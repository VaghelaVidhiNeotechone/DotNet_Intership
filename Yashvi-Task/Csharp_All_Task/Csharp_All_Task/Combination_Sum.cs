using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Combination_Sum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> res = GetNextIndexPermutations(new Stack<int>(), target, 0, 0, candidates);
            return res;
        }

        public IList<IList<int>> GetNextIndexPermutations(Stack<int> cl, int target, int sum, int index, int[] nums)
        {
            List<IList<int>> iResult = new List<IList<int>>();
            while (index < nums.Length)
            {
                if (sum + nums[index] < target)
                {
                    sum += nums[index];
                    cl.Push(nums[index]);
                    iResult.AddRange(GetNextIndexPermutations(cl, target, sum, index, nums));
                    cl.Pop();
                    sum -= nums[index];
                    index++;
                }
                else if (sum + nums[index] == target)
                {
                    cl.Push(nums[index]);
                    iResult.Add(new List<int>(cl));
                    cl.Pop();
                    break;
                }
                else
                {
                    break;
                }
            }
            return iResult;
        }
        public static void run()
        {
            Combination_Sum obj = new Combination_Sum();
            Console.WriteLine("---- Combination Sum ----");
            Console.Write("Enter numbers of candidates (space separated): ");
            int[] candidates = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Enter target sum: ");
            int target = Convert.ToInt32(Console.ReadLine());
            IList<IList<int>> result = obj.CombinationSum(candidates, target);
            Console.WriteLine("\nCombinations that sum up to target:");

            if (result.Count == 0)
            {
                Console.WriteLine("No combinations found.");
            }
            else
            {
                int count = 1;
                foreach (var combination in result)
                {
                    Console.WriteLine($"Combination {count}: [{string.Join(", ", combination)}]");
                    count++;
                }
            }

        }
    }
}
