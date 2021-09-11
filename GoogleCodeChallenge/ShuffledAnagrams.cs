using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleCodeChallenge
{
    class ShuffledAnagrams
    {
        
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            var inputData = new List<string>();
            for (int i = 0; i < t; i++)
            {
                inputData.Add(Console.ReadLine());
            }

            for (int i = 0; i < inputData.Count; i++)
            {
                Go(inputData[i], i + 1);
            }
            Console.ReadLine();
        }

        static void Go(string input, int caseNo)
        {
            var result = "IMPOSSIBLE";
            char[] t = input.ToCharArray();
            int n = t.Length;
            int[][] ai = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ai[i] = new int[] { t[i], i };
            }
            Array.Sort(ai, (x, y) => 
            {
                if (x[0] != y[0]) return x[0] - y[0];
                return (x[1] - y[1]);
            });
            char[] u = new char[n];
            for (int i = 0; i < n; i++)
            {
                u[ai[(i + n / 2) % n][1]] = (char)ai[i][0];
            }

            for (int i = 0; i < n; i++)
            {
                if (t[i] == u[i])
                {
                    Console.WriteLine("Case #{0}: {1}", caseNo, result);
                    return;
                }
            }
            Console.WriteLine("Case #{0}: {1}", caseNo, new string(u));
        }
    }
}
