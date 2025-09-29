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
            int left = 0, right = nums.Length - 1, mid;

            while (left <= right)
            {
                mid = (left + right) / 2;

                if (nums[mid] == target) 
                    return mid;
                else if (target > nums[mid]) 
                    left = mid + 1;
                else 
                    right = mid - 1;
            }

            return left;
        }
        public static void run()
        {
            Console.WriteLine("----Search Insert Position----");
            int[] nums = { 1, 3, 5, 6 };
            Console.Write("Enter any number to search:");
            int target= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert position of " +target+" is:"+SearchInsert(nums,target));


        }
    }
}
