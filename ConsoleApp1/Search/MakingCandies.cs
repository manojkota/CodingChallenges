using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp1.Search
{
    class MakingCandies
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(Solve(3, 1, 2, 12)); // Result - 3
            Console.WriteLine(Solve(1, 1, 6, 45)); // Result - 16

            Console.ReadLine();
        }

        public static long Solve(long m, long w, long p, long n)
        {
            long passes = 0;
            long candy = 0;
            long run = long.MaxValue;
            long step;

            while (candy < n)
            {
                //check how many we can bulk buy
                step = (m > long.MaxValue / w) ? 0 : (p - candy) / (m * w);

                //If we can't bulk buy then step by step
                if (step <= 0)
                {
                    //Checking buing affordability
                    long mw = candy / p;

                    //if machines are greather than workers & buying affordability then increase workers else viseversa
                    //Make sure the m & w are as close as possible
                    if (m >= w + mw)
                    {
                        w += mw;
                    }
                    else if (w >= m + mw)
                    {
                        m += mw;
                    }
                    //If not both then update the machines & workers equally
                    else
                    {
                        long total = m + w + mw;
                        m = total / 2;
                        w = total - m;
                    }

                    //as we bought a machine or worker then candy will be deducted for buying price
                    candy %= p;
                    step = 1;
                }

                passes += step;

                if (step * m > long.MaxValue / w)
                {
                    candy = long.MaxValue;
                }
                else
                {
                    //calculate candies based on current step
                    candy += step * m * w;
                    run = Math.Min(run, (long)(passes + Math.Ceiling((n - candy) / (m * w * 1.0))));
                }
            }

            return Math.Min(passes, run);
            //long passes = 0;
            //long candies = 0;

            
            ////while (candies < n)
            ////{

            ////    passes++;
            ////    if (candies < p)
            ////    {
            ////        long tempPasses = (p - candies) / (m * w);
            ////        passes = passes + tempPasses;
            ////        candies = p;
            ////        continue;
            ////    }
            ////    candies += m * w;
            ////    if(candies >= n)
            ////    {
            ////        break;
            ////    }

            ////    while (candies/p > 0)
            ////    {
            ////        if(candies * 2 >= n)
            ////        {
            ////            break;
            ////        }
            ////        if(m > w)
            ////        {
            ////            w++;
            ////        }
            ////        else
            ////        {
            ////            m++;
            ////        }
            ////        candies -= p;
            ////        if((m *w)+candies >= n)
            ////        {
            ////            break;
            ////        }
            ////    }
            ////}
            //return maxPasses;
        }
    }
}
