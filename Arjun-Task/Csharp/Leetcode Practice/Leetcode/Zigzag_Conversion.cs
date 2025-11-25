using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Zigzag_Conversion
    {
        public static string ConvertZigzag(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= numRows)
                return s;

            string[] rows = new string[numRows];
            int row = 0;
            int step = 1;

            foreach (char c in s)
            {
                rows[row] += c;

                if (row == 0)
                    step = 1;
                else if (row == numRows - 1)
                    step = -1;

                row += step;
            }

            return string.Concat(rows);
        }

        public static void run()
        {
            string s = "PAYPALISHIRING";
            int numRows = 3;

            string result = ConvertZigzag(s, numRows);
            Console.WriteLine("Output: " + result);
        }
    }
}
