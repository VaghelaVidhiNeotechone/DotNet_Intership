using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Unique_Paths
    {
        public int UniquePaths(int m, int n)
        {
            int[,] result = new int[m, n];
            result[0, 0] = 1;
            return FindPaths(result, m - 1, n - 1);
        }

        private int FindPaths(int[,] result, int m, int n)
        {
            if (m < 0 || n < 0)
            {
                return 0;
            }
            if (result[m, n] == 0)
            {
                result[m, n] = FindPaths(result, m - 1, n) + FindPaths(result, m, n - 1);
            }

            return result[m, n];
        }
        public static void run()
        {
            Unique_Paths obj = new Unique_Paths();

            Console.WriteLine("Enter number of rows (m): ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of columns (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            int totalPaths = obj.UniquePaths(m, n);

            Console.WriteLine($"\nTotal unique paths in a {m}x{n} grid: {totalPaths}");
        }
    }
}
