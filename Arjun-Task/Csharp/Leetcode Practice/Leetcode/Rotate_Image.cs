using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Rotate_Image
    {
        static void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                Array.Reverse(matrix[i]);
            }
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(", ", row));
            }
        }

        public static void run()
        {
            int[][] matrix = new int[][]
            {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6},
            new int[] {7, 8, 9}
            };

            Console.WriteLine("Original Matrix:");
            PrintMatrix(matrix);

            Rotate(matrix);

            Console.WriteLine("\nRotated Matrix:");
            PrintMatrix(matrix);
        }
    }
}
