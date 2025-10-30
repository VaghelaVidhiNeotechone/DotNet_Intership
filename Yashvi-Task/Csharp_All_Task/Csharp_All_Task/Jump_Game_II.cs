using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Jump_Game_II
    {
        public int Jump(int[] nums)
        {

            int ans = 0, currEnd = 0, currFar = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                currFar = Math.Max(currFar, i + nums[i]);

                if (i == currEnd)
                {
                    ans++;
                    currEnd = currFar;
                }
            }

            return ans;
        }
        public static void run()
        {
            Jump_Game_II obj = new Jump_Game_II();
            Console.WriteLine("---- Jump_Game_II ----");
            Console.WriteLine("Enter Element of Array(space Seperate):");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int result = obj.Jump(nums);
            Console.WriteLine("Result: " + result);
        }
    }
}
