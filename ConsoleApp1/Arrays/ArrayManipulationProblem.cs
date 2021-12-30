using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class ArrayManipulationProblem
    {
        public static long Execute(int n, int[][] queries)
        {
            var arr = Enumerable.Range(0, n+2).Select(i => Convert.ToInt64(0)).ToList();

            long result = Int64.MinValue;
            
            for (int i = 0; i < queries.Length; i++)
            {
                var start = queries[i][0];
                var end = queries[i][1]+1;
                var value = queries[i][2];
                arr[start] = arr[start] + value;
                arr[end] = arr[end] - value;
            }
            long sum = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                sum += arr[i];
                result = Math.Max(result, sum);
            }

            return result;
        }
    }
}
