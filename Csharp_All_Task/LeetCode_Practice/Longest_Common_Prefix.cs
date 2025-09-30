using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Longest_Common_Prefix
    {
        public static void run()
        {
            string[] strs = { "flower", "flow", "flight" };
            string result = CommanPrefix(strs);
            Console.WriteLine("----Longest Common Prefix----");
            Console.WriteLine(result);
        }

        public static string CommanPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";
            string prefix = strs[0];
            for (int i = 1; i < strs.Length; i++)
                while (strs[i].IndexOf(prefix) != 0)
                    prefix = prefix.Substring(0, prefix.Length - 1);
            return prefix;
        }
    }
}