using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Merge_Intervals
    {
        public int[][] Merge(int[][] intervals)
        {

            if (intervals.Length <= 1) { return intervals; }

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> result = new List<int[]>();

            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                int[] interval = intervals[i];

                if (result.Last()[1] < interval[0])
                {
                    result.Add(interval);
                }
                else
                { 
                    result.Last()[1] = Math.Max(result.Last()[1], interval[1]);
                }
            }

            return result.ToArray();
        }

        public static void run()
        {
            Merge_Intervals obj = new Merge_Intervals();
            Console.WriteLine("---- Merge Intervals ----");

            Console.Write("Enter number of intervals: ");
            int n = int.Parse(Console.ReadLine());

            int[][] intervals = new int[n][];
            Console.WriteLine($"Enter {n} intervals (each with start and end, space-separated):");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Interval {i + 1}: ");
                intervals[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            }

            int[][] merged = obj.Merge(intervals);

            Console.WriteLine("\nMerged Intervals:");
            foreach (var interval in merged)
            {
                Console.WriteLine($"[ {interval[0]}, {interval[1]} ]");
            }
        }

    }
}
