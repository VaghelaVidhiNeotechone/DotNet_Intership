using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Permutations
    {
        IList<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> Permute(int[] nums)
        {
            GeneratePrem(new List<int>(), nums.ToList());
            return result;

        }

        void GeneratePrem(List<int> prefix, List<int> remaining)
        {
            if (remaining.Any())
            {

                for (var i = 0; i < remaining.Count(); i++)
                {
                    var t = new int[prefix.Count()];
                    prefix.CopyTo(t);
                    var p_copy = t.ToList();
                    p_copy.Add(remaining[i]);
                    GeneratePrem(p_copy, remaining.Where(r => r != remaining[i]).ToList());
                }

            }
            else result.Add(prefix);
        }
        public static void run()
        {
            Permutations obj = new Permutations();
            Console.WriteLine("---- Permutations ----");
            Console.Write("Enter Numbers (space separated): ");

            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            IList<IList<int>> result = obj.Permute(nums);

            Console.WriteLine("\nAll Permutations:");

            int count = 1;
            foreach (var permutation in result)
            {
                Console.WriteLine($"{count++}. [ {string.Join(", ", permutation)} ]");
            }
        }
    }
}