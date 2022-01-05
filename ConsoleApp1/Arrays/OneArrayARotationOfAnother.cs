using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    /// <summary>
    /// Write a function that returns true if one array is a rotation of another. 
    /// NOTE:There areno duplicatesin each of these arrays. Example:[1, 2, 3, 4, 5, 6, 7] is a rotation of[4, 5, 6, 7, 1, 2, 3].
    /// </summary>
    internal class OneArrayARotationOfAnother
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", Solve(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 4, 5, 6, 7, 8, 1,2,3 })));//result - true
            Console.ReadLine();
        }

        static bool Solve(int[] a, int[] b)
        {
            if(a.Length != b.Length)
            {
                return false;
            }
            var result = true;
            var x = a[0];
            var y = -1;
            for (int j = 0; j < b.Length; j++)
            {
                if(x == b[j])
                {
                    y = j;
                    break;
                }
            }
            if(y == -1)
            {
                return false;
            }
            var k = 0;
            while(k < a.Length)
            {
                if(a[k] == b[(y+k)%b.Length])
                {
                    k++;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
