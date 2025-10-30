using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Sudoku_Solver
    {
        public void SolveSudoku(char[][] board)
        {
            Solve(board);
        }

        private bool Solve(char[][] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (IsValid(board, row, col, c))
                            {
                                board[row][col] = c;

                                if (Solve(board))
                                    return true;
                                else
                                    board[row][col] = '.';
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValid(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] == c) return false;
                if (board[row][i] == c) return false;
                if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c) return false;
            }
            return true;
        }

        public static void run()
        {
            char[][] board = new char[][]
            {
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

            Sudoku_Solver solver = new Sudoku_Solver();
            solver.SolveSudoku(board);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    Console.Write(board[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}
