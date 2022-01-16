using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class MergeIntervals
    {
        static void Main(string[] args)
        {
            var result = Merge(new int[][] { new int[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } });//[[1,6],[8,10],[15,18]]
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, delegate (int[] m, int[] n)
            { return m[0] - n[0]; });

            var merged = new List<int[]>();

            foreach (var interval in intervals)
            {
                var start = interval[0];
                var end = interval[1];

                // if the list of merged intervals is empty or if the current
                // interval does not overlap with the previous, simply append it.
                if (merged.Count == 0 || merged.Last()[1] < start)
                {
                    merged.Add(interval);
                }
                // otherwise, there is overlap, so we merge the current and previous
                // intervals.
                else
                {
                    merged.Last()[1] = Math.Max(merged.Last()[1], end);
                }

            }
            return merged.ToArray();
        }
    }
}
