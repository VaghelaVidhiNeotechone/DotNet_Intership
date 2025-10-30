using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Spiral_Matrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            int left = 0, right = m - 1;
            int top = 0, bottom = n - 1;
            List<int> result = new List<int>();

            while (left <= right && top <= bottom)
            {
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }
                top++;
                for (int i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }
                right--;
                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        result.Add(matrix[bottom][i]);
                    }
                    bottom--;
                }
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }
                    left++;
                }
            }
            return result;

        }
        public static void run()
        {
            Spiral_Matrix obj = new Spiral_Matrix();
            Console.WriteLine("---- Spiral Matrix ----");
            Console.Write("Enter number of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            int cols = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            Console.WriteLine($"Enter {rows} rows with {cols} space-separated numbers each:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"Row {i + 1}: ");
                matrix[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            }
            IList<int> result = obj.SpiralOrder(matrix);
            Console.WriteLine("\nMatrix in Spiral Order:");
            Console.WriteLine("[ " + string.Join(", ", result) + " ]");
        }

    }
}
