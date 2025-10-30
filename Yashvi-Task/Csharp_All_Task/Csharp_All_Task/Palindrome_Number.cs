using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Palindrome_Number
    {
       
            public bool IsPalindrome(int x)
            {
                if (x < 0)
                    return false;

                int original = x;  
                int reversed = 0;

                while (x != 0)
                {
                    int remainder = x % 10;
                    reversed = reversed * 10 + remainder;
                    x /= 10;
                }
                return original == reversed;
            }

            public static void run()
            {
                Palindrome_Number obj = new Palindrome_Number();
                Console.WriteLine("---- Palindrome Number Check ----");
                Console.Write("Enter any number: ");
                int x = Convert.ToInt32(Console.ReadLine());

                bool isPal = obj.IsPalindrome(x);

                if (isPal)
                    Console.WriteLine(x+" is a Palindrome Number.");
                else
                    Console.WriteLine($"{x} is NOT a Palindrome Number.");
            }
        }
    }

