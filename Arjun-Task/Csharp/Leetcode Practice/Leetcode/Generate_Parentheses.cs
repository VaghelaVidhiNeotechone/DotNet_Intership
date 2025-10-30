using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Leetcode
{
    internal class Generate_Parentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> result = new List<string>();
            Backtrack(result, "", 0, 0, n);
            return result;
        }

        private void Backtrack(List<string> result, string current, int open, int close, int max)
        {
            if (current.Length == max * 2)
            {
                result.Add(current);
                return;
            }

            if (open < max)
            {
                Backtrack(result, current + "(", open + 1, close, max);
            }

            if (close < open)
            {
                Backtrack(result, current + ")", open, close + 1, max);
            }
        }

        public static void run()
        {
            Console.WriteLine("Enter the value of n:");
            int n = int.Parse(Console.ReadLine());

            Generate_Parentheses solution = new Generate_Parentheses();
            IList<string> result = solution.GenerateParenthesis(n);

            Console.WriteLine("\nGenerated Parentheses:");
            foreach (string combination in result)
            {
                Console.WriteLine(combination);
            }
        }

    }
}
