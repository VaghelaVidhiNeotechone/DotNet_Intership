using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Minimum_Path_Sum
    {
        public int MinPathSum(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    if (i == 0)
                    {
                        grid[i][j] += grid[i][j - 1];
                        continue;
                    }

                    if (j == 0)
                    {
                        grid[i][j] += grid[i - 1][j];
                        continue;
                    }

                    grid[i][j] += Math.Min(grid[i][j - 1], grid[i - 1][j]);
                }
            }

            return grid[grid.Length - 1][grid[0].Length - 1];
        }
        public static void run()
        {
            Minimum_Path_Sum obj = new Minimum_Path_Sum();
            int[][] grid = new int[][]
            {
                new int[] { 1, 3, 1 },
                new int[] { 1, 5, 1 },
                new int[] { 4, 2, 1 }
            };
            Console.WriteLine("Grid (Each cell represents a cost):");
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    Console.Write(grid[i][j] + "\t");
                }
                Console.WriteLine();
            }
            int minSum = obj.MinPathSum(grid);
            Console.WriteLine($"\nMinimum Path Sum (Top-Left to Bottom-Right): {minSum}");
        }
    }
}
