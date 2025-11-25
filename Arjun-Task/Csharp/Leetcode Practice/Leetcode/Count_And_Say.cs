using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Count_And_Say
    {
        public static string CountAndSay(int n)
        {
            if (n <= 0) return "";

            string result = "1";

            for (int i = 1; i < n; i++)
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                for (int j = 1; j < result.Length; j++)
                {
                    if (result[j] == result[j - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(result[j - 1]);
                        count = 1;
                    }
                }

                sb.Append(count);
                sb.Append(result[result.Length - 1]);

                result = sb.ToString();
            }

            return result;
        }

        public static void run()
        {
            Console.Write("Enter the value of n: ");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                string result = CountAndSay(n);
                Console.WriteLine($"countAndSay({n}) = \"{result}\"");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
