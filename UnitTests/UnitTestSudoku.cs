using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestSudoku
    {
        [TestMethod]
        public void TestCorrectSudoku()
        {
            var sudokuUtil = new VerifySudoku.SudokuUtil();

            bool result = sudokuUtil.VerifySudoku(@"input_sudoku1.txt");

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestWrongRow()
        {
            var sudokuUtil = new VerifySudoku.SudokuUtil();

            bool result = sudokuUtil.VerifySudoku(@"input_sudoku2.txt");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestWrongColumn()
        {
            var sudokuUtil = new VerifySudoku.SudokuUtil();

            bool result = sudokuUtil.VerifySudoku(@"input_sudoku3.txt");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestWrong3x3Box()
        {
            var sudokuUtil = new VerifySudoku.SudokuUtil();

            bool result = sudokuUtil.VerifySudoku(@"input_sudoku4.txt");

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestWrongFile()
        {
            var sudokuUtil = new VerifySudoku.SudokuUtil();

            bool result = sudokuUtil.VerifySudoku(@"input_sudoku5.txt");

            Assert.AreEqual(false, result);
        }
    }
}
