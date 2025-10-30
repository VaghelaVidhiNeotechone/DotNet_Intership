using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class First_Missing_Positive
    {
        public int FirstMissingPositive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();

            foreach (int num in nums)
            {
                if (num > 0)
                {
                    set.Add(num);
                }
            }

            for (int i = 1; i <= nums.Length + 1; i++)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }

            return -1;
        }

        public static void run()
        {
            int[] nums = { 1, 2, 0 };

            First_Missing_Positive solution = new First_Missing_Positive();
            int result = solution.FirstMissingPositive(nums);

            Console.WriteLine("First missing positive number is: " + result);
        }
    }
}
