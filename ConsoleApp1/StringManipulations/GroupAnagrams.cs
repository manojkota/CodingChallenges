using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringManipulations
{
    internal class GroupAnagrams
    {
        static void Main(string[] args)
        {
            var result = Solve(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });//Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(",", item));
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static IList<IList<string>> Solve(string[] strs)
        {
            var result = new List<IList<string>>();
            if (strs.Length == 1)
            {
                result.Add(new List<string>() { strs[0] });
                return result;
            }

            var dict = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var sortedStr = SortString(str);
                if (dict.ContainsKey(sortedStr))
                {
                    dict[sortedStr].Add(str);
                }
                else
                {
                    dict.Add(sortedStr, new List<string> { str });
                }
            }

            foreach (var item in dict)
            {
                result.Add(item.Value);
            }
            return result;
        }

        static string SortString(string s)
        {
            var arr = s.ToCharArray();
            Array.Sort(arr);
            return new string(arr);
        }
    }
}
