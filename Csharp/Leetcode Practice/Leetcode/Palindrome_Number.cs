using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Palindrome_Number
    {
        public static bool IsPalindrome(int x)
        {
            int number = x;
            int rem;
            int result = 0;
            int temp = number;

            while (number != 0)
            {
                rem = number % 10;
                result = result * 10 + rem;
                number = number / 10;
            }

            number = temp;

            if (number == result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void run()
        {
            //Palindrome_Number solution = new Palindrome_Number();

            Console.Write("Enter a number: ");
            int input = int.Parse(Console.ReadLine());

            bool isPalindrome = Palindrome_Number.IsPalindrome(input);

            if (isPalindrome)
            {
                Console.WriteLine("Palindrome Number");
            }
            else
            {
                Console.WriteLine("Not A Palindrome Number");
            }
        }

    }
}
