using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Unique_Paths_II
    {
        Dictionary<string, int> _dict = new Dictionary<string, int>();
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            return FindPath(obstacleGrid, obstacleGrid.Length - 1, obstacleGrid[0].Length - 1, 0, 0);
        }

        private int FindPath(int[][] obstacleGrid, int m, int n, int start, int end)
        {
            if (m < start || n < end)
            {
                return 0;
            }
            else if (obstacleGrid[start][end] == 1)
            {
                return 0;
            }
            else if (m == start && n == end)
            {
                return 1;
            }
            if (!_dict.ContainsKey($"{start}=>{end}"))
            {
                _dict[$"{start}=>{end}"] = FindPath(obstacleGrid, m, n, start + 1, end) + FindPath(obstacleGrid, m, n, start, end + 1);
            }
            return _dict[$"{start}=>{end}"];
        }
        public static void run()
        {
            Unique_Paths_II obj = new Unique_Paths_II();
            int[][] grid = new int[][]
            {
                new int[] { 0, 0, 0 },
                new int[] { 0, 1, 0 },
                new int[] { 0, 0, 0 }
            };

            Console.WriteLine("Grid (0 = Free, 1 = Obstacle):");
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    Console.Write(grid[i][j] + " ");
                }
                Console.WriteLine();
            }

            int totalPaths = obj.UniquePathsWithObstacles(grid);

            Console.WriteLine($"\nTotal unique paths (avoiding obstacles): {totalPaths}");
        }
    }
}
