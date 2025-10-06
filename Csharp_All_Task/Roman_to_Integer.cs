using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Roman_to_Integer
    {
        public int RomanToInt(string s)
        {
            var map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);
            int sum = 0;
            int last = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int current = map[s[i]];
                if (current < last)
                {
                    sum -= current;
                }
                else
                {
                    sum += current;
                }

                last = current;
            }
            return sum;
        }
        public static void run()
        {
            Roman_to_Integer obj = new Roman_to_Integer();
            Console.WriteLine("---- Roman_to_Integer ----");
            Console.Write("Enter any Roman Number: ");
            string s = Console.ReadLine();
            int convert = obj.RomanToInt(s);
            Console.WriteLine("Reverse Integer is : " + convert);
        }
    }
}
