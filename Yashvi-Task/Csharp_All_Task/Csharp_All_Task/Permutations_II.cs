using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Permutations_II
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            Array.Sort(nums);
            Backtrack(nums, new bool[nums.Length], new List<int>(), ans);
            return ans;
        }

        private void Backtrack(int[] nums, bool[] taken, IList<int> li, IList<IList<int>> ans)
        {
            if (li.Count == nums.Length)
            {
                ans.Add(new List<int>(li));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!taken[i] && (i == 0 || taken[i - 1] || nums[i] != nums[i - 1]))
                {
                    taken[i] = true;
                    li.Add(nums[i]);
                    Backtrack(nums, taken, li, ans);
                    taken[i] = false;
                    li.RemoveAt(li.Count - 1);
                }
            }
        }
        public static void run()
        {
            Permutations_II obj = new Permutations_II();
            Console.WriteLine("---- Permutations_II ----");
            Console.Write("Enter Numbers (space separated): ");

            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            IList<IList<int>> result = obj.PermuteUnique(nums);

            Console.WriteLine("\nAll Permutations:");

            int count = 1;
            foreach (var permutation in result)
            {
                Console.WriteLine($"{count++}. [ {string.Join(", ", permutation)} ]");
            }
        }
    }
}
