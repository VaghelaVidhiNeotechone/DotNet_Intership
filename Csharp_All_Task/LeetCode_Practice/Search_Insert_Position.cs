using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Search_Insert_Position
    {
        public static int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                else if (target > nums[mid]) left = mid + 1;
                else right = mid - 1;
            }
            return left;
        }

        public static void run()
        {
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("----Search Insert Position----");
            Console.Write("Enter number to search: ");
            int target = Convert.ToInt32(Console.ReadLine());
            int position = SearchInsert(nums, target);
            Console.WriteLine($"Insert position of {target} is: {position}");
        }
    }
}