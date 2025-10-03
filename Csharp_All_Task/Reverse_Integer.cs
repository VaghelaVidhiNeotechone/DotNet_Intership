using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Reverse_Integer
    {
        public int Reverse(int x)
        {
            var result = 0;

            while (x != 0)
            {
                var remainder = x % 10;
                var temp = result * 10 + remainder;

                // in case of overflow, the current value will not be equal to the previous one
                if ((temp - remainder) / 10 != result)
                {
                    return 0;
                }

                result = temp;
                x /= 10;
            }

            return result;

        }
        public static void run()
        {
            Reverse_Integer obj = new Reverse_Integer();
            Console.WriteLine("---- Reverse Integer----");
            Console.Write("Enter any number to reverse: ");
            int x = Convert.ToInt32(Console.ReadLine());
            int reverse = obj.Reverse(x);
            Console.WriteLine("Reverse Integer is : " + reverse);

          

        }
    }
}
