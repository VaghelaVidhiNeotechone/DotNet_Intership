using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Loops_Method
    {

        public static void run()
        {
            int i = 0;
            while (i < 5)
            {
                if (i == 2)
                {
                    i++;
                    continue;
                }
                Console.WriteLine(i);
                i++;
            }
            string[] cars = { "Volvo", "BMW", "Ford" };
            foreach (string j in cars)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("----Multiplication Table----");
            for (int k = 1; k <= 10; k++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(k * j + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("----Array with Loop----");
            int[] numbers = { 2, 4, 6, 8, 10 };
            int sum = 0;

            foreach (int num in numbers)
            {
                sum += num;
            }
            Console.WriteLine("Sum = " + sum);

            Console.WriteLine("----Calculate Fasctorial----");
            Console.Write("Enter a number: ");
            int nov = int.Parse(Console.ReadLine());
            Console.WriteLine("Factorial of " + nov + " = " + Loops_Method.Factorial(nov));

            Console.WriteLine("----Overload Method----");
            int num1 = Loops_Method.Add(3, 5);
            double num2 = Loops_Method.Add(3.34, 5.23);
            Console.WriteLine("Add(int): " + num1);
            Console.WriteLine("Add(double): " + num2);

        }
        public static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }


    }
}
