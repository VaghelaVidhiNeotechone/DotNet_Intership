using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Trapping_Rain_Water
    {
        public int Trap(int[] height)
        {
            int n = height.Length;
            if (n == 0) return 0;

            int[] leftMax = new int[n];
            int[] rightMax = new int[n];
            int water = 0;

            leftMax[0] = height[0];
            for (int i = 1; i < n; i++)
                leftMax[i] = Math.Max(height[i], leftMax[i - 1]);

            rightMax[n - 1] = height[n - 1];
            for (int i = n - 2; i >= 0; i--)
                rightMax[i] = Math.Max(height[i], rightMax[i + 1]);

            for (int i = 0; i < n; i++)
                water += Math.Min(leftMax[i], rightMax[i]) - height[i];

            return water;
        }

        public static void run()
        {
            int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

            Trapping_Rain_Water solution = new Trapping_Rain_Water();
            int trappedWater = solution.Trap(height);

            Console.WriteLine("Amount of trapped water: " + trappedWater);
        }
    }
}
