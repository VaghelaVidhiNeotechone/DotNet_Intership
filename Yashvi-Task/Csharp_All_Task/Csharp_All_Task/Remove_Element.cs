using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Remove_Element
    {
        public int RemoveElement(int[] nums, int val)
        {
            int current = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[current] = nums[i];
                    current++;
                }
            }
            return current;
        }
        public static void run()
        {
            Remove_Element obj = new Remove_Element();

            Console.WriteLine("----Remove Element ----");
            Console.Write("Enter array elements (space separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            Console.Write("Enter One Array Element:");
            int val = Convert.ToInt32(Console.ReadLine());
            int remove = obj.RemoveElement(nums,val);
            Console.WriteLine("\nTotal Unique Elements:" +remove);
            Console.Write("Array after removing duplicates: ");
            for (int i = 0; i < remove; i++)
            {
                Console.Write(nums[i] + " ");
            }

        }
    }
}
