using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestProject1;

namespace VectorB4.Tests
{
    [TestClass]
    public class OblakoToDxfConverterTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void ConvertLines_Mach3_MatchesReference()
        {
            // Arrange
            var converter = new OblakoToDxfConverter();
            var parameters = new OblakoToDxfConverter.ConvertParameters
            {
                Format = AppConfig.FormatType.Mach3
            };

            // Загружаем вход и эталон через TestUtils
            List<string> input = TestUtils.LoadFile("input_oblako_mach3.txt");
            List<string> expected = TestUtils.LoadFile("reference_dxf_mach3.dxf");

            // Act
            List<string> actual = converter.ConvertLines(input, parameters);

            // Assert
            TestUtils.AssertFilesEqual(expected, actual, "Mach3 → DXF: ");
        }

        [TestMethod]
        public void ConvertLines_Mach4_MatchesReference()
        {
            // Arrange
            var converter = new OblakoToDxfConverter();
            var parameters = new OblakoToDxfConverter.ConvertParameters
            {
                Format = AppConfig.FormatType.Mach4
            };

            List<string> input = TestUtils.LoadFile("input_oblako_mach4.txt");
            List<string> expected = TestUtils.LoadFile("reference_dxf_mach4.dxf");

            // Act
            List<string> actual = converter.ConvertLines(input, parameters);

            // Assert
            TestUtils.AssertFilesEqual(expected, actual, "Mach4 → DXF: ");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ConvertLines_EmptyInput_Throws()
        {
            // Arrange
            var converter = new OblakoToDxfConverter();
            var parameters = new OblakoToDxfConverter.ConvertParameters
            {
                Format = AppConfig.FormatType.Mach3
            };

            // Act
            converter.ConvertLines(new List<string>(), parameters);
        }
    }
}
