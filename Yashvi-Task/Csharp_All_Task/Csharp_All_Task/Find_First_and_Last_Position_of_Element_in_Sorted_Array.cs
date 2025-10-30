using System;
using System.Collections.Generic;
using System.Linq;

namespace Csharp_All_Task
{
    internal class Find_First_and_Last_Position_of_Element_in_Sorted_Array
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int first = -1, last = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    first = i;
                    break;
                }
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == target)
                {
                    last = i;
                    break;
                }
            }

            return new int[] { first, last };
        }

        public static void run()
        {
            Find_First_and_Last_Position_of_Element_in_Sorted_Array obj = new Find_First_and_Last_Position_of_Element_in_Sorted_Array();
            Console.WriteLine("---- Find First and Last Position of Element in Sorted Array ----");
            Console.Write("Enter elements of array (space separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Enter target number: ");
            int target = Convert.ToInt32(Console.ReadLine());
            int[] result = obj.SearchRange(nums, target);
            Console.WriteLine("[ " + result[0] + " , " + result[1]+" ]");
        }
    }
}
