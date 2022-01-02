using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Amazon
{
    /// <summary>
    /// Given an array of integers, write a function that returns true if there is a triplet (a, b, c) that satisfies a2 + b2 = c2.
    /// </summary>
    internal class PythogorianTriplet
    {
        static void Main(string[] args)
        {
            Console.WriteLine( Solve(new List<int>() { 3, 1, 5, 4, 6 }));//Result - true
            Console.WriteLine( Solve(new List<int>() { 10, 4, 6, 12, 5 }));//Result - false
            Console.ReadLine();
        }

        private static bool Solve(List<int> input)
        {
            var result = false;
            var inArray = input.ToArray();
            Array.Sort(inArray);
            var cmap = new Dictionary<int, int>();
            var amap = new Dictionary<int, int>();
            foreach (var item in inArray)
            {
                var value = (int)Math.Pow(item, 2);
                if (cmap.ContainsKey(value))
                {
                    result = true;
                    break;
                }

                foreach (var key in amap)
                {
                    if(!cmap.ContainsKey((value + key.Key)))
                    {
                        cmap[value + key.Key] = 1;
                    }
                }
                
                if (!amap.ContainsKey(value))
                {
                    amap[value] = item;
                }
            }
            return result;
        }
    }
}
