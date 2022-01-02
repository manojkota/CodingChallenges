using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DynamicProgramming
{
    internal class Abbreviation
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve("daBcd", "ABC"));//result - YES
            Console.ReadLine();
        }

        public static string Solve(string a, string b)
        {
            var dp = new bool[a.Length + 1, b.Length + 1];

            dp[0, 0] = true;
            
            for (int i = 1; i <= a.Length; i++)
            {
                if (char.IsLower(a[i - 1]))
                {
                    dp[i, 0] = true;
                }
                else
                {
                    dp[i, 0] = false;
                }
            }
            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    char ca = a[i - 1], cb = b[j - 1];
                    if (ca == cb)
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (char.ToUpper(ca) == cb)
                    {
                        dp[i, j] = dp[i - 1, j - 1] || dp[i - 1, j];
                    }
                    else if (char.IsUpper(ca))
                    {
                        dp[i, j] = false;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[a.Length, b.Length] ? "YES" : "NO";
        }
    }
}
