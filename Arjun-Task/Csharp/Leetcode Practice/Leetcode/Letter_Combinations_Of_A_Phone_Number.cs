using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Letter_Combinations_Of_A_Phone_Number
    {
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();

            if (string.IsNullOrEmpty(digits))
                return result;

            Dictionary<char, string> phoneMap = new Dictionary<char, string>
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

            Backtrack(result, phoneMap, digits, 0, "");

            return result;
        }

        private void Backtrack(IList<string> result, Dictionary<char, string> phoneMap, string digits, int index, string current)
        {
            if (index == digits.Length)
            {
                result.Add(current);
                return;
            }

            char digit = digits[index];
            string letters = phoneMap[digit];

            foreach (char letter in letters)
            {
                Backtrack(result, phoneMap, digits, index + 1, current + letter);
            }
        }

        public static void run()
        {
            Console.WriteLine("Enter digits (2-9): ");
            string input = Console.ReadLine();

            Letter_Combinations_Of_A_Phone_Number solution = new Letter_Combinations_Of_A_Phone_Number();
            IList<string> combinations = solution.LetterCombinations(input);

            Console.WriteLine("Possible letter combinations:");
            foreach (var combo in combinations)
            {
                Console.WriteLine(combo);
            }
        }

    }
}
