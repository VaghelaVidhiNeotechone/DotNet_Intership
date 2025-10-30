using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Maximum_Subarray_sum
    {
        public int MaxSubArray(int[] nums)
        {
            int maxCurrent = nums[0];
            int maxSubArr = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (maxSubArr + nums[i] > nums[i]) { maxSubArr = maxSubArr + nums[i]; }
                else { maxSubArr = nums[i]; }

                if (maxSubArr > maxCurrent) { maxCurrent = maxSubArr; }
            }
            return maxCurrent;
        }
        public static void run()
        {
            Maximum_Subarray_sum obj = new Maximum_Subarray_sum();
            Console.WriteLine("----  Maximum_Subarray_sum ----");
            Console.Write("Enter Element of Array(space seperated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            int result = obj.MaxSubArray(nums);
            Console.WriteLine("Result: " + result);
        }
    }
}
