using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    /// <summary>
    /// Find the most frequently occurringitem in an array. 
    /// Example:The most frequently occurring item in [1, 3, 1, 3, 2, 1] is 1. 
    /// If you're given an empty array, you should return null (in Java)or None (in Python). 
    /// You can assume that there is always a single, unique value that appears most frequently unless the array is empty. 
    /// For instance, you won't be given an array such as [1, 1, 2, 2].
    /// </summary>
    internal class MostFrequencyOccuringItemInArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(new int[] { 1, 2, 3, 1, 4 }));//result - 1
            Console.ReadLine();
        }

        static int? Solve(int[] arr)
        {
            int? result = null;
            int maxCount = 0;
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if(dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]] = dict[arr[i]]+1;
                }
                else
                {
                    dict.Add(arr[i], 1);
                }
                                
                if(dict[arr[i]] > maxCount)
                {
                    maxCount = dict[arr[i]];
                    result = arr[i];
                }
            }
            return result;
        }
    }
}
