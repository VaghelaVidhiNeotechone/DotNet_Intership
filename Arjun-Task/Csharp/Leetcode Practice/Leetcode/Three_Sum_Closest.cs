using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Three_Sum_Closest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int closest = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (Math.Abs(target - sum) < Math.Abs(target - closest))
                    {
                        closest = sum;
                    }

                    if (sum < target)
                    {
                        left++;
                    }
                    else if (sum > target)
                    {
                        right--;
                    }
                    else
                    {
                        return target;
                    }
                }
            }

            return closest;
        }

        public static void run()
        {
            int[] nums = { -1, 2, 1, -4 };
            int target = 1;

            Three_Sum_Closest solution = new Three_Sum_Closest();
            int closestSum = solution.ThreeSumClosest(nums, target);

            Console.WriteLine($"Closest sum to target {target} is: {closestSum}");
        }

    }
}
