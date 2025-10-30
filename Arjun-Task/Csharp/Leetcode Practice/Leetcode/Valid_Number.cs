using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Valid_Number
    {
        public bool IsNumber(string s)
        {
            s = s.Trim();
            if (s.Length == 0) return false;

            bool numberSeen = false;
            bool dotSeen = false;
            bool eSeen = false;
            bool numberAfterE = true;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (char.IsDigit(c))
                {
                    numberSeen = true;
                    if (eSeen)
                        numberAfterE = true;
                }
                else if (c == '.')
                {
                    if (dotSeen || eSeen)
                        return false;
                    dotSeen = true;
                }
                else if (c == 'e' || c == 'E')
                {
                    if (eSeen || !numberSeen)
                        return false;
                    eSeen = true;
                    numberAfterE = false;
                }
                else if (c == '+' || c == '-')
                {
                    if (i != 0 && s[i - 1] != 'e' && s[i - 1] != 'E')
                        return false;
                }
                else
                {
                    return false;
                }
            }

            return numberSeen && numberAfterE;
        }

        public static void run()
        {
            var solution = new Valid_Number();

            string input = "0";
            bool result = solution.IsNumber(input);

            Console.WriteLine($"Input: \"{input}\"");
            Console.WriteLine("Is valid number? " + result);
        }
    }
}
