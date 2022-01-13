using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    internal class IntegerToRoman
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(1994));//Result - MCMXCIV
            Console.ReadLine();
        }

        static string Solve(int num)
        {
            var values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4 ,1 };
            var symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X","IX", "V", "IV", "I" };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < values.Length && num > 0; i++)
            {
                while(values[i] <= num)
                {
                    num -= values[i];
                    sb.Append(symbols[i]);
                }
            }
            return sb.ToString();
        }
    }
}
