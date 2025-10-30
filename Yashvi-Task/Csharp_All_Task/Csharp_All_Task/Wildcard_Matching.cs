using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Wildcard_Matching
    {
        public bool IsMatch(string s, string p)
        {
            int m = s.Length;
            int n = p.Length;
            bool[,] dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 1];
                }
            }
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                    }
                    else if (p[j - 1] == '?' || p[j - 1] == s[i - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                }
            }
            return dp[m, n];
        }
        public static void run()
        {
            Wildcard_Matching obj = new Wildcard_Matching();
            Console.WriteLine("---- Wildcard_Matching ----");
            Console.Write("Enter String 1: ");
            string s = Console.ReadLine();
            Console.Write("Enter String 2: ");
            string p = Console.ReadLine();
            bool result = obj.IsMatch(s, p);
            Console.WriteLine("Matching String Is: " + result);
        }
    }
}
