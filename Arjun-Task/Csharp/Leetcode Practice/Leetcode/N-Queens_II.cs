using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class N_Queens_II
    {
        private int count = 0;

        public int TotalNQueens(int n)
        {
            bool[] cols = new bool[n];
            bool[] diag1 = new bool[2 * n];
            bool[] diag2 = new bool[2 * n];

            Backtrack(0, n, cols, diag1, diag2);
            return count;
        }

        private void Backtrack(int row, int n, bool[] cols, bool[] diag1, bool[] diag2)
        {
            if (row == n)
            {
                count++;
                return;
            }

            for (int col = 0; col < n; col++)
            {
                int d1 = row - col + n;
                int d2 = row + col;

                if (cols[col] || diag1[d1] || diag2[d2])
                    continue;

                cols[col] = diag1[d1] = diag2[d2] = true;

                Backtrack(row + 1, n, cols, diag1, diag2);

                cols[col] = diag1[d1] = diag2[d2] = false;
            }
        }

        public static void run()
        {
            Console.WriteLine("Enter the value of n (number of queens): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                N_Queens_II solution = new N_Queens_II();
                int result = solution.TotalNQueens(n);
                Console.WriteLine($"Number of distinct solutions for {n}-Queens: {result}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }
    }
}
