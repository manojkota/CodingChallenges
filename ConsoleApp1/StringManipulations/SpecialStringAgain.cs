using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    class SpecialStringAgain
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(Solve(4, "aaaa"));
            Console.WriteLine(Solve(8, "mnonopoo"));
            //Console.WriteLine(MakeAnagram("cde", "dcf"));
            Console.ReadLine();
        }

        public static long Solve(int n, string s)
        {
            long count = n;
            for (int i = 0; i < s.Length; i++)
            {
                var first = s[i];
                var diffIndex = -1;
                for (int j = i+1; j < s.Length; j++)
                {
                    var curr = s[j];
                    if(first == curr)
                    {

                        if ((diffIndex == -1) ||
                            (j - diffIndex == diffIndex - i))
                        {
                            count++;
                        }
                    }
                    else
                    {
                        if (diffIndex == -1)
                            diffIndex = j;
                        else
                            break;
                    }
                }
            }
            return count;
        }

        public static long Solve1(int n, string s)
        {
            long count = n;
            int i = 0, c = 2;
            char[] input = s.ToCharArray();
            while(i < n)
            {
                if(i+c > n)
                {
                    c++;
                    i = 0;
                }
                else if (i + c <= n)
                {
                    var ss = input.Skip(i).Take(c).ToArray(); //s.Substring(i, c);
                    count = CheckSpecialString(count, c, ss);

                    i++;
                }
                if (c > n)
                {
                    break;
                }
            }

            return count;
        }

        private static long CheckSpecialString(long count, int c, char[] ss)
        {
            var mid = c / 2;
            
            var s1 = ss.Take(mid).ToArray();// ss.Substring(0, mid);
            var s2 = ss.Skip(c % 2 == 0 ? mid : mid + 1).ToArray(); //ss.Substring(c % 2 == 0 ? mid : mid + 1);
            if (s1.ToString() == s2.ToString() && s1.All(x => s1[0] == x) && s2.All(x => s1[0] == x))
            {
                Console.WriteLine(ss);
                count++;
            }

            return count;
        }
    }
}
