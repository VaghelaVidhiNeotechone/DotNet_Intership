using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Spiral_Matrix_II
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            int left = 0, right = n - 1, top = 0, bottom = n - 1;
            int count = 1;
            for (int k = 0; k < n; k++)
            {
                result[k] = new int[n];
            }

            while (left <= right && top <= bottom)
            {
                for (int i = left; i <= right; i++)
                {
                    result[top][i] = count;
                    count++;
                }
                top++;
                for (int i = top; i <= bottom; i++)
                {
                    result[i][right] = count;
                    count++;
                }
                right--;
                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        result[bottom][i] = count;
                        count++;
                    }
                }
                bottom--;
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result[i][left] = count;
                        count++;
                    }
                }
                left++;
            }
            return result;
        }
        public static void run()
        {
            Spiral_Matrix_II obj = new Spiral_Matrix_II();
            Console.WriteLine("---- Spiral Matrix II ----");
            Console.Write("Enter the size of the matrix (n): ");
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = obj.GenerateMatrix(n);

            Console.WriteLine($"\nGenerated {n}x{n} Spiral Matrix:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i][j].ToString().PadLeft(4)); 
                }
                Console.WriteLine();
            }
        }

    }
}
