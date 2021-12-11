using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    class GreedyFlorist
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(3, new int[]{ 2,5,6 }));//Result - 13
            Console.WriteLine(Solve(2, new int[] { 2,5,6}));//Result - 15
            Console.WriteLine(Solve(3, new int[] { 1, 3, 5, 7, 9 }));//Result - 29
            Console.ReadLine();
        }

        static int Solve(int k, int[] c)
        {
            var result = 0;
            //sort the array
            Array.Sort(c);
            var l = c.Length;
                        
            //if people are equal to flowers then sum all the elements in the array
            if(k == l)
            {
                result = c.Sum();
            }
            //if people are greater than flowers then buy flowers from low to high
            else if(k > l)
            {
                for (int i = 0; i < l; i++)
                {
                    if(i <= k)
                    {
                        result += c[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //if people less than flowers they have to buy all flowers and max low cost flowers
            else
            {
                var p = 0;
                var r = 1;
                for (int i = l-1; i >= 0; i--)
                {
                    result += ((p + 1) * c[i]);
                    if(r == k)
                    {
                        p++;
                        r = 1;
                    }
                    else
                    {
                        r++;
                    }
                }
            }

            return result;
        }
    }
}
