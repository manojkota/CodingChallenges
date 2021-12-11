using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    class LuckBalance
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(3, new List<List<int>> { new List<int> { 5,1},
            new List<int> { 2,1},
            new List<int> { 1,1},
            new List<int> { 8,1},
            new List<int> { 10,0},
            new List<int> { 5,0}}));//Result - 29
            Console.WriteLine(Solve(2, new List<List<int>> { new List<int> { 5,1},
            new List<int> { 1,1},
            new List<int> { 4,0}}));//Result - 10
            Console.ReadLine();
        }

        public static int Solve(int k, List<List<int>> contests)
        {
            var result = 0;
            contests = contests.OrderBy(x => x[1]).OrderByDescending(x => x[0]).ToList();
            foreach (var item in contests)
            {
                var c = item[0];
                var i = item[1];
                //Console.WriteLine($"{c} - {i}");
                if(i == 0)
                {
                    result += c;
                }
                else if(k > 0)
                {
                    result += c;
                    k--;
                }
                else
                {
                    result -= c;
                }
            }
            return result;
        }
    }
}
