using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Next_Permutation
    {
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int ind = -1;
            for (int i = n - 2; i >= 0; i--)
            {
                if (nums[i] < nums[i + 1])
                {
                    ind = i;
                    break;
                }
            }
            if (ind == -1)
                Array.Reverse(nums);
            else
            {
                for (int i = n - 1; i > ind; i--)
                {
                    if (nums[i] > nums[ind])
                    {
                        int temp = nums[i];
                        nums[i] = nums[ind];
                        nums[ind] = temp;
                        break;
                    }
                }
                Array.Reverse(nums, ind + 1, n - ind - 1);
            }
        }
        public static void run()
        {
            Next_Permutation obj = new Next_Permutation();
            Console.WriteLine("---- Next Permutation ----");
            Console.Write("Enter elements of the array (space-separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            obj.NextPermutation(nums);
            Console.WriteLine("Next Permutation: " + string.Join(" ", nums));

        }
    }
}