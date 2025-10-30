using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Pow_x_n_
    {
        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;

            if (n < 0)
            {
                x = 1 / x;
                if (n == int.MinValue)
                {
                    return x * MyPow(x, -(n + 1));
                }
                n = -n;
            }

            if (n % 2 == 0)
            {
                double half = MyPow(x, n / 2);
                return half * half;
            }
            else
            {
                return x * MyPow(x, n - 1);
            }
        }

        public static void run()
        {
            Console.Write("Enter the base (x): ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the exponent (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            Pow_x_n_ sol = new Pow_x_n_();
            double result = sol.MyPow(x, n);
            Console.WriteLine("Result: " + result);
        }
    }
}
