using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Jump_Game_II
    {
        public static int Jump(int[] nums)
        {
            int jumps = 0;
            int currentEnd = 0;
            int farthest = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]);

                if (i == currentEnd)
                {
                    jumps++;
                    currentEnd = farthest;
                }
            }

            return jumps;
        }

        public static void run()
        {
            int[] nums = { 2, 3, 1, 1, 4 };

            Console.WriteLine("Input array: [" + string.Join(", ", nums) + "]");

            int result = Jump(nums);

            Console.WriteLine("Minimum number of jumps to reach the last index: " + result);
        }
    }
}
