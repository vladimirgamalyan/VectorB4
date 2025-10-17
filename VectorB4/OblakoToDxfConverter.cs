using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace VectorB4
{
    /// <summary>
    /// Преобразует облако точек (список строк) в DXF-полилинию.
    /// Поддерживает форматы Mach3 и Mach4.
    /// </summary>
    public class OblakoToDxfConverter
    {
        public class ConvertParameters
        {
            public AppConfig.FormatType Format { get; set; }
        }

        public List<string> ConvertLines(List<string> sourceLines, ConvertParameters p)
        {
            if (sourceLines == null || sourceLines.Count == 0)
                throw new ArgumentException("Пустые входные данные.");

            var result = new List<string>();

            // --- Заголовок DXF ---
            result.Add("0");
            result.Add("SECTION");
            result.Add("  2");
            result.Add("ENTITIES");
            result.Add("  0");
            result.Add("POLYLINE");
            result.Add("  8");
            result.Add("");

            foreach (string line in sourceLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] values;

                switch (p.Format)
                {
                    case AppConfig.FormatType.Mach3:
                        // Пример строки: 77.01367,129.99375,0.00000
                        values = line.Split(',')
                                     .Select(s => s.Trim())
                                     .ToArray();
                        break;

                    case AppConfig.FormatType.Mach4:
                        // Пример строки: X-6.0670 Y0.0000 Z0.0000
                        values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(s => s.Trim().Substring(1))
                                     .ToArray();
                        break;

                    default:
                        throw new InvalidOperationException("Unknown format: " + p.Format);
                }

                if (values.Length < 3)
                    continue; // Пропускаем некорректную строку

                // --- Вершина DXF ---
                result.Add("  0");
                result.Add("VERTEX");
                result.Add("  8");
                result.Add("0");
                result.Add(" 10");
                result.Add(values[0]);
                result.Add(" 20");
                result.Add(values[1]);
                result.Add(" 30");
                result.Add(values[2]);
                result.Add(" 70");
                result.Add("    32");
            }

            // --- Завершение секции ---
            result.Add("  0");
            result.Add("SEQEND");
            result.Add("  0");
            result.Add("ENDSEC");
            result.Add("  0");
            result.Add("EOF");

            return result;
        }
    }
}
