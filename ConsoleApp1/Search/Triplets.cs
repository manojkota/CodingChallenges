using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp1.Search
{
    class Triplets
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TripletsBenchTest>();
            //Console.WriteLine(Solve(new int[] { 1, 3, 5, 7 },
            //    new int[] { 5, 7, 9 },
            //    new int[] { 7, 9, 11, 13 }));//result - 12
            //Console.WriteLine(Solve(new int[] { 1, 3, 5 },
            //    new int[] { 2, 3 },
            //    new int[] { 1, 2, 3 }));//result - 8
            //Console.WriteLine(Solve(new int[] { 1, 4, 5 },
            //    new int[] { 2, 3, 3 },
            //    new int[] { 1, 2, 3 }));//result - 5
            //Console.ReadLine();
        }

        static long Solve(int[] a, int[] b, int[] c)
        {
            long count = 0;
            a = a.Distinct().ToArray();
            b = b.Distinct().ToArray();
            c = c.Distinct().ToArray();
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);

            long ai = 0,
                ci = 0;

            for (int j = 0; j < b.Length; j++)
            {
                while (ai < a.Length && a[ai] <= b[j])
                    ai += 1;
                while (ci < c.Length && c[ci] <= b[j])
                    ci += 1;
                count += ai * ci;
            }


            //foreach (var item in b)
            //{
            //    var ac = a.Where(x => x <= item).Count();
            //    var cc = c.Where(x => x <= item).Count();
            //    count += ac * cc;
            //}

            return count;
        }
    }

    [MemoryDiagnoser]
    public class TripletsBenchTest
    {
        [Benchmark]
        public long Solve()
        {
            var a = new int[] { 1, 3, 5, 7 };
            var b = new int[] { 5, 7, 9 };
            var c = new int[] { 7, 9, 11, 13 };
            long count = 0;
            a = a.Distinct().ToArray();
            b = b.Distinct().ToArray();
            c = c.Distinct().ToArray();
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);

            long ai = 0,
                ci = 0;

            for (int j = 0; j < b.Length; j++)
            {
                while (ai < a.Length && a[ai] <= b[j])
                    ai += 1;
                while (ci < c.Length && c[ci] <= b[j])
                    ci += 1;
                count += ai * ci;
            }

            return count;
        }

        [Benchmark]
        public long Solve1()
        {
            var a = new int[] { 1, 3, 5, 7 };
            var b = new int[] { 5, 7, 9 };
            var c = new int[] { 7, 9, 11, 13 };
            long count = 0;
            a = a.Distinct().ToArray();
            b = b.Distinct().ToArray();
            c = c.Distinct().ToArray();
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);


            foreach (var item in b)
            {
                long ac = a.Where(x => x <= item).Count();
                long cc = c.Where(x => x <= item).Count();
                count += ac * cc;
            }

            return count;
        }
    }
}
