using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class _3Sum_Closest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            int left = 1, right = 2;
            int memory = nums[0] + nums[left] + nums[right];
            for(int i=0;i<nums.Length;i++)
            {
                left = i + 1;
                right = left + 1;
                while(left<nums.Length && right < nums.Length)
                {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == target)
                    {
                        return sum;
                    }
                    if (Math.Abs(target - memory) >= Math.Abs(target - sum))
                    {
                        memory = sum;
                    }
                    right++;
                    if (right == nums.Length)
                    {
                        left++;
                        right = left + 1;
                    }
                    if(left>=nums.Length)
                    {
                        break;
                    }
                }

            }
            return memory;
        }
        public static void run()
        {
            _3Sum_Closest obj= new _3Sum_Closest();
            Console.WriteLine("---- 3Sum Closest Problem ----");
            Console.Write("Enter Numbers (space separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Enter Numbers of sum: ");
            int target = Convert.ToInt32(Console.ReadLine());
            int result = obj.ThreeSumClosest(nums,target);
            Console.WriteLine("\nClosest triplet sum to target :" + result);
        }

    }
}
