using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ActivityNotifications
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Solve(new List<int>() { 10, 20, 30, 40, 50 }, 3));
            Console.WriteLine(Solve(new List<int>() { 1, 2, 3, 4, 4 }, 4));
            Console.ReadLine();
        }
        /// <summary>
        /// Counting sort example
        /// </summary>
        /// <param name="expenditure"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private static int Solve(List<int> expenditure, int d)
        {
            var result = 0;
            var l = expenditure.Count;
            int[] data = new int[201];
            for (var i = 0; i < d; i++)
            {
                data[expenditure[i]]++;
            }
            for (var i = d; i < l; i++)
            {
                double median = getMedian(d, data);

                if (expenditure[i] >= 2 * median)
                {
                    result++;
                }

                data[expenditure[i]]++;
                data[expenditure[i - d]]--;
            }
            return result;
        }

        private static double getMedian(int d, int[] data)
        {
            double median = 0;
            if (d % 2 == 0)
            {
                int? m1 = null;
                int? m2 = null;
                int count = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    count += data[j];
                    if (!m1.HasValue && count >= d / 2)
                    {
                        m1 = j;
                    }
                    if (!m2.HasValue && count >= d / 2 + 1)
                    {
                        m2 = j;
                        break;
                    }
                }
                median = (m1.Value + m2.Value) / 2.0;
            }
            else
            {
                int count = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    count += data[j];
                    if (count > d / 2)
                    {
                        median = j;
                        break;
                    }
                }
            }
            return median;
        }
    }
}
