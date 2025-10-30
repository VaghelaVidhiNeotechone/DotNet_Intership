using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Longest_Palindromic_Substring
    {
        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            if (n == 0) return "";

            bool[,] dp = new bool[n, n];
            int start = 0, maxlen = 1;

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
                    maxlen = 2;
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
                        maxlen = len;
                    }
                }
            }

            return s.Substring(start, maxlen);
        }

        public static void run()
        {
            string s = "uryttyuytrtyu";
            Longest_Palindromic_Substring obj = new Longest_Palindromic_Substring();
            string palindromic = obj.LongestPalindrome(s);
            Console.WriteLine("---- Longest Palindromic Substring----");
            Console.WriteLine("Longest Palindromic Substring: " + palindromic);
        }
    }
}
