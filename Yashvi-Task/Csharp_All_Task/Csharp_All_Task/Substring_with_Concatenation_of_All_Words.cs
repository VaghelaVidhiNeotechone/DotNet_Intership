using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Substring_with_Concatenation_of_All_Words
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            int n = s.Length, right = 0, left = 0;
            int wLen = words[0].Length;
            int sumLen = string.Join("", words).Length;
            IList<int> res = new List<int>();
            var checkWords = words.ToList();
            while (right <= n - wLen)
            {
                string currWord = s.Substring(right, wLen);
                if (checkWords.Contains(currWord))
                {
                    checkWords.Remove(currWord);
                    right += wLen;
                    if (checkWords.Count == 0)
                    {
                        res.Add(right - sumLen);
                        checkWords = words.ToList();
                        left++;
                        right = left;
                    }
                }
                else
                {
                    checkWords = words.ToList();
                    left++;
                    right = left;
                }

            }
            return res;
        }
        public static void run()
        {
            Substring_with_Concatenation_of_All_Words obj = new Substring_with_Concatenation_of_All_Words();
            Console.WriteLine("---- Substring with Concatenation of All Words ----");
            Console.Write("Enter main string: ");
            string s = Console.ReadLine();
            Console.Write("Enter words (space-separated): ");
            string[] words = Console.ReadLine().Split();
            IList<int> result = obj.FindSubstring(s, words);
            if (result.Count > 0)
            {
                Console.WriteLine("Starting indices of substrings:");
                Console.WriteLine(string.Join(", ", result));
            }
            else
            {
                Console.WriteLine("No concatenation substring found.");
            }

        }
    }
}


