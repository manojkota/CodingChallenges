using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeChallenge
{
    class IncreasingSequence
    {
        static void Main(string[] args)
        {
            var readFromFile = false;
            string[] lines = null;
            if (readFromFile)
            {
                lines = System.IO.File.ReadAllLines(@"Data\palindromecrossword_sample_input.txt");
            }
            int t = readFromFile ? Convert.ToInt32(lines[0]) : Convert.ToInt32(Console.ReadLine());
            var ln = 1;

            for (int i = 0; i < t; i++)
            {
                Execute(i + 1, Convert.ToInt64(Console.ReadLine()));
            }


            Console.ReadLine();
        }

        private static void Execute(int cn, long n)
        {
            double gamma = 0.57721566490153286061;
            if (n <= 1000000)
            {
                double s = 0;
                for (long i = 1; i <= n; i++)
                {
                    s += 1 /(double) i;
                }
                Console.WriteLine("Case #{0}: {1}", cn, s);
            }
            else
            {
                Console.WriteLine("Case #{0}: {1}", cn, Math.Log(n) + gamma);
            }
        }
    }
}
