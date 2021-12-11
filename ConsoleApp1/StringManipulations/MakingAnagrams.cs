using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    class MakingAnagrams
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MakeAnagram("fcrxzwscanmligyxyvym", "jxwtrhvujlmrpdoqbisbwhmgpmeoke"));
            //Console.WriteLine(MakeAnagram("cde", "abc"));
            //Console.WriteLine(MakeAnagram("cde", "dcf"));
            Console.ReadLine();
        }

        public static int MakeAnagram(string a, string b)
        {
            var count = 0;
            var ad = new Dictionary<char, int>();
            var bd = new Dictionary<char, int>();
            a.ToList().ForEach(x =>
            {
                if(ad.ContainsKey(x))
                {
                    ad[x] += 1;
                }
                else
                {
                    ad[x] = 1;
                }
            });

            b.ToList().ForEach(x =>
            {
                if (bd.ContainsKey(x))
                {
                    bd[x] += 1;
                }
                else
                {
                    bd[x] = 1;
                }
            });

            foreach (var k in ad)
            {
                if(bd.ContainsKey(k.Key))
                {
                    var min = Math.Min(bd[k.Key], ad[k.Key]);
                    if(bd[k.Key] > min)
                    {
                        count += bd[k.Key] - min;
                    }
                    else if (ad[k.Key] > min)
                    {
                        count += ad[k.Key] - min;
                    }
                }
                else
                {
                    count += ad[k.Key];
                }
            }

            foreach (var item in bd)
            {
                if(!ad.ContainsKey(item.Key))
                {
                    count += bd[item.Key];
                }
            }

            return count;
        }
    }
}
