using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Combination_Sum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            return CombinationSum(candidates, target, 0);
        }

        private List<IList<int>> CombinationSum(int[] condidates,  int target, int i)
        {
            var res = new List<IList<int>>();
            if(target == 0)
            {
                res.Add(new List<int>());
                return res;
            }
            if(target < 0 || i == condidates.Length) return res;
            var withI = CombinationSum(condidates, target - condidates[i],i);
            foreach(var list in withI)
            {
                list.Add(condidates[i]);
            }
            var withoutI = CombinationSum(condidates, target, i + 1);
            withI.AddRange(withoutI);
            return withI;
        }

        public static void run()
        {
            var combinationSumSolver = new Combination_Sum();

            int[] candidates = { 2, 3, 6, 7 };
            int target = 7;

            var result = combinationSumSolver.CombinationSum(candidates, target);

            Console.WriteLine("Combinations that sum to " + target + ":");
            foreach (var combination in result)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }
        }
    }
}
