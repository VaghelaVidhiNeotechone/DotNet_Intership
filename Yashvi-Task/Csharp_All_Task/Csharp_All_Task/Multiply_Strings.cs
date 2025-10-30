using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Multiply_Strings
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }

            int l1 = num1.Length;
            int l2 = num2.Length;
            int[] result = new int[l1 + l2];
            for (int i = l1 - 1; i >= 0; i--)
            {
                for (int j = l2 - 1; j >= 0; j--)
                {
                    int d1 = num1[i] - '0';
                    int d2 = num2[j] - '0';
                    int p = d1 * d2;
                    int sum = result[i + j + 1] + p;
                    result[i + j + 1] = sum % 10;
                    result[i + j] += sum / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0 && result[i] == 0)
                {
                    continue;
                }

                sb.Append(result[i]);
            }

            return sb.ToString();
        }
        public static void run()
        {
            Multiply_Strings obj = new Multiply_Strings();
            Console.WriteLine("---- Multiply_Strings ----");
            Console.Write("Enter number 1: ");
            string num1 = Console.ReadLine();
            Console.Write("Enter number 2: ");
            string num2 = Console.ReadLine();
            string result=obj.Multiply(num1, num2);
            Console.WriteLine("Multiply String Ans " + result);
        }
    }
}
