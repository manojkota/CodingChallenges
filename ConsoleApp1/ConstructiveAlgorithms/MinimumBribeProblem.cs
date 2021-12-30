using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class MinimumBribeProblem
    {
              
        public static void minimumBribes(int[] q)
        {

            int bribe = 0;
            bool chaotic = false;
            int n = q.Length;
            for (int i = 0; i < n; i++)
            {
                if (q[i] - (i + 1) > 2)
                {
                    chaotic = true;
                    break;
                }
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                    if (q[j] > q[i])
                        bribe++;
            }
            if (chaotic)
                Console.WriteLine("Too chaotic");
            else
                Console.WriteLine(bribe);

            //var bribes = 0;
            ////var faulty = false;

            ////for (int i = 0; i < q.Length; i++)
            ////{
            ////    var av = i + 1;
            ////    if (q[i] - av > 2)
            ////    {
            ////        Console.WriteLine("Too chaotic");
            ////        return;
            ////    }
            ////}
                

            //for (int i = 0; i < q.Length; i++)
            //{
            //    var av = i + 1;
            //    if (q[i] == av)
            //    {
            //        continue;
            //    }
            //    else if (q[i] - av > 2)
            //    {
            //        Console.WriteLine("Too chaotic");
            //        return;
            //    }
            //    for (int j = Math.Max(0, q[i] - 2); j < i; j++)
            //    {
            //        if (q[j] > q[i])
            //        {
            //            bribes++;
            //        }
            //    }
                    
            //    //var iVal = q[i];
            //    //for (int j = i+1; j < q.Length; j++)
            //    //{
            //    //    var swaps = 0;
            //    //    if(q[i] > q[j] && swaps < 2)
            //    //    {
            //    //        var t = q[j];
            //    //        q[j] = q[i];
            //    //        q[i] = t;
            //    //        bribes++;
            //    //        swaps++;
            //    //    }
            //    //    //else if (j >= iVal)
            //    //    //{
            //    //    //    break;
            //    //    //}
            //    //    else if(swaps >= 2)
            //    //    {
            //    //        break;
            //    //    }
            //    //}
            //}
            //Console.WriteLine(bribes);
            
            //for (int i = 0; i < q.Length; i++)
            //{
            //    var av = i + 1;
            //    if (q[i] == av)
            //    {
            //        continue;
            //    }
            //    else if (q[i] > av && q[i] - av <= 2)
            //    {
            //        bribes += (q[i] - av);
            //    }
            //    else if (q[i] < av && av - q[i] <= 2)
            //    {
            //        bribes += (av - q[i]);
            //    }
            //    //else if (q[i] == av + 1)
            //    //{
            //    //    bribes += 1;
            //    //}
            //    //else if (q[i] == av + 2)
            //    //{
            //    //    bribes += 2;
            //    //}
            //    else if (q[i] < av)
            //    {
            //        if (q[i] == i - 3)
            //        {
            //            bribes += ((i - 2) - q[i]);
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //    }
            //    else
            //    {
            //        faulty = true;
            //        break;
            //    }
            //}

            //if (faulty)
            //{
            //    Console.WriteLine("Too chaotic");
            //}
            //else
            //{
            //    Console.WriteLine(bribes);
            //}
        }
    }
}
