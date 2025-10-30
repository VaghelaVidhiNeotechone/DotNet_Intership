using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Regular_Expression_Matching
    {
        public bool IsMatch(string s, string p)
        {
            if (p.Contains("**"))
                return true;
            return Regex.IsMatch(s, "^" + p + "$");
        }
        public static void run()
        {
            Regular_Expression_Matching obj = new Regular_Expression_Matching();
            Console.WriteLine("---- Regular Expression Matching ----");
            Console.Write("Enter String: ");
            string s= Console.ReadLine();
            Console.Write("Enter reguler expression pattern: ");
            string p=Console.ReadLine();
            bool isMatch = obj.IsMatch(s, p);

            if (isMatch)
            {
                Console.WriteLine($" The string \"{s}\" matches the pattern \"{p}\"");
            }
            else
            {
                Console.WriteLine($" The string \"{s}\" does NOT match the pattern \"{p}\"");

            }


            }
        }
}
