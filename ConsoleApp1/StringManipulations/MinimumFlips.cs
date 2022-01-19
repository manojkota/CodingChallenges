using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    internal class MinimumFlips
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinFlipsMonoIncr("00110"));//result - 1
            Console.ReadLine();
        }

        static int MinFlipsMonoIncr(string s)
        {
            int one = 0;
            int flip = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    one++;
                }
                else
                {
                    flip++;
                }
                flip = Math.Min(one, flip);
            }
            return flip;
        }
    }
}
