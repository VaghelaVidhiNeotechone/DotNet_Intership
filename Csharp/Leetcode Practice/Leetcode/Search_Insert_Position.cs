using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal class Search_Insert_Position
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return left;
        }

        public static void run()
        {
            Search_Insert_Position sol = new Search_Insert_Position();

            int[] nums = { 1, 3, 5, 6 };
            int target = 6;

            int result = sol.SearchInsert(nums, target);

            Console.WriteLine("");
            Console.WriteLine("Output: " + result);
        }

    }
}
