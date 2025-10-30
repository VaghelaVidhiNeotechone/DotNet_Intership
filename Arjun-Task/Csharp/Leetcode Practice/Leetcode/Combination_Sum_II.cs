using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Leetcode
{
    internal class Combination_Sum_II
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            List<IList<int>> results = new List<IList<int>>();
            Backtrack(candidates, target, 0, new List<int>(), results);
            return results;
        }

        private void Backtrack(int[] candidates, int target, int start, List<int> combination, List<IList<int>> results)
        {
            if (target == 0)
            {
                results.Add(new List<int>(combination));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1])
                    continue;

                if (candidates[i] > target)
                    break;

                combination.Add(candidates[i]);
                Backtrack(candidates, target - candidates[i], i + 1, combination, results);
                combination.RemoveAt(combination.Count - 1);
            }
        }

        public static void run()
        {
            int[] candidates = { 10, 1, 2, 7, 6, 1, 5 };
            int target = 8;

            Combination_Sum_II solution = new Combination_Sum_II();
            IList<IList<int>> result = solution.CombinationSum2(candidates, target);

            Console.WriteLine("Combinations that sum to " + target + ":");
            foreach (var combination in result)
            {
                Console.WriteLine("[" + string.Join(", ", combination) + "]");
            }
        }
    }
}
