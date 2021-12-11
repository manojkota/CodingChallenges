using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    class MinAbsoluteDiff
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(new List<int> { 3, -7 , 0}));//Result - 3
            Console.WriteLine(Solve(new List<int> { 1, -3, 71, 68, 17 }));//Result - 3
            Console.ReadLine();
        }

        public static int Solve(List<int> arr)
        {
            var result = int.MaxValue;
            var input = arr.ToArray();
            Array.Sort(input);
            for (int i = 1; i < input.Length; i++)
            {
                var t = input[i] - input[i-1];
                if(t < result)
                {
                    result = t;
                }
            }
            return result;
        }
    }
}
