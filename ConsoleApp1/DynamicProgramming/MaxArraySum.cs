using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DynamicProgramming
{
    internal class MaxArraySum
    {
        static void Main(string[] args)
        {
            Console.WriteLine( Solve(new int[] { -2,1,3,-4,5 }));//result - 8
            Console.WriteLine(Solve(new int[] { -2, -3, -1 }));//result - 0
            Console.ReadLine();
        }

        static int Solve(int[] arr)
        {
            var length = arr.Length;
            if(length == 0)
            {
                return 0;
            }
            if(length == 1)
            {
                return arr[0];
            }
            var dp = new int[arr.Length];
            dp[0] = Math.Max(0, arr[0]);
            dp[1] = Math.Max(dp[0], arr[1]);

            for (int i = 2; i < arr.Length; i++)
            {
                dp[i] = Math.Max(dp[i-1], arr[i] + dp[i - 2]);
            }

            return dp[length - 1];
        }
    }
}
