using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Longest_Valida_Parentheses
    {
        public int LongestValidParentheses_Stack(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int maxLen = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxLen = Math.Max(maxLen, i - stack.Peek());
                    }
                }
            }

            return maxLen;
        }

        public static void run()
        {
            Console.WriteLine("Enter a string containing only '(' and ')':");
            string input = Console.ReadLine();

            Longest_Valida_Parentheses solution = new Longest_Valida_Parentheses();

            //int resultDP = solution.LongestValidParentheses_DP(input);
            int resultStack = solution.LongestValidParentheses_Stack(input);

            //Console.WriteLine($"\nUsing Dynamic Programming: {resultDP}");
            Console.WriteLine($"Using Stack Approach: {resultStack}");
        }
    }
}
