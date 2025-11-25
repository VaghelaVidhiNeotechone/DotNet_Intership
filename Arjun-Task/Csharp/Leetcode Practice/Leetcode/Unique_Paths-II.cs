using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Unique_Paths_II
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            int[,] dp = new int[m, n];

            dp[0, 0] = obstacleGrid[0][0] == 0 ? 1 : 0;

            for (int i = 1; i < m; i++)
            {
                dp[i, 0] = (obstacleGrid[i][0] == 0 && dp[i - 1, 0] == 1) ? 1 : 0;
            }

            for (int j = 1; j < n; j++)
            {
                dp[0, j] = (obstacleGrid[0][j] == 0 && dp[0, j - 1] == 1) ? 1 : 0;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            return dp[m - 1, n - 1];
        }

        public static void run()
        {
            int[][] obstacleGrid = new int[][]
            {
                new int[] { 0, 0, 0 },
                new int[] { 0, 1, 0 },
                new int[] { 0, 0, 0 }
            };

            Unique_Paths_II solution = new Unique_Paths_II();

            int result = solution.UniquePathsWithObstacles(obstacleGrid);
            Console.WriteLine("Number of unique paths: " + result);
        }
    }
}
