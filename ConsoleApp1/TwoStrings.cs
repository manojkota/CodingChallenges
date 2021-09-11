using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TwoStrings
    {
        public static string Execute(string s1, string s2)
        {
            var s1G = s1.Distinct().ToDictionary(x => x);
            var s2G = s2.Distinct().ToDictionary(x => x);
            return s1G.Intersect(s2G).Count() > 0 ? "YES" : "NO";
        }
    }
}
