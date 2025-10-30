using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Valid_Sudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            HashSet<char>[] rows = new HashSet<char>[9];
            HashSet<char>[] cols = new HashSet<char>[9];
            HashSet<char>[] boxes = new HashSet<char>[9];

            for (int i = 0; i < 9; i++)
            {
                rows[i] = new HashSet<char>();
                cols[i] = new HashSet<char>();
                boxes[i] = new HashSet<char>();
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char val = board[i][j];

                    if (val == '.')
                        continue;

                    if (rows[i].Contains(val))
                        return false;
                    rows[i].Add(val);

                    if (cols[j].Contains(val))
                        return false;
                    cols[j].Add(val);

                    int boxIndex = (i / 3) * 3 + (j / 3);
                    if (boxes[boxIndex].Contains(val))
                        return false;
                    boxes[boxIndex].Add(val);
                }
            }

            return true;
        }

        public static void run()
        {
            char[][] board = new char[][] {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}
            };

            Valid_Sudoku solution = new Valid_Sudoku();
            bool isValid = solution.IsValidSudoku(board);

            Console.WriteLine("Is the Sudoku board valid? " + isValid);
        }
    }
}
