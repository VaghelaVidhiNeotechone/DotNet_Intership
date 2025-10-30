using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class LoopsMethod
    {
        public static void mySum()
        {
            int[] num = { 5, 10, 15, 20, 25 };
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }

            Console.WriteLine("Sum of array elements: " + sum);




            Console.WriteLine("Print multiplication table(1–10)");

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(i * j + "\t");
                }
                Console.WriteLine("\n");
            }

        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static long Factorial(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
                return -1;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
