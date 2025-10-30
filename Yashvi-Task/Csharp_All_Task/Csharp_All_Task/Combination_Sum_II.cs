using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Combination_Sum_II
    {
        IList<IList<int>> ans = new List<IList<int>>();
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            CombinationSum2Until(candidates, target, 0, 0, new List<int>());
            return ans;
        }

        private void CombinationSum2Until(int[] candidates, int target, int idx, int sum, List<int> list)
        {
            if (sum == target)
            {
                ans.Add(list.ToList());
                return;
            }

            if (sum > target || idx == candidates.Length)
                return;

            for (int i = idx; i < candidates.Length; i++)
            {
                if (i > idx && candidates[i] == candidates[i - 1])
                    continue;

                list.Add(candidates[i]);
                CombinationSum2Until(candidates, target, i + 1, sum + candidates[i], list);
                list.RemoveAt(list.Count - 1);
            }
        }
        public static void run()
        {
            Combination_Sum_II obj = new Combination_Sum_II();
            Console.WriteLine("---- Combination Sum II ----");
            Console.Write("Enter numbers of candidates (space separated): ");
            int[] candidates = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Enter target sum: ");
            int target = Convert.ToInt32(Console.ReadLine());
            IList<IList<int>> result = obj.CombinationSum2(candidates, target);
            Console.WriteLine("\nCombinations that sum up to target:");
            if (result.Count == 0)
            {
                Console.WriteLine("No combinations found.");
            }
            else
            {
                int count = 1;
                foreach (var combination in result)
                {
                    Console.WriteLine($"Combination {count}: [{string.Join(", ", combination)}]");
                    count++;
                }
            }
        }
    }
}
