using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class _4Sum
    {
        
         public IList<IList<int>> FourSum(int[] nums, int target)
        {

            Array.Sort(nums);
            var result = new List<IList<int>>();
            int n = nums.Length;

            for (int i = 0; i < n - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                for (int j = i + 1; j < n - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                    int left = j + 1;
                    int right = n - 1;
                    long targetSum = (long)target - nums[i] - nums[j];

                    while (left < right)
                    {
                        long sum = (long)nums[left] + nums[right];
                        if (sum == targetSum)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            left++;
                            right--;
                        }
                        else if (sum < targetSum) left++;
                        else right--;
                    }
                }
            }

            return result;
        }
        
        
        public static void run()
        {
            _4Sum obj = new _4Sum();
            Console.WriteLine("---- 4Sum  ----");
            Console.Write("Enter Numbers (space separated): ");
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Enter Numbers of sum: ");
            int target = Convert.ToInt32(Console.ReadLine());
            IList<IList<int>> result = obj.FourSum(nums, target);
            Console.WriteLine("\nFour Sum Array List :" );

            if (result.Count == 0)
            {
                Console.WriteLine("No Four Sum found.");
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
