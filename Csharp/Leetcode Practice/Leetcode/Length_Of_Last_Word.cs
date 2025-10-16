using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Length_Of_Last_Word
    {
        public static int LengthOfLastWord(string s)
        {
            s = s.Trim();

            string[] words = s.Split(' ');

            string lastWord = words[words.Length - 1];

            return lastWord.Length;
        }

        public static void run()
        {
            string s = "Hello World";
            int length = LengthOfLastWord(s);
            Console.WriteLine("Length of last word : " + length);
        }
    }
}
