using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Zigzag_Conversion
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            var output = new StringBuilder(s.Length);

            var period = numRows * 2 - 2;

            for (int row = 0; row < numRows; ++row)
            {
                var increment = 2 * row;

                for (int i = row; i < s.Length; i += increment)
                {
                    output.Append(s[i]);

                    if (increment != period)
                    {
                        increment = period - increment;
                    }
                }
            }

            return output.ToString();
        }
        public static void run()
        {
            string s = "PAYPALISHIRING";
            int numRows = 2;
            Zigzag_Conversion obj = new Zigzag_Conversion();
            string zigzag = obj.Convert(s,numRows);
            Console.WriteLine("----Zigzag Conversion----");
            Console.WriteLine(zigzag);

        }
    }
    }
    