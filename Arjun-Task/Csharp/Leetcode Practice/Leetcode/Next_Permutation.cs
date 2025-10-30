using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Next_Permutation
    {
        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;

            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }

            if (i >= 0)
            {
                int j = nums.Length - 1;

                while (nums[j] <= nums[i])
                {
                    j--;
                }

                Swap(nums, i, j);
            }

            Reverse(nums, i + 1, nums.Length - 1);
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                Swap(nums, start, end);
                start++;
                end--;
            }
        }

        public static void run()
        {
            int[] nums = { 1, 2, 3 };

            Console.WriteLine("Original Array: " + string.Join(", ", nums));

            Next_Permutation sol = new Next_Permutation();
            sol.NextPermutation(nums);

            Console.WriteLine("Next Permutation: " + string.Join(", ", nums));
        }
    }
}
