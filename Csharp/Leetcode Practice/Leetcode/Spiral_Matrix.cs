using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Spiral_Matrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();

            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return result;

            int top = 0;
            int bottom = matrix.Length - 1;
            int left = 0;
            int right = matrix[0].Length - 1;

            while (top <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++)
                    result.Add(matrix[top][i]);
                top++;

                for (int i = top; i <= bottom; i++)
                    result.Add(matrix[i][right]);
                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                        result.Add(matrix[bottom][i]);
                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                        result.Add(matrix[i][left]);
                    left++;
                }
            }

            return result;
        }

        public static void run()
        {
            int[][] matrix = new int[][]
            {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6},
            new int[] {7, 8, 9}
            };

            Spiral_Matrix sm = new Spiral_Matrix();
            IList<int> result = sm.SpiralOrder(matrix);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
