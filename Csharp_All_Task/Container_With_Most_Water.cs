using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Container_With_Most_Water
    {
        public int MaxArea(int[] height)
        {
            int l = 0, r = height.Length - 1, max = 0;
            while (l < r)
            {
                int area = (r - l) * Math.Min(height[l], height[r]);
                if (area > max) max = area;
                if (height[l] < height[r]) l++;
                else r--;
            }
            return max;
        }

        public static void run()
        {
            Container_With_Most_Water obj=new Container_With_Most_Water();
            Console.WriteLine("---- Container With Most Water ----");
            Console.Write("Enter heights (space separated): ");
            int[] height = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int result = obj.MaxArea(height);
            Console.WriteLine("Maximum Water Area: " + result);
        }
    }
}
