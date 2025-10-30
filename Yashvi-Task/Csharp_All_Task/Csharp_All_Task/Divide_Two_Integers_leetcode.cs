using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Divide_Two_Integers_leetcode
    {
        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                Console.WriteLine("\n Error: Division by zero is not allowed.");
                return double.NaN; 
            }
            double result = dividend / divisor;
            return result;
        }
        public static void run()
        {
            Divide_Two_Integers_leetcode obj = new Divide_Two_Integers_leetcode();
            Console.WriteLine("---- Divide Two Numbers ----");
            Console.Write("Enter the dividend: ");
            double dividend = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the divisor: ");
            double divisor = Convert.ToInt32(Console.ReadLine());
            double result = obj.Divide(dividend, divisor);
            Console.WriteLine("Result: "+result);
        }
    }
}
