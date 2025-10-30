using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Count_and_Say
    {
        public string CountAndSay(int n)
        {

            string prev = "1";
            for (int i = 1; i < n; i++)
            {
                prev = sequence(prev);
            }
            return prev;
        }
        string sequence(string s)
        {
            string ans = "";
            for (int i = 0; i < s.Length; i++)
            {
                int count = 1;
                while (i < s.Length - 1 && s[i] == s[i + 1])
                {
                    count++;
                    i++;
                }
                ans = ans + count + s[i];
            }
            return ans;
        }
        public static void run()
        {
            Count_and_Say obj = new Count_and_Say();
            Console.WriteLine("---- Count_and_Say ----");
            Console.Write("Enter any number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            string result = obj.CountAndSay(n);
            Console.WriteLine("Result: " + result);
        }
    }

}
