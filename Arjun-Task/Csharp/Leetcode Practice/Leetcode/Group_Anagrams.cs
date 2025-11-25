using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Group_Anagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var groups = new Dictionary<string, IList<string>>();
            int[] chars;

            foreach (var str in strs)
            {
                chars = new int[26];
                foreach (char c in str)
                {
                    chars[c - 'a']++;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    while (chars[i]-- > 0)
                    {
                        sb.Append((char)(i+'a'));
                    }
                }
                string s = sb.ToString();
                if(groups.ContainsKey(s))
                    groups[s].Add(str);
                else 
                    groups.Add(s, new List<string>{str});
            }
            return groups.Values.ToList();
        }

        public static void run()
        {
            string[] input = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            Group_Anagrams anagramGrouper = new Group_Anagrams();
            IList<IList<string>> grouped = anagramGrouper.GroupAnagrams(input);

            Console.WriteLine("Grouped Anagrams:");
            foreach (var group in grouped)
            {
                Console.WriteLine("[" + string.Join(", ", group) + "]");
            }
        }
    }
}
