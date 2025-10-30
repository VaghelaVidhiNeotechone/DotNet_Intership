using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Generate_Parentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var res = new List<string>();
            void Backtrack(string current, int open, int close)
            {
                if (current.Length == n * 2)
                {
                    res.Add(current);
                    return;
                }
                if (open < n) Backtrack(current + "(", open + 1, close);
                if (close < open) Backtrack(current + ")", open, close + 1);
            }
            Backtrack("", 0, 0);
            return res;
        }
        public static void run()
        {
            Generate_Parentheses obj = new Generate_Parentheses();
            Console.WriteLine("---- Generate Parentheses ----");
            Console.Write("Enter any Number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            IList<string> result =obj.GenerateParenthesis(n);
            Console.WriteLine("Result: [" + string.Join(", ", result) + "]");


        }
    }
}
