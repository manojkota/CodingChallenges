using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    class CommonChild
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(commonChild("SHINCHAN", "NOHARAAH"));//result -3
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            Console.WriteLine(Solve("SHINCHAN", "NOHARAAH"));//result -3
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.WriteLine(Solve("AA", "BB"));//result - 0
            Console.WriteLine(Solve("ABCDEF", "FBDAMN"));//result - 2
            Console.ReadLine();
        }

        public static int commonChild(string s1, string s2)
        {
            int[,] C = new int[s1.Length + 1, s2.Length + 1]; // (a, b).Length + 1
            for (int i = 0; i < s1.Length; i++)
                C[i, 0] = 0;
            for (int j = 0; j < s2.Length; j++)
                C[0, j] = 0;
            for (int i = 1; i <= s1.Length; i++)
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])//i-1,j-1
                        C[i, j] = C[i - 1, j - 1] + 1;
                    else
                        C[i, j] = Math.Max(C[i, j - 1], C[i - 1, j]);
                }
            return C[s1.Length, s2.Length];
        }

        public static int Solve(string s1, string s2)
        {
            var values = new List<string>();
            
            for (int i = 0; i < s1.Length; i++)
            {
                var first = s1[i];
                var fInd = s2.IndexOf(first);
                if (!(fInd > -1))
                {
                    continue;
                }
                var sb = new StringBuilder();
                var li = -1;
                for (int k = i; k < s1.Length; k++)
                {
                    var curr = s1[k];
                    var ind = s2.Substring(li > -1 ? li+1 : 0).IndexOf(curr) + (li > -1 ? li+1 : 0);
                    if (ind > -1 && ind > li)
                    {
                        li = ind;
                        sb.Append(curr);
                    }
                    if(li+1 == s2.Length)
                    {
                        break;
                    }
                }
                values.Add(sb.ToString());
                //Console.WriteLine(sb.ToString());
            }
            
            return values?.OrderByDescending(x => x.Length)?.FirstOrDefault()?.Length ?? 0;
        }
    }
}
