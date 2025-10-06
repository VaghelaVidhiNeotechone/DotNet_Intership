using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Three_Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int j = i + 1;
                int k = nums.Length - 1;

                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });

                        while (j < k && nums[j] == nums[j + 1]) j++;
                        while (j < k && nums[k] == nums[k - 1]) k--;

                        j++;
                        k--;
                    }
                    else if (sum < 0)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return result;
        }

        public static void run()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };

            Three_Sum solution = new Three_Sum();

            IList<IList<int>> triplets = solution.ThreeSum(nums);

            Console.WriteLine("Triplets that sum to zero:");
            foreach (var triplet in triplets)
            {
                Console.WriteLine($"[{string.Join(", ", triplet)}]");
            }
        }

    }
}
