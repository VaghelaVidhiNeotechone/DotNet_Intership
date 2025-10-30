using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Longest_Palindromic_Substring
    {
        public static string LongestPalindrome(string s)
        {
            int n = s.Length;
            if (n == 0) return "";

            bool[,] dp = new bool[n, n];
            int start = 0, maxLength = 1;

            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            for (int len = 3; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1;

                    if (s[i] == s[j] && dp[i + 1, j - 1])
                    {
                        dp[i, j] = true;
                        start = i;
                        maxLength = len;
                    }
                }
            }

            return s.Substring(start, maxLength);
        }

        public static void run()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            //string s = "cbbd";



            //Longest_Palindromic_Substring solution = new Longest_Palindromic_Substring();
            //string result = solution.LongestPalindrome(input);

            string result = Longest_Palindromic_Substring.LongestPalindrome(input);

            //string result = Longest_Palindromic_Substring.LongestPalindrome(s);



            Console.WriteLine($"Longest Palindromic Substring: {result}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
