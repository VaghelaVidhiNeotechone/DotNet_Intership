using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal class Two_Sum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dict.ContainsKey(diff))
                    return new int[] { i, dict[diff] };
                dict[nums[i]] = i;
            }
            return null;
        }

        public static void run()
        {

            Two_Sum solution = new Two_Sum();
            int[] a = { 2, 11, 7, 3, 6 };
            int target = 17;

            int[] result = solution.TwoSum(a, target);
            if (result != null && result.Length > 0)
            {
                Console.WriteLine("Output: " + result[0] + ", " + result[1]);
            }
            else
            {
                Console.WriteLine("No solution found.");
            }

        }
    }
}
