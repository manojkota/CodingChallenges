using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    class OddNumberAdditions
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchTest>();
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Console.WriteLine(AddOddNumbers_Bit_Shift(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToArray()));
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            //sw.Restart();
            //Console.WriteLine(AddOddNumbers(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToArray()));
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            //sw.Restart();
            //Console.WriteLine(AddOddNumbers_Bit_Shift_Fixed_Pointer(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToArray()));
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        
    }

    [MemoryDiagnoser]
    public class BenchTest
    {
        [Benchmark]
        public long AddOddNumbers()
        {
            var arr = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    count += arr[i];
                }
            }
            return count;
        }

        [Benchmark]
        public long AddOddNumbers_Bit_Shift()
        {
            var arr = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count += ((arr[i] & 1) == 1) ? arr[i] : 0;
            }
            return count;
        }

        [Benchmark]
        public unsafe long AddOddNumbers_Bit_Shift_Fixed_Pointer()
        {
            var arr = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var count = 0;
            var a = arr.ToArray();
            fixed (int* p = a)
            {
                int* c = p;
                for (int i = 0; i < arr.Length; i++)
                {
                    count += (p[i] & 1) * p[i];
                }
            }

            return count;
        }
    }
}
