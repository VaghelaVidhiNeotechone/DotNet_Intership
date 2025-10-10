using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Longest_Valid_Parentheses
    {
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int maxLength = 0;

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
                        maxLength = Math.Max(maxLength, i - stack.Peek());
                    }
                }
            }

            return maxLength;
        }
        public static void run()
        {
            Longest_Valid_Parentheses obj= new Longest_Valid_Parentheses();
            Console.WriteLine("---- Longest Valid Parentheses ----");
            Console.Write("Enter any String: ");
            string s = Console.ReadLine();
            int result = obj.LongestValidParentheses(s);
            Console.WriteLine(result);
        }
    }
}
