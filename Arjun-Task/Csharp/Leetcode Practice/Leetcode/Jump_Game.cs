using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Jump_Game
    {
        public bool CanJump(int[] nums)
        {
            int maxReach = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > maxReach)
                {
                    return false;
                }
                maxReach = Math.Max(maxReach, i + nums[i]);
            }
            return true;
        }

        public static void run()
        {
            Jump_Game solution = new Jump_Game();

            int[] nums = { 2, 3, 1, 1, 4 };

            bool result = solution.CanJump(nums);

            Console.WriteLine("Can jump to the last index: " + result);
        }
    }
}
