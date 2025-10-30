using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Valid_Number
    {
        public bool IsNumber(string s)
        {
            return Regex.Match(s, @"^(?:\+|\-){0,1}(?:(\d+\.\d*)|(\d*\.\d+)|(\d+))(?:E[+-]{0,1}\d+){0,1}$", RegexOptions.IgnoreCase).Success;
        }
        public static void run()
        {
            Valid_Number obj = new Valid_Number();

            string[] testStrings = {
                "123",
                "-123",
                "+123.45",
                "3.14159",
                ".5",
                "5.",
                "1e10",
                "-2.3E-4",
                "abc",
                "1.2.3",
                " ",
                "e9"
            };

            Console.WriteLine("Testing valid and invalid number strings:\n");

            foreach (string s in testStrings)
            {
                bool isValid = obj.IsNumber(s);
                Console.WriteLine($"\"{s}\" -> {(isValid ? "Valid Number " : "Invalid ")}");
            }
            Console.WriteLine("\nEnter a string to test (or press Enter to exit):");
            while (true)
            {
                Console.Write("Input: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;

                bool isValid = obj.IsNumber(input);
                Console.WriteLine(isValid ? " Valid number" : " Invalid number");
            }
        }
    }
}

