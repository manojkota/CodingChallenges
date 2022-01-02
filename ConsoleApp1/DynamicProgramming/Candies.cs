using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DynamicProgramming
{
    internal class Candies
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(3, new List<int>() { 1,2,3}));//result - 3
            Console.WriteLine(Solve(10, new List<int>() { 2, 4, 2, 6, 1, 7, 8, 9, 2, 1}));//result - 10
            Console.ReadLine();
        }

        public static long Solve(int n, List<int> arr)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            long[] c = new long[n];
            long[] s = new long[n];
            c[0] = 1;
            
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    c[i] = c[i - 1] + 1;
                }
                else
                {
                    c[i] = 1;
                }
            }
            s[n - 1] = c[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1])
                {
                    s[i] = s[i + 1] + 1;
                    c[i] = Math.Max(c[i], s[i]);
                }
                else
                {
                    s[i] = c[i];
                }
            }
            return c.Sum();
        }
    }
}
