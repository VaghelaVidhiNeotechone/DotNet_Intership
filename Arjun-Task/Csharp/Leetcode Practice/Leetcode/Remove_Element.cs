using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Remove_Element
    {
        public static int RemoveElement(int[] nums, int val)
        {
            int k = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }

            return k;
        }

        public static void run()
        {
            int[] nums = { 3, 2, 2, 3 };
            int val = 3;

            Console.WriteLine("Original array: [" + string.Join(", ", nums) + "]");
            Console.WriteLine("Value to remove: " + val);

            int k = RemoveElement(nums, val);

            Console.WriteLine("k = " + k);
            Console.Write("Modified array: [");
            for (int i = 0; i < k; i++)
            {
                Console.Write(nums[i]);
                if (i < k - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
        }
    }
}
