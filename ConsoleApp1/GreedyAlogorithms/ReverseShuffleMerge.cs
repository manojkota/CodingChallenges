using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    class ReverseShuffleMerge
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve("aeiouuoiea"));//Result - aeiou
            Console.WriteLine(Solve("abcdefgabcdefg"));//Result - agfedcb
            Console.WriteLine(Solve("eggegg"));//Result - egg
            Console.ReadLine();
        }

        public static string Solve(string s)
        {
            var result = new List<char>();
            var used = new Dictionary<char, int>();
            var unused = new Dictionary<char, int>();
            var req = new Dictionary<char, int>();
            foreach (var c in s)
            {
                unused[c] = unused.ContainsKey(c) ? unused[c] + 1 : 1;
            }

            foreach (var item in unused)
            {
                req[item.Key] = item.Value / 2;
                used[item.Key] = 0;
            }

            int j = 1;
            var cc = s[s.Length - 1];
            result.Add(cc);
            unused[cc]--;
            used[cc]++;
            for (int i = s.Length - 2; i >= 0; i--)
            {
                cc = s[i];
                //var rc = result.Count();
                if (used[cc] < req[cc])
                {
                    if(cc > result[j-1])
                    {
                        result.Add(cc);
                        j++;
                        unused[cc]--;
                        used[cc]++;
                    }
                    else
                    {
                        while(j > 0 && cc < result[j-1] && used[result[j-1]]-1 + unused[result[j-1]] >= req[result[j-1]])
                        {
                            var ind = --j;
                            var t = result[ind];
                            result.RemoveAt(ind);
                            used[t]--;
                        }
                        result.Add(cc);
                        j++;
                        unused[cc]--;
                        used[cc]++;
                    }
                }
                else
                {
                    unused[cc]--;
                }
            }

            return new string(result.ToArray());
        }
    }
}
