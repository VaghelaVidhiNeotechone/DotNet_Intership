using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Permutation_Sequence_leetcode
    {
        public string GetPermutation(int n, int k)
        {
            var charIndices = new List<int>();
            k--;
            for (int i = 1; i <= n; i++)
            {
                charIndices.Add(k % i);
                k /= i;
            }

            charIndices.Reverse();
            var chars = Enumerable.Range(0, n).Select(v => (char)('1' + v)).ToList();

            var result = "";
            foreach (var idx in charIndices)
            {
                result += chars[idx];
                chars.RemoveAt(idx);
            }

            return result;
        }
        public static void run()
        {
            Permutation_Sequence_leetcode obj = new Permutation_Sequence_leetcode();
            Console.WriteLine("---- Permutation_Sequence_leetcode ----");
            Console.Write("Enter (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter (k): ");
            int k = int.Parse(Console.ReadLine());
            string result = obj.GetPermutation(n,k);
            Console.WriteLine("Result: "+result);

        }
    }
}
