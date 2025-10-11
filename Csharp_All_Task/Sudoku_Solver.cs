using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Sudoku_Solver
    {
        public void SolveSudoku(char[][] board)
        {
            SolveSudoku(board, 0, 0);
        }

        private bool SolveSudoku(char[][] board, int row, int col)
        {
            if (col == 9)
            {
                col = 0;
                row++;

                if (row == 9)
                {
                    return true;
                }
            }

            if (board[row][col] != '.')
            {
                return SolveSudoku(board, row, col + 1);
            }

            for (char c = '1'; c <= '9'; c++)
            {
                if (IsValid(board, row, col, c))
                {
                    board[row][col] = c;

                    if (SolveSudoku(board, row, col + 1))
                    {
                        return true;
                    }

                    board[row][col] = '.';
                }
            }

            return false;
        }

        private bool IsValid(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == c)
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] == c)
                {
                    return false;
                }
            }
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (board[i][j] == c)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public static void run()
        {
            Sudoku_Solver obj = new Sudoku_Solver();
            Console.WriteLine("---- Sudoku Solver ----");

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

            obj.SolveSudoku(board);
            Console.WriteLine("Solved Sudoku Board:\n");
            PrintBoard(board);
        }
        private static void PrintBoard(char[][] board)
        {
            Console.WriteLine("[");

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i][j] + " , ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("]");
        }
    }
}
