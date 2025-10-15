using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_All_Task
{
    internal class Group_Anagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (string word in strs)
            {
                int[] count = new int[26];
                foreach (char c in word)
                {
                    count[c - 'a']++;
                }
                string key = string.Join("#", count);

                if (!map.ContainsKey(key))
                    map[key] = new List<string>();

                map[key].Add(word);
            }

            return map.Values.ToList<IList<string>>();
        }

 
        public static void run()
        {
            Group_Anagrams obj = new Group_Anagrams();
            Console.WriteLine("---- Group Anagrams ----");
            Console.Write("Enter words (space separated): ");

            string[] words = Console.ReadLine().Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

            var grouped = obj.GroupAnagrams(words);

            Console.WriteLine("\nAnagram Groups:");
            int groupNum = 1;
            foreach (var group in grouped)
            {
                Console.WriteLine($"Group {groupNum++}: {string.Join(", ", group)}");
            }

            Console.WriteLine("\nTotal Groups: " + grouped.Count);
        }
    }
}
