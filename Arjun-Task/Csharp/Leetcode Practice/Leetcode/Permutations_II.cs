using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Permutations_II
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var results = new List<IList<int>>();
            Array.Sort(nums);
            var used = new bool[nums.Length];
            Backtrack(nums, new List<int>(), used, results);
            return results;
        }

        private void Backtrack(int[] nums, List<int> path, bool[] used, List<IList<int>> results)
        {
            if (path.Count == nums.Length)
            {
                results.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;

                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                    continue;

                used[i] = true;
                path.Add(nums[i]);

                Backtrack(nums, path, used, results);

                used[i] = false;
                path.RemoveAt(path.Count - 1);
            }
        }

        public static void run()
        {

            int[] nums = { 1, 1, 2 };

            Permutations_II solution = new Permutations_II();
            IList<IList<int>> result = solution.PermuteUnique(nums);

            Console.WriteLine("Unique permutations:");
            foreach (var permutation in result)
            {
                Console.WriteLine($"[{string.Join(", ", permutation)}]");
            }
        }
    }
}
