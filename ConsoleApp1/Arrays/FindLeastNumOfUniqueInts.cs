using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    internal class FindLeastNumOfUniqueInts
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(new int[] { 4, 3, 1, 1, 3, 3, 2 }, 3));
            Console.ReadLine();
        }

        static int Solve(int[] arr, int k)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]]++;
                }
                else
                {
                    dict.Add(arr[i], 1);
                }
            }

            var target = k;
            foreach (var item in dict.OrderBy(x => x.Value))
            {
                for (var j = 1; j <= item.Value && target > 0; j++)
                {
                    dict[item.Key]--;
                    target--;
                }
                if (target == 0)
                {
                    break;
                }
            }
            return dict.Count(x => x.Value > 0);
        }
    }
}
