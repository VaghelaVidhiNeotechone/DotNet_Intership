using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Find_the_Index_of_the_First_Occurrence_in_a_String
    {
        public int StrStr(string haystack, string needle)
        {
            for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack.Substring(i, needle.Length) == needle)
                {
                    return i;
                }
            }

            return -1;
        }
        public static void run()
        {
            Find_the_Index_of_the_First_Occurrence_in_a_String obj = new Find_the_Index_of_the_First_Occurrence_in_a_String();
            Console.WriteLine("---- Find the Index of the First Occurrence in a String ----");
            Console.Write("Enter the main string (haystack): ");
            string haystack = Console.ReadLine();
            Console.Write("Enter the substring to find (needle): ");
            string needle = Console.ReadLine();
            int index = obj.StrStr(haystack, needle);
            if (index != -1)
                Console.WriteLine($"\nThe substring '{needle}' first occurs at index: {index}");
            else
                Console.WriteLine($"\nThe substring '{needle}' was not found in '{haystack}'.");
        }
    }
}
