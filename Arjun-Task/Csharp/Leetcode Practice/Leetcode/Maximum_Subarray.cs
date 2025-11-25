using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Maximum_Subarray
    {
        public int MaxSubArray(int[] nums)
        {
            int maxSoFar = nums[0];
            int currentMax = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentMax = Math.Max(nums[i], currentMax + nums[i]);
                maxSoFar = Math.Max(maxSoFar, currentMax);
            }

            return maxSoFar;
        }

        public static void run()
        {

            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Maximum_Subarray solution = new Maximum_Subarray();

            int maxSum = solution.MaxSubArray(nums);

            Console.WriteLine("Maximum Subarray Sum: " + maxSum);
        }
    }
}
