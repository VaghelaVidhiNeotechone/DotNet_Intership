using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Roman_To_Integer
    {
        static int RomanToInt(string s)
        {
            Dictionary<char, int> romanMap = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int total = 0;
            int prevValue = 0;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                int currentValue = romanMap[s[i]];

                if (currentValue < prevValue)
                {
                    total -= currentValue;
                }
                else
                {
                    total += currentValue;
                }

                prevValue = currentValue;
            }

            return total;
        }

        public static void run()
        {
            string roman = "III";

            int result = RomanToInt(roman);

            Console.WriteLine($"Input: {roman}");
            Console.WriteLine($"Output: {result}");
        }
    }
}
