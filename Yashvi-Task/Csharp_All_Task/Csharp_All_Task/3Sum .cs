using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class _3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            int n=nums.Length;
            Array.Sort(nums);
            for(int i=0; i < n - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                   continue;
                int j = i + 1, k = n - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if(sum==0)
                    {
                        list.Add(new List<int> { nums[i], nums[j], nums[k] });
                        while (j < k && nums[j] == nums[j + 1])
                        {
                            j++;
                        }
                        while (j < k && nums[k] == nums[k - 1])
                        {
                            k--;
                        }
                        j++;k--;
                    }
                    else if (sum > 0)
                    {
                        k--;
                    }
                    else if (sum < 0)
                    {
                        j++;
                    }
                }
                while(i+1<n&& nums[i] == nums[i + 1])
                {
                    i++;
                }
               
            }
            return list;
        }
        public static void run()
        {
            _3Sum obj = new _3Sum();
            Console.WriteLine("---- 3Sum Problem ----");
            Console.Write("Enter Numbers (space separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            IList<IList<int>> result = obj.ThreeSum(nums);
            Console.WriteLine("\nTriplets that sum to zero:");

            if (result.Count == 0)
            {
                Console.WriteLine("No triplets found.");
            }
            else
            {
                foreach (var triplet in result)
                {
                    Console.WriteLine($"[{string.Join(", ", triplet)}]");
                }
            }
        }
    }
}
