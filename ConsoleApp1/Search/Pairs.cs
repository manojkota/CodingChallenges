using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Search
{
    class Pairs
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(2, new List<int> {1,5,3,4,2 }));//result - 3
            //Solve(new List<int> { 2,2,4,3 }, 4);//result 1 2
            Console.ReadLine();
        }

        public static int Solve(int k, List<int> arr)
        {
            var count = 0;
            var input = arr.ToArray();
            Array.Sort(input);

            //Two pointer solutions...valid one
            //int i = 0, j = 1;
            //while(j < input.Length)
            //{
            //    var diff = input[j] - input[i];
            //    if(diff == k)
            //    {
            //        count++;
            //        j++;
            //    }
            //    else if(diff > k)
            //    {
            //        i++;
            //    }
            //    else if(diff < k)
            //    {
            //        j++;
            //    }
            //}
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var val = input[i] + k;
                if (dict.ContainsKey(input[i]))
                {
                    count++;
                }
                dict[val] = i;
            }
            return count;
        }
    }
}
