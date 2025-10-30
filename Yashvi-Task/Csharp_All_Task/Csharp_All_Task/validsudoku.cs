using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class validsudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            HashSet<string> seen = new HashSet<string>();

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    char num = board[row][col];

                    if (num == '.') continue; 

                    string rowCheck = $"{num} in row {row}";
                    string colCheck = $"{num} in col {col}";
                    string boxCheck = $"{num} in box {row / 3}-{col / 3}";

                    if (!seen.Add(rowCheck) || !seen.Add(colCheck) || !seen.Add(boxCheck))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void run()
        {
            validsudoku obj = new validsudoku();
            Console.WriteLine("---- Valid Sudoku ----");

            char[][] board = new char[][]
            {
                new char[] { '5','3','.','.','7','.','.','.','.' },
                new char[] { '6','.','.','1','9','5','.','.','.' },
                new char[] { '.','9','8','.','.','.','.','6','.' },
                new char[] { '8','.','.','.','6','.','.','.','3' },
                new char[] { '4','.','.','8','.','3','.','.','1' },
                new char[] { '7','.','.','.','2','.','.','.','6' },
                new char[] { '.','6','.','.','.','.','2','8','.' },
                new char[] { '.','.','.','4','1','9','.','.','5' },
                new char[] { '.','.','.','.','8','.','.','7','9' }
            };

            bool result = obj.IsValidSudoku(board);
            Console.WriteLine("Is Sudoku valid? " + result);
        }
    }
}
