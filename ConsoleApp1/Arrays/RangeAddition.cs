using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    internal class RangeAddition
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", GetModifiedArray(5, new int[3][] {new int[3] {1,3,2},
            new int[3]{ 2,4,3 },
            new int[3] {0,2,-2}})));//[-2,0,3,5,3]
            Console.ReadLine();
        }

        static int[] GetModifiedArray(int length, int[][] updates)
        {
            var arr = new int[length + 1];

            for (var k = 0; k < updates.Length; k++)
            {
                var i = updates[k][0];
                var j = updates[k][1];
                var val = updates[k][2];
                arr[i] += val;
                arr[j + 1] -= val;
            }

            for (int k = 1; k < length; k++)
            {
                arr[k] = arr[k] + arr[k - 1];
            }

            return arr.Take(arr.Length-1).ToArray();
        }
    }
}
