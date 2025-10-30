using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Integer_To_Roman
    {
        public static string IntToRoman(int num)
        {
            Dictionary<int, string> romanMap = new Dictionary<int, string>() {
            {1000, "M"},
            {900, "CM"},
            {500, "D"},
            {400, "CD"},
            {100, "C"},
            {90, "XC"},
            {50, "L"},
            {40, "XL"},
            {10, "X"},
            {9, "IX"},
            {5, "V"},
            {4, "IV"},
            {1, "I"}
        };

            int[] values = new int[] {
            1000, 900, 500, 400,
            100, 90, 50, 40,
            10, 9, 5, 4, 1
        };

            StringBuilder result = new StringBuilder();

            foreach (int value in values)
            {
                while (num >= value)
                {
                    result.Append(romanMap[value]);
                    num -= value;
                }
            }

            return result.ToString();
        }

        public static void run()
        {
            int number = 3749;

            string romanNumeral = IntToRoman(number);

            Console.WriteLine($"Input: {number}");
            Console.WriteLine($"Output: {romanNumeral}");
        }

    }
}
