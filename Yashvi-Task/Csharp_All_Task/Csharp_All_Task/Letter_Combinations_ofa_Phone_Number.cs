using System;
using System.Collections.Generic;

namespace Csharp_All_Task
{
    internal class Letter_Combinations_ofa_Phone_Number
    {
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();

            if (string.IsNullOrEmpty(digits))
                return result;
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "2", "abc" },
                { "3", "def" },
                { "4", "ghi" },
                { "5", "jkl" },
                { "6", "mno" },
                { "7", "pqrs" },
                { "8", "tuv" },
                { "9", "wxyz" }
            };
            void Backtracking(int index, string current)
            {
                if (current.Length == digits.Length)
                {
                    result.Add(current);
                    return;
                }
                string chars = dict[digits[index].ToString()];
                for (int i = 0; i < chars.Length; i++)
                {
                    Backtracking(index + 1, current + chars[i]);
                }
            }
            Backtracking(0, string.Empty);

            return result;
        }

        public static void run()
        {
            Letter_Combinations_ofa_Phone_Number obj = new Letter_Combinations_ofa_Phone_Number();
            Console.Write("Enter digits (no spaces): ");
            string digits = Console.ReadLine();
            foreach (char c in digits)
            {
                if (c < '2' || c > '9')
                {
                    Console.WriteLine("\n Invalid input! Only digits 2–9 are allowed.");
                    return;
                }
            }
            IList<string> result = obj.LetterCombinations(digits);
            if (result.Count == 0)
            {
                Console.WriteLine("No possible combinations found.");
            }
            else
            {
                Console.WriteLine("Combinations:\n");
                int count = 1;
                foreach (string combination in result)
                {
                    Console.WriteLine($"{count}. {combination}");
                    count++;
                }
            }

        }
    }
}
