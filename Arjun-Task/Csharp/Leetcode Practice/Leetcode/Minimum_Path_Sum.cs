using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Minimum_Path_Sum
    {
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    else if (i == 0)
                        grid[i][j] += grid[i][j - 1];
                    else if (j == 0)
                        grid[i][j] += grid[i - 1][j];
                    else
                        grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
                }
            }

            return grid[m - 1][n - 1];
        }

        public static void run()
        {
            int[][] grid = new int[][]
            {
                new int[] {1, 3, 1},
                new int[] {1, 5, 1},
                new int[] {4, 2, 1}
            };

            Minimum_Path_Sum sol = new Minimum_Path_Sum();

            int result = sol.MinPathSum(grid);

            Console.WriteLine("Minimum Path Sum: " + result);
        }
    }
}
