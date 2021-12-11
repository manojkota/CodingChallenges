using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    class SherlockAndTheValidString
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve1("abcdefghhgfedecba"));
            Console.WriteLine(Solve("abcc"));
            Console.WriteLine(Solve("aabbcd"));
            Console.ReadLine();
        }

        private static string Solve1(string s)
        {
            var groups = s.GroupBy(c => c);
            var groupedCounts = groups.GroupBy(c => c.Count()).OrderByDescending(e => e.Count());
            if (groupedCounts.Count() == 2)
                return groupedCounts.ElementAt(1).Count() == 1 && (groupedCounts.ElementAt(1).Key == 1 || Math.Abs(groupedCounts.ElementAt(1).Key - groupedCounts.First().Key) <= 1) ? "YES" : "NO";
            else if (groupedCounts.Count() == 1)
                return "YES";
            return "NO";
        }

        public static string Solve(string s)
        {
            var result = false;

            var ad = new Dictionary<char, int>();
            s.ToList().ForEach(x =>
            {
                if (ad.ContainsKey(x))
                {
                    ad[x] += 1;
                }
                else
                {
                    ad[x] = 1;
                }
            });
            
            if(ad.Max(x => x.Value) - ad.Min(x => x.Value) <= 1)
            {
                var cd = new Dictionary<int, int>();
                foreach (var item in ad)
                {
                    if(cd.ContainsKey(ad[item.Key]))
                    {
                        cd[ad[item.Key]] += 1;
                    }
                    else
                    {
                        cd[ad[item.Key]] = 1;
                    }
                }

                int c = 0, lk = 0, lv = 0, dc = 0 ;
                result = true;
                
                foreach (var item in cd.OrderByDescending(x => x.Value))
                {
                    if(c == 0)
                    {
                        lk = item.Key;
                        lv = cd[item.Key];
                        c++;
                        continue;
                    }
                    var cv = cd[item.Key];
                    var ck = item.Key;
                    if(c > 1 || !(cv == 1 && (ck ==1 || ck - lk <= 1)))
                    {
                        result = false;
                        break;
                    }
                    //if((cv * ck) - (lv * lk) > 1)
                    //{
                    //    result = false;
                    //    break;
                    //}
                    //else 
                    //{
                    //    dc += (cv * ck) - (lv * lk);
                    //}
                   
                    lk = ck;
                    lv = cv;
                    c++;
                }
            }

            return result ? "YES" : "NO";
        }
    }
}
