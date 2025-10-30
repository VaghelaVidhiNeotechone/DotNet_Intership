using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Spiral_Matrix_II
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            int top = 0, bottom = n - 1;
            int left = 0, right = n - 1;
            int num = 1;
            int max = n * n;

            while (num <= max)
            {
                for (int i = left; i <= right && num <= max; i++)
                {
                    matrix[top][i] = num++;
                }
                top++;

                for (int i = top; i <= bottom && num <= max; i++)
                {
                    matrix[i][right] = num++;
                }
                right--;

                for (int i = right; i >= left && num <= max; i--)
                {
                    matrix[bottom][i] = num++;
                }
                bottom--;

                for (int i = bottom; i >= top && num <= max; i--)
                {
                    matrix[i][left] = num++;
                }
                left++;
            }

            return matrix;
        }

        public static void run()
        {
            Console.Write("Enter the size of the matrix (n): ");
            int n = int.Parse(Console.ReadLine());

            Spiral_Matrix_II solution = new Spiral_Matrix_II();
            int[][] result = solution.GenerateMatrix(n);

            Console.WriteLine("\nSpiral Matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(result[i][j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}
