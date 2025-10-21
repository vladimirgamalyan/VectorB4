using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestProject1;

namespace VectorB4.Tests
{
    [TestClass]
    public class GCodeFixerTests
    {
        public TestContext TestContext { get; set; }

        //[TestMethod]
        //public void Fix_GCodeFile_Mach4_MatchesReference()
        //{
        //    // Arrange
        //    var fixer = new GCodeFixer();
        //    var parameters = new GCodeFixer.FixParameters
        //    {
        //        Repeats = 2,
        //        RepeatStep = 1.0m,
        //        Format = AppConfig.FormatType.Mach4,
        //        Orientation = AppConfig.OrientationType.Hor,
        //        RepeatsMode = AppConfig.RepeatsType.Zero
        //    };

        //    // Загружаем вход и эталон
        //    List<string> input = TestUtils.LoadFile("input_fix_mach3.tap");
        //    List<string> expected = TestUtils.LoadFile("reference_fix_mach3.tap");

        //    // Act
        //    List<string> actual = fixer.FixLines(input, parameters);

        //    // Assert
        //    TestUtils.AssertFilesEqual(expected, actual, "Fix Mach3: ");
        //}

        [TestMethod]
        public void Fix_GCodeFile_Mach3_MatchesReference_Zero()
        {
            // Arrange
            var fixer = new GCodeFixer();
            var parameters = new GCodeFixer.FixParameters
            {
                Repeats = 3,
                RepeatStep = 0.1m,
                Format = AppConfig.FormatType.Mach3,
                Orientation = AppConfig.OrientationType.Hor,
                RepeatsMode = AppConfig.RepeatsType.Zero
            };

            List<string> input = TestUtils.LoadFile("input_fix.tap");
            List<string> expected = TestUtils.LoadFile("reference_fix_zero.tap");

            // Act
            List<string> actual = fixer.FixLines(input, parameters);

            // Assert
            TestUtils.AssertFilesEqual(expected, actual, "Fix: ");
        }

        [TestMethod]
        public void Fix_GCodeFile_Mach3_MatchesReference_End()
        {
            // Arrange
            var fixer = new GCodeFixer();
            var parameters = new GCodeFixer.FixParameters
            {
                Repeats = 3,
                RepeatStep = 0.1m,
                Format = AppConfig.FormatType.Mach3,
                Orientation = AppConfig.OrientationType.Hor,
                RepeatsMode = AppConfig.RepeatsType.End
            };

            List<string> input = TestUtils.LoadFile("input_fix.tap");
            List<string> expected = TestUtils.LoadFile("reference_fix_end.tap");

            // Act
            List<string> actual = fixer.FixLines(input, parameters);

            // Assert
            TestUtils.AssertFilesEqual(expected, actual, "Fix: ");
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Fix_AlreadyProcessed_Throws()
        {
            // Arrange
            var fixer = new GCodeFixer();
            var parameters = new GCodeFixer.FixParameters
            {
                Repeats = 1,
                RepeatStep = 1.0m,
                Format = AppConfig.FormatType.Mach3,
                Orientation = AppConfig.OrientationType.Hor,
                RepeatsMode = AppConfig.RepeatsType.Zero
            };

            // Входной файл уже содержит маркер "( vozvrat ispravlen, dobavleny povtory )"
            List<string> input = TestUtils.LoadFile("input_already_fixed.tap");

            // Act
            fixer.FixLines(input, parameters);
        }

        //[TestMethod]
        //public void ShiftProgram_CorrectlyOffsetsCoordinates()
        //{
        //    // Arrange
        //    var input = new List<string> { "G1X0", "G1X1.5", "G1X3.0" };
        //    var expected = new List<string> { "G1X-1", "G1X0.5", "G1X2" };

        //    // Act
        //    List<string> actual = GCodeFixer.ShiftProgramForTest(input, 1.0m, false, AppConfig.OrientationType.Hor);

        //    // Assert
        //    TestUtils.AssertFilesEqual(expected, actual, "ShiftProgram: ");
        //}
    }
}
