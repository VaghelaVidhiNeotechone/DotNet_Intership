using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Wildcard_Matching
    {
        public bool IsMatch(string s, string p)
        {
            string pattern = "^" + Regex.Escape(p)
                                        .Replace("\\?", ".")
                                        .Replace("\\*", ".*") + "$";
            return Regex.IsMatch(s, pattern);
        }

        public static void run()
        {
            var solution = new Wildcard_Matching();

            Console.WriteLine("Enter the input string (s):");
            string s = Console.ReadLine();

            Console.WriteLine("Enter the pattern (p):");
            string p = Console.ReadLine();

            bool isMatch = solution.IsMatch(s, p);

            Console.WriteLine($"Does \"{s}\" match pattern \"{p}\"? {isMatch}");
        }
    }
}
