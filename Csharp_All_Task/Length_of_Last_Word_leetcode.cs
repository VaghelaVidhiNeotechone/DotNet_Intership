using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Length_of_Last_Word_leetcode
    {
        public int LengthOfLastWord(string s)
        {
            s = s.Trim();
            string last = s.Substring(s.LastIndexOf(' ') + 1);
            int n = last.Length;
            return n;
        }
        public static void run()
        {
            Length_of_Last_Word_leetcode obj=new Length_of_Last_Word_leetcode();
            Console.WriteLine("---- Length_of_Last_Word_leetcode ----");
            Console.WriteLine("Enter any String");
            string s=Console.ReadLine();
            int result=obj.LengthOfLastWord(s);
            Console.WriteLine("Lenght:" + result);
        }
    }
}
