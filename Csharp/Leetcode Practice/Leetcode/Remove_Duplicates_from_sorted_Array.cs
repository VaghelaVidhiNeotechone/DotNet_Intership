using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp
{
    internal class Remove_Duplicates_from_sorted_Array
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int slow = 0;

            for (int fast = 1; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[slow])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
            }

            return slow + 1;
        }

        public static void run()
        {
            Remove_Duplicates_from_sorted_Array sol = new Remove_Duplicates_from_sorted_Array();

            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            int newLength = sol.RemoveDuplicates(nums);

            Console.WriteLine("New length: " + newLength);
            Console.Write("Unique elements: ");
            for (int i = 0; i < newLength; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }

    }
}
