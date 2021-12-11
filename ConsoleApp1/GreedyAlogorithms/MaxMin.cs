using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    class MaxMin
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(3, new List<int>{ 10,100,300,200,1000,20,30 }));//Result - 20
            Console.WriteLine(Solve(4, new List<int> { 1,2,3,4,10,20,30,40,100,200}));//Result - 3
            //Console.WriteLine(Solve(3, new int[] { 1, 3, 5, 7, 9 }));//Result - 29
            Console.ReadLine();
        }

        public static int Solve(int k, List<int> arr)
        {
            var result = int.MaxValue;
            var input = arr.ToArray();
            Array.Sort(input);
            for (int i = 0; i < input.Length -k + 1; i++)
            {
                var t = Math.Abs(input[i + k - 1] - input[i]);

                if (t < result)
                {
                    result = t;
                }
            }
            return result;
        }
    }
}
