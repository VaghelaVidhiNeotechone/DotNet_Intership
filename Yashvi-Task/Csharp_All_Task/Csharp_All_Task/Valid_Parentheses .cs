using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Valid_Parentheses
    {
        public bool IsValid(string s)
        {
            while (s.Contains("()") || s.Contains("[]") || s.Contains("{}") || s.Contains("<>"))
            {
                s = s.Replace("()", "").Replace("[]", "").Replace("{}", "").Replace("<>", "");
            }
            return s.Length == 0;
        }
        public static void run()
        {
            Valid_Parentheses obj = new Valid_Parentheses();
            Console.WriteLine("---- Valid Parentheses ----");
            Console.Write("Enter any Parentheses: ");
            string s = Console.ReadLine();
            bool result=obj.IsValid(s);
            if (result)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }

    }
}
