using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Longest_Substring_Without_Repeating_Characters
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> seen = new Dictionary<char, int>();
            int i = 0, res = 0;

            for (int j = 0; j < s.Length; j++)
            {
                char currentChar = s[j];
                if (seen.ContainsKey(currentChar))
                {
                    i = Math.Max(i, seen[currentChar] + 1);
                }
                seen[currentChar] = j;
                res = Math.Max(res, j - i + 1);
            }

            return res;
        }
        public static void run()
        {
            Console.WriteLine("---- Longest Substring Without Repeating Characters ----");
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            var solver = new Longest_Substring_Without_Repeating_Characters();
            int length = solver.LengthOfLongestSubstring(input);

            Console.WriteLine("Length of longest substring without repeating characters: " + length);

        }
    }
}
