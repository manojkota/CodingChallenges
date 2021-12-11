using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp1.Search
{
    class MaxSubArraySum
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(new List<long> { 3,3,9,9,5 }, 7));//result - 6
            Console.WriteLine(Solve(new List<long> { 1, 2, 3 }, 2));//result - 1
            
            Console.ReadLine();
        }

        public static long Solve(List<long> a, long m)
        {
            long max = 0;
            a.Sort();
            for (int i = 1; i <= a.Count(); i++)
            {
                var k = 1;
                while(k <= a.Count())
                {
                    var sub = a.Skip(k - 1).Take(i);
                    //foreach (var item in sub)
                    //{
                    //    Console.Write(item + "\n");
                    //}
                    //Console.WriteLine();
                    var s = (sub.Sum()) % m;
                    if (s > max)
                    {
                        max = s;
                    }
                    if (k + i > a.Count())
                    {
                        break;
                    }
                    k += 1;
                    
                }
            }
            return max;
        }
    }
}
