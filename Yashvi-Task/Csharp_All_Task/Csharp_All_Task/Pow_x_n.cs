using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Pow_x_n
    {
        public double MyPow(double x, int n)
        {
            return Math.Pow(x, n);
        }
        public static void run()
        {
            Pow_x_n obj = new Pow_x_n();
            Console.WriteLine("----  Power of Number ----");
            Console.Write("Enter Number: ");
            double x =Convert.ToDouble( Console.ReadLine());
            Console.Write("Enter Power: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double result = obj.MyPow(x, n);
            Console.WriteLine("Result: " + result);
        }
    }
}
