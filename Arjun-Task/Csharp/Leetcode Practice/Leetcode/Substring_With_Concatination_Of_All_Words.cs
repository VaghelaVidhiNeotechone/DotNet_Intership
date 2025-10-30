using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Substring_With_Concatination_Of_All_Words
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> result = new List<int>();
            if (s == null || words == null || words.Length == 0)
                return result;

            int wordLength = words[0].Length;
            int wordCount = words.Length;
            int windowLength = wordLength * wordCount;

            if (s.Length < windowLength)
                return result;

            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordFreq.ContainsKey(word))
                    wordFreq[word]++;
                else
                    wordFreq[word] = 1;
            }

            for (int i = 0; i < wordLength; i++)
            {
                int left = i, right = i;
                Dictionary<string, int> seenWords = new Dictionary<string, int>();

                while (right + wordLength <= s.Length)
                {
                    string word = s.Substring(right, wordLength);
                    right += wordLength;

                    if (wordFreq.ContainsKey(word))
                    {
                        if (seenWords.ContainsKey(word))
                            seenWords[word]++;
                        else
                            seenWords[word] = 1;

                        while (seenWords[word] > wordFreq[word])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            seenWords[leftWord]--;
                            left += wordLength;
                        }

                        if (right - left == windowLength)
                        {
                            result.Add(left);
                        }
                    }
                    else
                    {
                        seenWords.Clear();
                        left = right;
                    }
                }
            }

            return result;
        }

        public static void run()
        {
            string s = "barfoothefoobarman";
            string[] words = { "foo", "bar" };

            Substring_With_Concatination_Of_All_Words solution = new Substring_With_Concatination_Of_All_Words();
            IList<int> result = solution.FindSubstring(s, words);

            Console.WriteLine("Output indices:");
            foreach (int index in result)
            {
                Console.WriteLine(index);
            }
        }
    }
}
