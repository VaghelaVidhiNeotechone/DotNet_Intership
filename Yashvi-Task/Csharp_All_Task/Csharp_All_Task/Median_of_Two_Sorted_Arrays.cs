using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Median_of_Two_Sorted_Arrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int numOne = 0, numTwo = 0;
            List<int> nums = new List<int>();
            int sum = nums1.Length + nums2.Length;
            for (int i = 0; i < sum; i++)
            {
                if (numOne < nums1.Length && numTwo < nums2.Length)
                {
                    if (nums1[numOne] < nums2[numTwo])
                    {
                        nums.Add(nums1[numOne]);
                        numOne++;
                    }
                    else
                    {
                        nums.Add(nums2[numTwo]);
                        numTwo++;
                    }
                }
                else if (numOne >= nums1.Length && numTwo < nums2.Length)
                {
                    nums.Add(nums2[numTwo]);
                    numTwo++;
                }
                else if (numTwo >= nums2.Length && numOne < nums1.Length)
                {
                    nums.Add(nums1[numOne]);
                    numOne++;
                }
            }
            if (sum % 2 == 0)
            {
                return (double)(nums[(sum / 2) - 1] + nums[(sum / 2)]) / 2;
            }
            return nums[sum / 2];

        }
        public static void run()
        {
            int[] nums1 = { 9, 2, 7 };
            int[] nums2 = { 1, 2 };

            Median_of_Two_Sorted_Arrays obj = new Median_of_Two_Sorted_Arrays();
            double median = obj.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine("----Median of Two Sorted Array----");
            Console.WriteLine("Median is: " + median);
        }
    }
}
