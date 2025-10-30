using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Find_First_And_Last_Position_Of_Element_In_Sorted_Array
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int first = FindFirst(nums, target);
            int last = FindLast(nums, target);
            return new int[] { first, last };
        }

        private int FindFirst(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    result = mid;
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }

        private int FindLast(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    result = mid;
                    left = mid + 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }
        public static void run()
        {
            int[] nums = { 5, 7, 7, 8, 8, 10 };
            int target = 8;

            Find_First_And_Last_Position_Of_Element_In_Sorted_Array solution = new Find_First_And_Last_Position_Of_Element_In_Sorted_Array();
            int[] result = solution.SearchRange(nums, target);

            Console.WriteLine($"Input: nums = [{string.Join(",", nums)}], target = {target}");
            Console.WriteLine($"Output: [{result[0]}, {result[1]}]");
        }
    }
}
