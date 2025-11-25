using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Multiply_Strings
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0") return "0";

            int[] result = new int[num1.Length + num2.Length];

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    int p1 = i + j;
                    int p2 = i + j + 1;

                    int sum = mul + result[p2];
                    result[p2] = sum % 10;
                    result[p1] += sum / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int num in result)
            {
                if (!(sb.Length == 0 && num == 0))
                {
                    sb.Append(num);
                }
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }

        public static void run()
        {
            Console.WriteLine("Enter first number:");
            string num1 = Console.ReadLine();

            Console.WriteLine("Enter second number:");
            string num2 = Console.ReadLine();

            Multiply_Strings solution = new Multiply_Strings();
            string result = solution.Multiply(num1, num2);

            Console.WriteLine($"Result: {result}");
        }
    }
}
