using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Find_The_Index_Of_The_First_Occurrence_In_A_String
    {
        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;
            if (needle.Length > haystack.Length) return -1;

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int j = 0;
                while (j < needle.Length && haystack[i + j] == needle[j])
                {
                    j++;
                }
                if (j == needle.Length)
                {
                    return i;
                }
            }

            return -1;
        }

        public static void run()
        {
            string haystack = "sadbutsad";
            string needle = "sad";

            int index = StrStr(haystack, needle);

            Console.WriteLine("First occurrence of \"{0}\" in \"{1}\" is at index: {2}", needle, haystack, index);
        }
    }
}
