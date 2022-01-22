using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Hashtable
{
    internal class Analyze_User_Website_Visit_Pattern
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MostVisitedPattern(new string[] { "joe", "joe", "joe", "james", "james", "james", "james", "mary", "mary", "mary" },
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new string[] { "home", "about", "career", "home", "cart", "maps", "home", "home", "about", "career" }));//OP - ["home","about","career"]
            Console.ReadLine();
        }

        public class Solution
        {
            public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
            {

                var entries = new List<Entry>();
                for (int i = 0; i < username.Length; i++)
                {
                    var e = new Entry(username[i], timestamp[i], website[i]);
                    entries.Add(e);
                }

                // order entries by Timestamp ASC
                entries = entries.OrderBy(e => e.TimeStamp).ToList();

                // username & websites in order
                var dict = new Dictionary<string, List<string>>();

                foreach (var entry in entries)
                {
                    if (dict.ContainsKey(entry.UserName))
                    {
                        dict[entry.UserName].Add(entry.Website);
                    }
                    else
                    {
                        dict.Add(entry.UserName, new List<string>() { entry.Website });
                    }
                }

                // home,away,love -> key (hashset of usernames)
                // leetcode,love,leetcode -> key (hashset of usernames)
                Dictionary<string, HashSet<string>> counts = new Dictionary<string, HashSet<string>>();
                foreach (var kvp in dict)
                {
                    var sites = kvp.Value;

                    for (int i = 0; i < sites.Count - 2; i++)
                    {
                        for (int j = i + 1; j < sites.Count - 1; j++)
                        {
                            for (int k = j + 1; k < sites.Count; k++)
                            {
                                var key = sites[i] + "," + sites[j] + "," + sites[k];
                                if (counts.ContainsKey(key))
                                {
                                    counts[key].Add(kvp.Key);
                                }
                                else
                                {
                                    counts.Add(key, new HashSet<string>() { kvp.Key });
                                }
                            }
                        }
                    }
                }

                string result = "";
                int maxPattern = 0;
                int currentCount = 0;

                foreach (var kvp in counts)
                {
                    currentCount = kvp.Value.Count;
                    if (currentCount > maxPattern)
                    {
                        maxPattern = currentCount;
                        result = kvp.Key;
                    }
                    else if (currentCount == maxPattern && string.Compare(kvp.Key, result) == -1)
                    {
                        result = kvp.Key;
                    }
                }

                return result.Split(',');
            }

            public class Entry
            {
                public string UserName;
                public int TimeStamp;
                public string Website;

                public Entry(string u, int t, string w)
                {
                    UserName = u;
                    TimeStamp = t;
                    Website = w;
                }
            }
        }
    }
}
