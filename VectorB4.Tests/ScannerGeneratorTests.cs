using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using UnitTestProject1;
using VectorB4;

namespace UnitTestProject1
{
    [TestClass]
    public class ScannerGeneratorTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GenerateLines_Horizontal_MatchesReferenceFile()
        {
            // Arrange
            var generator = new ScannerGenerator();
            var parameters = new ScannerGenerator.TapParameters
            {
                Radius = 150,
                Speed = 100,
                Step = 1,
                Retire = 1,
                Orientation = AppConfig.OrientationType.Hor,
                InputOblakoFile = "oblako.txt"
            };

            List<string> expected = TestUtils.LoadFile("reference_scan.tap");

            // Act
            List<string> actual = generator.GenerateLines(parameters);

            // Assert
            TestUtils.AssertFilesEqual(expected, actual, "Проверка ScannerGenerator: ");
        }
    }
}
