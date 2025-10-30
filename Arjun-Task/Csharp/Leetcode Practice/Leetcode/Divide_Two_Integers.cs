using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Divide_Two_Integers
    {
        public static int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Divisor cannot be zero.");
            }

            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            bool isNegative = (dividend < 0) ^ (divisor < 0);

            long ldividend = Math.Abs((long)dividend);
            long ldivisor = Math.Abs((long)divisor);

            int result = 0;

            while (ldividend >= ldivisor)
            {
                long temp = ldivisor;
                int multiple = 1;

                while (ldividend >= (temp << 1))
                {
                    temp <<= 1;
                    multiple <<= 1;
                }

                ldividend -= temp;
                result += multiple;
            }

            return isNegative ? -result : result;
        }

        public static void run()
        {
            Console.WriteLine("Enter dividend:");
            int dividend = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter divisor:");
            int divisor = int.Parse(Console.ReadLine());

            try
            {
                int result = Divide(dividend, divisor);
                Console.WriteLine($"Result of {dividend} / {divisor} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
