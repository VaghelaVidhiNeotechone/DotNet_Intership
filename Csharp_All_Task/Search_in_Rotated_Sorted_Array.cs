using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Search_in_Rotated_Sorted_Array
    {
        public int Search(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                    break;
                }
            }
            return -1;
        }
        public static void run()
        {
            Search_in_Rotated_Sorted_Array obj=new Search_in_Rotated_Sorted_Array();
            Console.WriteLine("---- Search in Rotated Sorted Array ----");
            Console.Write("Enter Element of Array (space separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.WriteLine("Number of Element");
            int target = Convert.ToInt32(Console.ReadLine());
            int result=obj.Search(nums, target);
            Console.WriteLine("Result:"+result);

        }
    }
}
