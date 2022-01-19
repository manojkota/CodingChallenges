using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class KClosestPointsToOrigin
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Kclo)
        }

        static int[][] KClosest(int[][] points, int k)
        {
            SortedDictionary<double, List<(int, int)>> dict = new SortedDictionary<double, List<(int, int)>>();
            var x1 = 0;
            var y1 = 0;
            foreach (var point in points)
            {
                var x2 = point[0];
                var y2 = point[1];
                var dist = Math.Sqrt((double)(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
                if (dict.ContainsKey(dist))
                {
                    dict[dist].Add((x2, y2));
                }
                else
                {
                    dict.Add(dist, new List<(int, int)> { (x2, y2) });
                }
            }

            var result = new int[k][];
            var j = 0;
            foreach (var item in dict)
            {
                foreach (var l in item.Value)
                {
                    result[j] = new int[2] { l.Item1, l.Item2 };
                    j++;
                    if (j == k)
                    {
                        break;
                    }
                }
                if (j == k)
                {
                    break;
                }
            }
            return result;
        }

        static int[][] Solve(int[][] points, int k)
        {
            // Sort the array with a custom lambda comparator function
            Array.Sort(points, delegate (int[] a, int[] b) { return squaredDistance(a) - squaredDistance(b); });

            // Return the first k elements of the sorted array
            return points.Take(k).ToArray();
        }

        static int squaredDistance(int[] point)
        {
            // Calculate and return the squared Euclidean distance
            return point[0] * point[0] + point[1] * point[1];
        }
    }
}
