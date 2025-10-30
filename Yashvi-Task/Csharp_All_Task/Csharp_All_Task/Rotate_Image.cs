using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Rotate_Image
    {
        public void  Rotate(int[][] matrix)
        {
            int width = matrix.Length;
            if (width < 2)
                return;

            for (int row = 0; row < width / 2; row++)
                for (int col = row; col < width - row - 1; col++)
                {
                    var last = matrix.Length - 1;
                    var tmp = matrix[col][last - row];
                    matrix[col][last - row] = matrix[row][col];
                    matrix[row][col] = matrix[last - col][row];
                    matrix[last - col][row] = matrix[last - row][last - col];
                    matrix[last - row][last - col] = tmp;
                }
        }
        public static void run()
        {
            Rotate_Image obj = new Rotate_Image();
            Console.WriteLine("---- Rotate Image ----");
            Console.Write("Enter matrix size (e.g., 3 for 3x3): ");
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            Console.WriteLine($"Enter {n * n} numbers row by row (space separated):");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Row {i + 1}: ");
                matrix[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            }
            Console.WriteLine("\nOriginal Matrix:");
            PrintMatrix(matrix);
            obj.Rotate(matrix);
            Console.WriteLine("\nRotated Matrix (90° clockwise):");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("\t", row));
            }
        }

    }
}
