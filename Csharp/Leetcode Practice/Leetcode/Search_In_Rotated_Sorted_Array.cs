using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Search_In_Rotated_Sorted_Array
    {
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            return -1; 
        }

        public static void run()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            int target = 0;

            Search_In_Rotated_Sorted_Array solution = new Search_In_Rotated_Sorted_Array();
            int result = solution.Search(nums, target);

            Console.WriteLine("Index of target {0}: {1}", target, result);
        }
    }
}
