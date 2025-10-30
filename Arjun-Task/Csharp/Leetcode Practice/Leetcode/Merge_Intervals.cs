using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Merge_Intervals
    {
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0) return new int[0][];

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> merged = new List<int[]>();

            foreach (var interval in intervals)
            {
                if (merged.Count == 0 || merged[merged.Count - 1][1] < interval[0])
                {
                    merged.Add(interval);
                }
                else
                {
                    merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], interval[1]);
                }
            }

            return merged.ToArray();
        }

        public static void run()
        {
            var solution = new Merge_Intervals();
            int[][] intervals = new int[][] {
            new int[] {1, 3},
            new int[] {2, 6},
            new int[] {8, 10},
            new int[] {15, 18}
        };

            int[][] result = solution.Merge(intervals);

            Console.WriteLine("Merged Intervals:");
            foreach (var interval in result)
            {
                Console.WriteLine($"[{interval[0]}, {interval[1]}]");
            }
        }
    }
}
