using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    /// <summary>
    /// Write a function that returns the common elements (as an array)between twosortedarrays of integers (ascending order). 
    /// Example: The common elements between[1, 3, 4, 6, 7, 9] and[1, 2, 4, 5, 9, 10] are[1, 4, 9].
    /// </summary>
    internal class CommonElementsInTwoArrays
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", Solve(new int[] { 1,3,4,6,7,9 }, new int[] {1,2,4,5,9,10})));//result - [1,4,9]
            Console.ReadLine();
        }

        static int[] Solve(int[] a , int[] b)
        {
            var result = new List<int>();
            int i = 0, j = 0;
            while (i < a.Length && j < b.Length)
            {
                if(a[i] == b[j])
                {
                    result.Add(a[i]);
                    i++;
                    j++;
                }
                else if(a[i] > b[j])
                {
                    j++;
                }
                else if (a[i] < b[j])
                {
                    i++;
                }
            }
            return result.ToArray();
        }
    }
}
