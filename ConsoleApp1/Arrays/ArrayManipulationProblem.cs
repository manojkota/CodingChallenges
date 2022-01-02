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
                //We are looking for the max value performed after the queries are done.
                //The subtraction of the value at end_index + 1 represents the first value that the current queries value was not added to.
                //This allows us to simply add up all the values in the array, and have the correct value at every given index at the end.
                //So, if my query was 1  2 1 that would create the array 1 1 0, but to make that process faster for the sake of finding the max,
                //I can represent the same information as 1 0 -1 where each index value is the sum up to that index.
                var start = queries[i][0];
                var end = queries[i][1] + 1;
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
