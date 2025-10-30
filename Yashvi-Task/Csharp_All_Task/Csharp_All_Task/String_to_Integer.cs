using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class String_to_Integer
    {
         public int MyAtoi(string s)
        {
            int sign = 1, res = 0, idx = 0;

            while (idx < s.Length && s[idx] == ' ')
            {
                idx++;
            }
            if (idx < s.Length && (s[idx] == '-' || s[idx] == '+'))
            {
                if (s[idx] == '-')
                    sign = -1;
                idx++;
            }
            
            while (idx < s.Length && s[idx] >= '0' && s[idx] <= '9')
            {
                
                if (res > Int32.MaxValue / 10 ||
                        (res == Int32.MaxValue / 10 && s[idx] - '0' > 7))
                {
                    return sign == 1 ? Int32.MaxValue : Int32.MinValue;
                }
                
                res = 10 * res + (s[idx] - '0');
                idx++;
            }
            return res * sign;
        }
        public static void run()
        {

            String_to_Integer obj = new String_to_Integer();
            Console.WriteLine("---- String To Integer----");
            Console.Write("Enter any number: ");
            string s =Console.ReadLine();
            Console.WriteLine("String to Integer Number is : " + obj.MyAtoi(s));

        }
    }
        
    }
    
