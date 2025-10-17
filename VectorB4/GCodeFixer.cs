using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace VectorB4
{
    /// <summary>
    /// Исправляет G-код после сканирования (возврат, повторы и т.п.).
    /// </summary>
    public class GCodeFixer
    {
        public class FixParameters
        {
            public int Repeats { get; set; }
            public decimal RepeatStep { get; set; }
            public AppConfig.FormatType Format { get; set; }
            public AppConfig.OrientationType Orientation { get; set; }
            public AppConfig.RepeatsType RepeatsMode { get; set; }
        }

        private const string MarkerConverted = "( vozvrat ispravlen, dobavleny povtory )";

        public List<string> FixLines(List<string> lines, FixParameters p)
        {
            if (lines == null || lines.Count == 0)
                throw new ArgumentException("Пустой входной список строк.");

            if (lines.Contains(MarkerConverted))
                throw new InvalidOperationException("Файл уже был обработан.");

            // === 1. Исправляем возврат инструмента ===
            List<string> linesCorrected = new List<string>();
            foreach (string l in lines)
            {
                string line = Regex.Replace(l, @"\(\*.*?\*\)", "").Trim();
                if (line == "G0X0.000Y0.000")
                {
                    switch (p.Orientation)
                    {
                        case AppConfig.OrientationType.Hor:
                            linesCorrected.Add("G0X0");
                            linesCorrected.Add("G0Y0");
                            break;
                        case AppConfig.OrientationType.Ver:
                            linesCorrected.Add("G0Y0");
                            linesCorrected.Add("G0X0");
                            break;
                        default:
                            throw new Exception("Unknown orientation");
                    }
                }
                else if (!string.IsNullOrEmpty(line))
                {
                    linesCorrected.Add(line);
                }
            }

            // === 2. Отделяем тело программы между M3 и M30 ===
            List<string> linesResult = new List<string> { MarkerConverted };
            List<string> linesProgramBody = new List<string>();

            bool programBody = false;
            foreach (string line in linesCorrected)
            {
                if (programBody && line.Contains("M30"))
                    break;

                if (programBody)
                    linesProgramBody.Add(line);
                else
                    linesResult.Add(line);

                if (line.Contains("M3"))
                    programBody = true;
            }

            if (linesProgramBody.Count == 0)
                throw new InvalidOperationException("Не найден блок программы.");

            // === 3. Удаляем G0 с конца ===
            for (int i = linesProgramBody.Count - 1; i >= 0; i--)
            {
                if (linesProgramBody[i].StartsWith("G0", StringComparison.OrdinalIgnoreCase))
                    linesProgramBody.RemoveAt(i);
                else
                    break;
            }

            if (linesProgramBody.Count < 2)
                throw new InvalidOperationException("Слишком короткий блок программы.");

            string firstProgramLine = linesProgramBody[0];
            if (!firstProgramLine.StartsWith("G0", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("В первой строке программы не найдена команда G0");

            linesProgramBody.RemoveAt(0);

            foreach (string line in linesProgramBody)
            {
                if (!line.StartsWith("G1", StringComparison.OrdinalIgnoreCase) &&
                    !line.StartsWith("X", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("В программе найдены лишние команды: " + line);
            }

            // === 4. Пролог / эпилог ===
            List<string> progProlog = new List<string>();
            List<string> progEpilog = new List<string>();
            List<string> progGlobalProlog = new List<string>();
            List<string> progGlobalEpilog = new List<string>();

            switch (p.RepeatsMode)
            {
                case AppConfig.RepeatsType.Zero:
                    progProlog.Add(firstProgramLine);
                    switch (p.Orientation)
                    {
                        case AppConfig.OrientationType.Hor:
                            progEpilog.Add("G0X0");
                            progEpilog.Add("G0Y0");
                            break;
                        case AppConfig.OrientationType.Ver:
                            progEpilog.Add("G0Y0");
                            progEpilog.Add("G0X0");
                            break;
                    }
                    break;

                case AppConfig.RepeatsType.End:
                    progGlobalProlog.Add(firstProgramLine);
                    switch (p.Orientation)
                    {
                        case AppConfig.OrientationType.Hor:
                            progGlobalEpilog.Add("G0X0");
                            progGlobalEpilog.Add("G0Y0");
                            break;
                        case AppConfig.OrientationType.Ver:
                            progGlobalEpilog.Add("G0Y0");
                            progGlobalEpilog.Add("G0X0");
                            break;
                    }
                    break;

                default:
                    throw new Exception("Unknown RepeatsType");
            }

            // === 5. Генерация циклов ===
            linesResult.Add("");
            linesResult.AddRange(progGlobalProlog);
            linesResult.Add("");

            bool reverse = false;
            for (int i = 0; i < p.Repeats; ++i)
            {
                if (p.RepeatsMode != AppConfig.RepeatsType.End)
                    reverse = false;

                linesResult.Add("");
                linesResult.Add(string.Format("(* cicl {0} iz {1} *)", i + 1, p.Repeats));
                linesResult.AddRange(progProlog);
                linesResult.AddRange(ShiftProgram(linesProgramBody, p.RepeatStep * i, reverse, p.Orientation));
                linesResult.AddRange(progEpilog);

                reverse = !reverse;
            }

            linesResult.Add("");
            linesResult.AddRange(progGlobalEpilog);
            linesResult.Add("");

            if (p.Format == AppConfig.FormatType.Mach4)
                linesResult.Add("M05");

            linesResult.Add("M30");

            return linesResult;
        }

        private static List<string> ShiftProgram(List<string> lines, decimal offset, bool reverse, AppConfig.OrientationType orientationType)
        {
            bool changed = false;

            string orientation;
            switch (orientationType)
            {
                case AppConfig.OrientationType.Hor:
                    orientation = "X";
                    break;
                case AppConfig.OrientationType.Ver:
                    orientation = "Y";
                    break;
                default:
                    throw new Exception("Unknown orientation");
            }

            string pattern = $@"(?<![A-Z])({orientation}-?(?:\d+(?:\.\d+)?|\.\d+))";
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.CultureInvariant);
            var nfi = new NumberFormatInfo { NumberDecimalSeparator = ".", NumberGroupSeparator = "" };

            var result = new List<string>(lines.Count);

            foreach (string line in lines)
            {
                string newLine = regex.Replace(line, match =>
                {
                    string token = match.Groups[1].Value;
                    string numPart = token.Substring(1);

                    if (!decimal.TryParse(numPart, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal value))
                        throw new Exception($"Unable to parse {token}");

                    value -= offset;
                    changed = true;

                    return orientation + value.ToString("0.###", nfi);
                });

                if (reverse)
                    result.Insert(0, newLine);
                else
                    result.Add(newLine);
            }

            if (!changed)
                throw new Exception("nothing to shift in loop");

            return result;
        }
    }
}
