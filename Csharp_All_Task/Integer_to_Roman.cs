using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Integer_to_Roman
    {
            public string IntToRoman(int num)
            {
                string[] symbol = { "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
                int[] value =     {1000, 900,   800,    700,   600,  500, 400,  300,   200, 100,  90,    80,    70,    60,   50,  40,    30,   20,   10,   9,     8,     7,     6,   5 ,  4,     3,     2,   1 };

                var result = new StringBuilder();
                var index = 0;
                while (num != 0)
                {
                    if (num >= value[index])
                    {
                        num -= value[index];
                        result.Append(symbol[index]);
                    }
                    else
                    {
                        index++;
                    }
                }

                return result.ToString();
            }
        public static void run()
        {
            Integer_to_Roman obj = new Integer_to_Roman();
            Console.WriteLine("---- Integer_to_Roman ----");
            Console.Write("Enter any Number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            string convert = obj.IntToRoman(num);
            Console.WriteLine("Reverse Integer is : " + convert);
        }
        }
    }

