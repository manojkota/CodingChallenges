using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BubbleSort
    {
        static void Main(string[] args)
        {
            Solve(new List<int>() { 6, 4, 1 });
            Console.ReadLine();
        }

        private static void Solve(List<int> a)
        {
            var swaps = 0;
            var length = a.Count;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        var t = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = t;
                        swaps++;
                    }
                }
            }
            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First Element: {a.First()}");
            Console.WriteLine($"Last Element: {a.Last()}");
        }
    }
}
