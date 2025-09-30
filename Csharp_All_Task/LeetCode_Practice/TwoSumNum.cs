using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class TwoSumNum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numMap.ContainsKey(complement))
                    return new int[] { numMap[complement], i };
                numMap[nums[i]] = i;
            }
            return new int[] { };
        }

        public static void run()
        {
            int[] nums = { 5, 4, 8, 1 };
            int target = 13;

            TwoSumNum solution = new TwoSumNum();
            int[] result = solution.TwoSum(nums, target);

            Console.WriteLine("----Two Sum----");
            if (result.Length > 0)
                Console.WriteLine("Indices: " + result[0] + ", " + result[1]);
            else
                Console.WriteLine("No solution found.");
        }
    }
}