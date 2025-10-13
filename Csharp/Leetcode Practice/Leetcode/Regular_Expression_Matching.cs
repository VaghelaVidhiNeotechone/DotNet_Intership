using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Regular_Expression_Matching
    {
        public bool IsMatch(string s, string p)
        {
            return MatchHelper(s, p, 0, 0);
        }

        private bool MatchHelper(string s, string p, int i, int j)
        {
            if (j == p.Length)
            {
                return i == s.Length;
            }

            bool firstMatch = (i < s.Length &&
                              (s[i] == p[j] || p[j] == '.'));

            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                return MatchHelper(s, p, i, j + 2) ||
                       (firstMatch && MatchHelper(s, p, i + 1, j));
            }
            else
            {
                return firstMatch && MatchHelper(s, p, i + 1, j + 1);
            }
        }

        public static void run()
        {
            Regular_Expression_Matching solution = new Regular_Expression_Matching();

            Console.WriteLine("Enter string (s):");
            string s = Console.ReadLine();

            Console.WriteLine("Enter pattern (p):");
            string p = Console.ReadLine();

            bool result = solution.IsMatch(s, p);

            Console.WriteLine($"IsMatch(\"{s}\", \"{p}\") => {result}");
        }
    }
}
