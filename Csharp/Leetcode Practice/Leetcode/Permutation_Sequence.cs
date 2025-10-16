using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Permutation_Sequence
    {
        public string GetPermutation(int n, int k)
        {
            List<int> numbers = new List<int>();
            int[] factorial = new int[n + 1];
            factorial[0] = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial[i] = factorial[i - 1] * i;
                numbers.Add(i);
            }

            k--;
            return GetKthPermutation(numbers, k, factorial);
        }

        private string GetKthPermutation(List<int> numbers, int k, int[] factorial)
        {
            if (numbers.Count == 0)
                return "";

            int n = numbers.Count;
            int blockSize = factorial[n - 1];
            int index = k / blockSize;
            int chosen = numbers[index];
            numbers.RemoveAt(index);
            k %= blockSize;

            return chosen.ToString() + GetKthPermutation(numbers, k, factorial);
        }

        public static void run()
        {
            Permutation_Sequence sol = new Permutation_Sequence();
            int n = 3, k = 3;
            string result = sol.GetPermutation(n, k);
            Console.WriteLine(result);
        }
    }
}
