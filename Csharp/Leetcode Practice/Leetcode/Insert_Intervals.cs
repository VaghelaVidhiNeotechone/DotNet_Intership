using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Insert_Intervals
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();
            int i = 0;
            int n = intervals.Length;

            while (i < n && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }

            while (i < n && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            result.Add(newInterval);

            while (i < n)
            {
                result.Add(intervals[i]);
                i++;
            }

            return result.ToArray();
        }

        public static void run()
        {
            var solution = new Insert_Intervals();
            int[][] intervals = new int[][] {
            new int[] {1, 3},
            new int[] {6, 9}
        };
            int[] newInterval = new int[] { 2, 5 };

            int[][] result = solution.Insert(intervals, newInterval);

            Console.WriteLine("[{0}]", string.Join(", ",
                Array.ConvertAll(result, item => $"[{item[0]},{item[1]}]")));
        }
    }
}
