using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Permutation
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            Backtrack(nums, new List<int>(), new bool[nums.Length], result);
            return result;
        }

        private void Backtrack(int[] nums, List<int> current, bool[] used, List<IList<int>> result)
        {
            if (current.Count == nums.Length)
            {

                result.Add(new List<int>(current));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;

                current.Add(nums[i]);
                used[i] = true;

                Backtrack(nums, current, used, result);

                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }

        public static void run()
        {
            var solution = new Permutation();
            int[] nums = { 1, 2, 3 };
            var permutations = solution.Permute(nums);

            foreach (var perm in permutations)
            {
                Console.WriteLine("[" + string.Join(",", perm) + "]");
            }
        }
    }

}
