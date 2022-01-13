using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    internal class RomanToInteger
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve("MCMXCIV"));//Result - 1994
            Console.WriteLine(Solve1("MCMXCIV"));//Result - 1994
            Console.ReadLine();
        }

        static int Solve(string s)
        {
            var result = 0;
            var values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            var symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            for (int i = 0; i < symbols.Length; i++)
            {
                while (s.StartsWith(symbols[i]))
                {
                    result += values[i];
                    s = s.Remove(0, symbols[i].Length);
                }
            }
            return result;
        }

        static Dictionary<string, int> values = new Dictionary<string, int>()
        {
            {"M", 1000 },
            //{"CM", 900 },
            {"D", 500 },
            //{"CD", 400 },
            {"C", 100 },
            //{"XC", 90 },
            {"L", 50 },
            //{"XL", 40 },
            {"X", 10 },
            //{"IX", 9 },
            {"V", 5 },
            //{"IV", 4 },
            {"I", 1 }
        };

        static int Solve1(string s)
        {
            int sum = 0;
            int i = 0;
            while (i < s.Length)
            {
                String currentSymbol = s.Substring(i, 1);
                int currentValue = values[currentSymbol];
                int nextValue = 0;
                if (i + 1 < s.Length)
                {
                    String nextSymbol = s.Substring(i + 1, 1);
                    if(values.ContainsKey(nextSymbol))
                        nextValue = values[nextSymbol];
                }

                if (currentValue < nextValue)
                {
                    sum += (nextValue - currentValue);
                    i += 2;
                }
                else
                {
                    sum += currentValue;
                    i += 1;
                }

            }
            return sum;
        }
    }
}
