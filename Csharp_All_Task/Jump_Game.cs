using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Jump_Game
    {
        public bool CanJump(int[] nums)
        {
            int finishIndex = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= finishIndex)
                {
                    if (i == 0) return true;
                    finishIndex = i;
                }
            }
            return false;
        }
        public static void run()
        {
            Jump_Game obj = new Jump_Game();
            Console.WriteLine("---- Jump_Game ----");
            Console.WriteLine("Enter Element of Array(space Seperate):");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            bool result = obj.CanJump(nums);
            Console.WriteLine("Result: " + result);
        }
    }
}
