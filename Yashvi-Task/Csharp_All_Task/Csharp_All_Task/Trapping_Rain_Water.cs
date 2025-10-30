using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Trapping_Rain_Water
    {
        public int Trap(int[] height)
        {

            int res = 0;

            int l = 0;
            int r = height.Length - 1;

            int maxL = height[l];
            int maxR = height[r];
            while (l <= r)
            {
                if (maxL < height[l]) maxL = height[l];
                if (maxR < height[r]) maxR = height[r];

                res += maxL - height[l];
                res += maxR - height[r];

                if (maxL < maxR) l++;
                if (maxR <= maxL) r--;
            }

            return res;
        }
        public static void run()
        {
            Trapping_Rain_Water obj = new Trapping_Rain_Water();
            Console.WriteLine("---- Trapping_Rain_Water ----");
            Console.WriteLine("Enter Element of Array(space Seperate):");
            int[] height = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int result = obj.Trap(height);
            Console.WriteLine("Result: " + result);
        }
    }
}
