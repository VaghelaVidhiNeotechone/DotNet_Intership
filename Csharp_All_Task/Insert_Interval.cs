using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Insert_Interval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var res = new List<int[]>();

            foreach (var interval in intervals)
            {
                if (interval[0] > newInterval[1])
                {
                    res.Add(newInterval);
                    newInterval = interval;
                }
                else if (interval[1] < newInterval[0])
                {
                    res.Add(interval);
                }
                else
                {
                    newInterval[0] = Math.Min(newInterval[0], interval[0]);
                    newInterval[1] = Math.Max(newInterval[1], interval[1]);
                }
            }

            res.Add(newInterval);

            return res.ToArray();
        }
        public static void run()
        {
            Insert_Interval obj = new Insert_Interval();
            Console.WriteLine("---- Insert_Interval ----");
            Console.Write("Enter number of intervals: ");
            int n = int.Parse(Console.ReadLine());
            int[][] intervals = new int[n][];
            Console.WriteLine($"Enter {n} intervals (each with start and end, space-separated):");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Interval {i + 1}: ");
                intervals[i] = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            }
            Console.WriteLine("Enter New  intervals(space Seperate):");
            int[] newInterval = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int[][] merged = obj.Insert(intervals, newInterval);
            Console.WriteLine("\nMerged Intervals:");
            foreach (var interval in merged)
            {
                Console.WriteLine($"[ {interval[0]}, {interval[1]} ]");
            }
        }
    }
}
