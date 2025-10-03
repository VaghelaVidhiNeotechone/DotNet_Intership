using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class String_To_Integer
    {
        public static int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int i = 0, sign = 1, result = 0;
            int n = s.Length;

            while (i < n && s[i] == ' ')
            {
                i++;
            }

            if (i < n && (s[i] == '+' || s[i] == '-'))
            {
                sign = s[i] == '-' ? -1 : 1;
                i++;
            }

            while (i < n && char.IsDigit(s[i]))
            {
                int digit = s[i] - '0';

                if (result > (Int32.MaxValue - digit) / 10)
                {
                    return sign == 1 ? Int32.MaxValue : Int32.MinValue;
                }

                result = result * 10 + digit;
                i++;
            }

            return result * sign;
        }

        public static void run()
        {
            //String_To_Integer sol = new String_To_Integer();

            Console.WriteLine(String_To_Integer.MyAtoi("42"));
            Console.WriteLine(String_To_Integer.MyAtoi("   -42"));  
            Console.WriteLine(String_To_Integer.MyAtoi("4193 with words"));
            Console.WriteLine(String_To_Integer.MyAtoi("words and 987"));
            Console.WriteLine(String_To_Integer.MyAtoi("-91283472332"));
        }
    }
}
