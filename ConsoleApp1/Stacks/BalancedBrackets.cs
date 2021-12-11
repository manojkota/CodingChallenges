using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Stacks
{
    class BalancedBrackets
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve("{[()]}"));//result - Yes
            Console.WriteLine(Solve("{[(])}"));//result - No
            Console.WriteLine(Solve("{{[[(())]]}}"));//result - Yes

            Console.ReadLine();
        }

        static string Solve(string s)
        {
            var result = "NO";
            if(s.Length % 2 == 0)
            {
                var arr = s.ToArray();
                var res = new List<int>();
                for(int i = 0; i < arr.Length; i++)
                {
                    if (res.Count() == 0)
                    {
                        res.Add(arr[i]);
                        continue;
                    }
                    var t = (int)res.Last();
                    var c = (int)arr[i];
                    if (c == 41)
                    {
                        if (t + 1 == c)
                        {
                            res.RemoveAt(res.Count() - 1);
                        }
                        else
                        {
                            res.Add(c);
                        }
                    }
                    else if (c == 93)
                    {
                        if (t + 2 == c)
                        {
                            res.RemoveAt(res.Count() - 1);
                        }
                        else
                        {
                            res.Add(c);
                        }
                    }
                    else if (c == 125)
                    {
                        if (t + 2 == c)
                        {
                            res.RemoveAt(res.Count() - 1);
                        }
                        else
                        {
                            res.Add(c);
                        }
                    }
                    else
                    {
                        res.Add(c);
                    }
                }
                if (res.Count() == 0)
                {
                    result = "YES";
                }
            }
            
            return result;
        }
    }
}
