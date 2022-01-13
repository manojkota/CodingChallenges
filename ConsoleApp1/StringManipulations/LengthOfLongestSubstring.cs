using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    internal class LengthOfLongestSubstring
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve("dvdf"));//result - 3
            Console.WriteLine(Solve("au"));//result - 2
            Console.ReadLine();
        }

        public static int Solve(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }
            if (s.Length == 1)
            {
                return 1;
            }
            var result = 0;
            var dict = new Dictionary<char, int>();
            int start = 0;
            int end = 0;
            while (end < s.Length)
            {
                if (dict.ContainsKey(s[end]))
                {
                    start = Math.Max(start, dict[s[end]]);
                }
                result = Math.Max(result, end - start + 1);
                dict[s[end]] = end + 1;
                end++;
            }
            return result;
        }
    }
}
