using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Longest_Common_Prefix
    {
        public string LongestCommonPrefixFunc(string[] strs)
        {
            string res = "";
            int chIndex = 0;

            foreach (char ch in strs[0].ToCharArray())
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    if (chIndex >= strs[i].Length || ch != strs[i][chIndex])
                    {
                        return res;
                    }
                }
                res += ch;
                chIndex++;
            }

            return res;
        }

        public static void run()
        {
            string[] input = { "flower", "flow", "flight" };

            Longest_Common_Prefix lcp = new Longest_Common_Prefix();
            string result = lcp.LongestCommonPrefixFunc(input);

            Console.WriteLine("Longest Common Prefix: " + result);
        }

    }
}
