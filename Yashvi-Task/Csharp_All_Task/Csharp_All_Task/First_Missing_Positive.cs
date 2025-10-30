using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class First_Missing_Positive
    {
        public int FirstMissingPositive(int[] nums)
        {
            var v = nums.Distinct().ToArray(); 
            Array.Sort(v);  
            int x = 1, y = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] <= 0) continue;  
                                         
                else if (v[i] == x)
                    x++;
                else break;
            }
            return x;
        }
        public static void run()
        {
            First_Missing_Positive obj = new First_Missing_Positive();
            Console.WriteLine("---- First_Missing_Positive ----");
            Console.WriteLine("Enter Element of Array(space Seperate):");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int result=obj.FirstMissingPositive(nums);
            Console.WriteLine("Result: "+result);
        }
    }
}
