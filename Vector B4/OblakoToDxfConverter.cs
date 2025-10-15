using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Vector_B4
{
    /// <summary>
    /// Преобразует файл облака точек (oblako.txt) в DXF-полилинию.
    /// Поддерживает форматы Mach3 и Mach4.
    /// </summary>
    public class OblakoToDxfConverter
    {
        public class ConvertParameters
        {
            public string InputFile { get; set; }
            public string OutputFile { get; set; }
            public AppConfig.FormatType Format { get; set; }
        }

        public void Convert(ConvertParameters p)
        {
            if (string.IsNullOrWhiteSpace(p.InputFile))
                throw new ArgumentException("InputFile не задан.");
            if (string.IsNullOrWhiteSpace(p.OutputFile))
                throw new ArgumentException("OutputFile не задан.");
            if (!File.Exists(p.InputFile))
                throw new FileNotFoundException("Файл не найден: " + p.InputFile);

            using (var srcFile = new StreamReader(p.InputFile))
            using (var dstFile = new StreamWriter(p.OutputFile, false, System.Text.Encoding.GetEncoding("Windows-1251")))
            {
                // Заголовок DXF
                dstFile.WriteLine("0");
                dstFile.WriteLine("SECTION");
                dstFile.WriteLine("  2");
                dstFile.WriteLine("ENTITIES");
                dstFile.WriteLine("  0");
                dstFile.WriteLine("POLYLINE");
                dstFile.WriteLine("  8");
                dstFile.WriteLine("");

                string line;
                while ((line = srcFile.ReadLine()) != null)
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

                    // DXF vertex
                    dstFile.WriteLine("  0");
                    dstFile.WriteLine("VERTEX");
                    dstFile.WriteLine("  8");
                    dstFile.WriteLine("0");
                    dstFile.WriteLine(" 10");
                    dstFile.WriteLine(values[0]);
                    dstFile.WriteLine(" 20");
                    dstFile.WriteLine(values[1]);
                    dstFile.WriteLine(" 30");
                    dstFile.WriteLine(values[2]);
                    dstFile.WriteLine(" 70");
                    dstFile.WriteLine("    32");
                }

                // Завершение секции
                dstFile.WriteLine("  0");
                dstFile.WriteLine("SEQEND");
                dstFile.WriteLine("  0");
                dstFile.WriteLine("ENDSEC");
                dstFile.WriteLine("  0");
                dstFile.WriteLine("EOF");
            }
        }
    }
}
