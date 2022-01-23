using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.General
{
    internal class KthFactorOfN
    {
        static void Main(string[] args)
        {
            Console.WriteLine(KthFactor( 12, 3));//3
            Console.ReadLine();
        }

        static int KthFactor(int n, int k)
        {
            var factors = new List<int>() { 1 };

            var start = 2;
            if (n % 2 == 1)
            {
                start = 3;
            }

            for (var i = start; i <= n; i++)
            {
                if (n % i == 0)
                {
                    factors.Add(i);
                }
                if (factors.Count == k)
                {
                    break;
                }
            }
            return factors.Count >= k ? factors[k - 1] : -1;
        }
    }
}
