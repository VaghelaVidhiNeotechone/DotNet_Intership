using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Longest_Substring_Without_Repeating_Characters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            int maxLength = 0;
            int start = 0;

            for (int end = 0; end < s.Length; end++)
            {
                char currentChar = s[end];
                if (map.ContainsKey(currentChar) && map[currentChar] >= start)
                {
                    start = map[currentChar] + 1;
                }
                map[currentChar] = end;
                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }

        public static void run()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();
            int result = LengthOfLongestSubstring(input);
            Console.WriteLine("Length of longest substring without repeating characters: " + result);
        }
    }
}
