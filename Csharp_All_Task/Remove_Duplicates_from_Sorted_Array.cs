using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Remove_Duplicates_from_Sorted_Array
    {
        public int RemoveDuplicates(int[] nums)
        {
            int[] DistinctElements = nums.Distinct().ToArray();
            for (int i = 0; i < DistinctElements.Length; i++)
            {
                nums[i] = DistinctElements[i];
            }
            return DistinctElements.Length;
        }
        public static void run()
        {
            Remove_Duplicates_from_Sorted_Array obj = new Remove_Duplicates_from_Sorted_Array();

            Console.WriteLine("---- Remove Duplicates from Sorted Array ----");
            Console.Write("Enter array elements (space separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            int dupli = obj.RemoveDuplicates(nums);
            Console.WriteLine("\nTotal Unique Elements:"+dupli);
            Console.Write("Array after removing duplicates: ");
            for (int i = 0; i < dupli; i++)
            {
                Console.Write(nums[i] + " ");
            }

        }
    }
}
