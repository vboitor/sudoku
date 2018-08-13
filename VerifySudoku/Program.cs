using System;

namespace VerifySudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            SudokuUtil sudoku = new SudokuUtil();

            bool passed = sudoku.VerifySudoku(@"input_sudoku.txt");

            System.Console.WriteLine("Valid Sudoku: " + passed);

            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
