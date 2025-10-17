using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestProject1
{
    public static class TestUtils
    {
        public static List<string> LoadFile(string fileName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(baseDir, fileName);

            // Если файл не найден в корне сборки — ищем в подпапке TestData
            if (!File.Exists(path))
            {
                string altPath = Path.Combine(baseDir, "TestData", fileName);
                if (File.Exists(altPath))
                    path = altPath;
                else
                    Assert.Fail($"Файл не найден ни по пути:\n{path}\nни по пути:\n{altPath}");
            }

            try
            {
                return File.ReadAllLines(path, System.Text.Encoding.GetEncoding("Windows-1251")).ToList();
            }
            catch
            {
                return File.ReadAllLines(path, System.Text.Encoding.UTF8).ToList();
            }
        }

        public static void AssertFilesEqual(List<string> expected, List<string> actual, string context = "")
        {
            Assert.AreEqual(expected.Count, actual.Count,
                $"{context}Количество строк различается: ожидалось {expected.Count}, получено {actual.Count}");

            for (int i = 0; i < expected.Count; i++)
            {
                string exp = expected[i].TrimEnd();
                string act = actual[i].TrimEnd();

                if (exp != act)
                {
                    string message =
                        $"{context}Несовпадение в строке {i + 1}:\n" +
                        $"Ожидалось: \"{exp}\"\n" +
                        $"Получено:  \"{act}\"";
                    Assert.Fail(message);
                }
            }
        }
    }
}
