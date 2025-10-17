using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Unique_Paths
    {
        public int UniquePaths(int m, int n)
        {
            return (int)BinomialCoefficient(m + n - 2, Math.Min(m - 1, n - 1));
        }

        private long BinomialCoefficient(int n, int k)
        {
            long result = 1;
            for (int i = 1; i <= k; i++)
            {
                result = result * (n - k + i) / i;
            }
            return result;
        }

        public static void run()
        {
            Unique_Paths sol = new Unique_Paths();
            int m = 3, n = 7;
            Console.WriteLine(sol.UniquePaths(m, n));
        }
    }
}
