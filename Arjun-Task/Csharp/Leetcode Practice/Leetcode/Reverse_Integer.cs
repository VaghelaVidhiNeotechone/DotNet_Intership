using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Reverse_Integer
    {
        public static int ReverseInteger(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int digit = x % 10;
                x /= 10;

                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7))
                {
                    return 0;
                }

                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8))
                {
                    return 0;
                }

                result = result * 10 + digit;
            }

            return result;
        }

        public static void run()
        {
            Console.Write("Enter an integer to reverse: ");
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                int reversed = ReverseInteger(input);
                Console.WriteLine($"Reversed Integer: {reversed}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
