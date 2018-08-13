using System;
using System.Text.RegularExpressions;

namespace VerifySudoku
{
    public class SudokuUtil
    {
        private readonly int[,] matrix = new int[9, 9];

        public bool VerifySudoku(string fileName)
        {
            bool ret = true;

            if (!LoadSudokuFromFile(matrix, fileName))
            {
                return false;
            }

            if (!VerifyAllRows(matrix))
            {
                return false;
            }

            if (!VerifyAllCols(matrix))
            {
                return false;
            }
            if (!Verify3x3Squares(matrix))
            {
                return false;
            }
            return ret; ;
        }

        // load SUDOKU numbers into a 2D array
        private bool LoadSudokuFromFile(int[,] matrix, string fileName)
        {
            string line;
            int row = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
            {
                if (line == String.Empty)
                {
                    //this is to handle files with lines ending in 0D 0D 0A (CR CR LF)
                    continue;
                }

                //check line to be 9 characters long, containing only digits 1-9
                Match match = Regex.Match(line, @"^[1-9]{9}$");
                if(!match.Success)
                {
                    return false;
                }

                int col = 0;

                foreach (char c in line)
                {
                    int intVal = (int)Char.GetNumericValue(c);
                    matrix[row, col] = intVal;
                    col++;
                }
                row++;
            }
            file.Close();
            return true;

        }

        //verify SUDOKU rule for rows
        private bool VerifyAllRows(int[,] matrix)
        {
            for (int i = 0; i < 9; i++)
            {
                int[] row = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    row[j] = matrix[i, j];
                }
                if (!VerifyUnique(row))
                {
                    return false;
                }
            }
            return true;
        }

        //verify SUDOKU rule for cols
        private bool VerifyAllCols(int[,] matrix)
        {
            for (int i = 0; i < 9; i++)
            {
                int[] col = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    col[j] = matrix[j, i];
                }
                if (!VerifyUnique(col))
                {
                    return false;
                }
            }
            return true;
        }

        //verify SUDOKU rule for 3x3 squares
        private bool Verify3x3Squares(int[,] matrix)
        {
            bool ret = true;
            for (int i = 0; i < 9; i = i + 3)
            {
                for (int j = 0; j < 9; j = j + 3)
                {
                    int[] square = new int[9];
                    int index = 0;
                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            square[index] = matrix[k, l];
                            index++;
                        }
                    }
                    if (!VerifyUnique(square))
                    {
                        return false;
                    }
                }
            }
            return ret;
        }

        //verify SUDOKU numbers from 1-9 are unique
        private bool VerifyUnique(int[] arr)
        {
            bool ret = true;
            Array.Sort(arr);
            for (int i = 0; i < 9; i++)
            {
                if (arr[i] != i + 1)
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
    }
}
