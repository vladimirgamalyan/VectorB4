using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VectorB4
{
    /// <summary>
    /// Представляет одну строку G-кода (например: G1 X10.5 Y-3.2 F1200)
    /// </summary>
    public class GCodeCommand
    {
        public string Command { get; set; } = "";                     // G1, M3, G92 и т.п.
        public Dictionary<char, double> Parameters { get; set; } = new Dictionary<char, double>();
        public string Comment { get; set; } = "";

        public override string ToString()
        {
            var args = string.Join(" ", Parameters.Select(p => $"{p.Key}{p.Value}"));
            return string.IsNullOrEmpty(Comment)
                ? $"{Command} {args}".Trim()
                : $"{Command} {args} ; {Comment}".Trim();
        }
    }

    /// <summary>
    /// Парсер одной строки G-кода
    /// </summary>
    public static class GCodeParser
    {
        private static readonly Regex tokenRegex = new Regex(
            @"([GMT]\d+)|([XYZEFIJKRSP]\s*[-+]?\d*\.?\d+)|;.*$|\(.*?\)",
            RegexOptions.IgnoreCase);

        /// <summary>
        /// Разбирает одну строку G-кода и возвращает объект команды.
        /// Возвращает null, если строка пуста или не содержит команд.
        /// </summary>
        public static GCodeCommand ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            line = line.Trim();
            var matches = tokenRegex.Matches(line);
            var cmd = new GCodeCommand();

            foreach (Match match in matches)
            {
                string token = match.Value.Trim();

                // Комментарий
                if (token.StartsWith(";") || token.StartsWith("("))
                {
                    cmd.Comment = token.Trim(';', '(', ')', ' ');
                    continue;
                }

                // Команда (G1, M3, и т.п.)
                if (Regex.IsMatch(token, @"^[GMT]\d+", RegexOptions.IgnoreCase))
                {
                    cmd.Command = token.ToUpper();
                    continue;
                }

                // Аргументы (X10, Y-3.5, F1200)
                if (token.Length > 1)
                {
                    char axis = token[0];
                    double value;
                    if (double.TryParse(token.Substring(1).Replace(" ", ""), out value))
                        cmd.Parameters[axis] = value;
                }
            }

            if (!string.IsNullOrEmpty(cmd.Command) || cmd.Parameters.Count > 0)
                return cmd;

            return null;
        }
    }
}
