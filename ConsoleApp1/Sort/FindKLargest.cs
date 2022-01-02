using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Sort
{
    /// <summary>
    /// Question: Write an efficient program for printing k largest elements in an array. Elements in an array can be in any order.
    ///For example, if the given array is [1, 23, 12, 9, 30, 2, 50] and you are asked for the largest 3 elements i.e., k = 3 then your program should print 50, 30, and 23.
    /// </summary>
    internal class FindKLargest
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", Solve(new List<int>() { 1, 23, 12, 9, 30, 2, 50 }, 2)));
            Console.ReadLine();
        }

        private static List<int> Solve(List<int> input, int k)
        {
            var result = new List<int>();
            for(var pass = input.Count - 1; pass >= input.Count - k; pass--)
            {
                for (int i = 0; i < pass; i++)
                {
                    if(input[i] > input[i+1])
                    {
                        var temp = input[i];
                        input[i] = input[i+1];
                        input[i+1] = temp;
                    }
                }
                result.Add(input[pass]);
            }
            return result;
        }
    }
}
