using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MaximumToys
    {
        static void Main(string[] args)
        {
           Console.WriteLine(Solve(new List<int>() { 1, 12, 5, 111, 200, 1000, 10 }, 50));
            Console.ReadLine();
        }

        private static int Solve(List<int> prices, int k)
        {
            var result = 0;
            prices.Sort();
            var bill = 0;
            for (int i = 0; i < prices.Count; i++)
            {
                if(bill + prices[i] <= k)
                {
                    bill += prices[i];
                    result++;
                }
            }
            return result;
        }
    }
}
