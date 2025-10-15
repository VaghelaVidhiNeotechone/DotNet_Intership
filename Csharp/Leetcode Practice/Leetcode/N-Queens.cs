using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class N_Queens
    {
        public static IList<IList<string>> SolveNQueens(int n)
        {
            var results = new List<IList<string>>();
            var board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = new string('.', n).ToCharArray();
            }

            bool[] cols = new bool[n];
            bool[] diag1 = new bool[2 * n - 1];
            bool[] diag2 = new bool[2 * n - 1];

            Backtrack(0, board, results, cols, diag1, diag2, n);
            return results;
        }

        private static void Backtrack(int row, char[][] board, List<IList<string>> results, bool[] cols, bool[] diag1, bool[] diag2, int n)
        {
            if (row == n)
            {
                var solution = new List<string>();
                foreach (var r in board)
                {
                    solution.Add(new string(r));
                }
                results.Add(solution);
                return;
            }

            for (int col = 0; col < n; col++)
            {
                int d1 = row + col;
                int d2 = row - col + n - 1;

                if (cols[col] || diag1[d1] || diag2[d2])
                    continue;

                board[row][col] = 'Q';
                cols[col] = diag1[d1] = diag2[d2] = true;

                Backtrack(row + 1, board, results, cols, diag1, diag2, n);

                board[row][col] = '.';
                cols[col] = diag1[d1] = diag2[d2] = false;
            }
        }

        public static void run()
        {
            Console.Write("Enter the value of N (e.g., 4): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                var solution = SolveNQueens(n);
                Console.WriteLine($"\nTotal Solutions: {solution.Count}");

                for (int i = 0; i < solution.Count; i++)
                {
                    Console.WriteLine($"\nSolution {i + 1}:");
                    foreach (var row in solution[i])
                    {
                        Console.WriteLine(row);
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
    }
}
