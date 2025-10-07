using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Valid_Parentheses
    {
        public bool IsValid(string s)
        {
            Stack<char> myStack = new Stack<char>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        myStack.Push(c);
                        break;
                    case ')':
                        if (myStack.Count == 0 || myStack.Pop() != '(')
                            return false;
                        break;

                    case '}':
                        if (myStack.Count == 0 || myStack.Pop() != '{')
                            return false;
                        break;

                    case ']':
                        if (myStack.Count == 0 || myStack.Pop() != '[')
                            return false;
                        break;
                }
            }
            return myStack.Count == 0;
        }

        public static void run()
        {
            Valid_Parentheses validator = new Valid_Parentheses();

            string input1 = "()";
            string input2 = "()[]{}";
            string input3 = "(]";
            string input4 = "([{}])";
            string input5 = "([)]";

            Console.WriteLine($"Input: {input1} => Valid: {validator.IsValid(input1)}");
            Console.WriteLine($"Input: {input2} => Valid: {validator.IsValid(input2)}");
            Console.WriteLine($"Input: {input3} => Valid: {validator.IsValid(input3)}");
            Console.WriteLine($"Input: {input4} => Valid: {validator.IsValid(input4)}");
            Console.WriteLine($"Input: {input5} => Valid: {validator.IsValid(input5)}");
        }
    }
}
