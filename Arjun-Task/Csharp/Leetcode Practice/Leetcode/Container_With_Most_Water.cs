using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Container_With_Most_Water
    {
        public static int MaxArea(int[] height)
        {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                int width = right - left;
                int minHeight = Math.Min(height[left], height[right]);
                int currentArea = width * minHeight;
                maxArea = Math.Max(maxArea, currentArea);

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }

        public static void run()
        {
            int[] height = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };

            //Container_With_Most_Water solution = new Container_With_Most_Water();

            int result = Container_With_Most_Water.MaxArea(height);
            Console.WriteLine("The maximum area is: " + result);
        }

    }
}
