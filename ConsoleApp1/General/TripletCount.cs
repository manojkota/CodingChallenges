using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TripletCount
    {
        public static long Execute(List<long> arr, long r)
        {
            long count = 0;
            var mp2 = new Dictionary<long, long>();
            var mp3 = new Dictionary<long, long>();

            foreach (long val in arr)
            {
                if (mp3.ContainsKey(val))
                {
                    count += mp3[val];
                }
                if (mp2.ContainsKey(val))
                {
                    if (mp3.ContainsKey(val * r))
                    {
                        mp3[val * r] += mp2[val];
                    }
                    else
                    {
                        mp3[val * r] = mp2[val];
                    }
                }
                if (mp2.ContainsKey(val * r))
                {
                    mp2[val * r]++;
                }
                else
                {
                    mp2[val * r] = 1;
                }
            }
            
            return count;
        }
    }
}
