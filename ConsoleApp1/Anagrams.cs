using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Anagrams
    {
        public static int Execute(string s)
        {
            var result = 0;

            for (int i = 1; i < s.Length; i++)
            {
                var found = new Dictionary<string, int>();
                for (int j = 0; i + j <= s.Length; j++)
                {
                    var word = s.Substring(j, i);
                    var a = word.ToArray();
                    Console.WriteLine(word);
                    Array.Sort(a);
                    word = new string(a);
                    if (found.ContainsKey(word))
                    {
                        result += found[word];
                        found[word]++;
                    }
                    else
                    {
                        found[word] = 1;
                    }
                }
            }
            
            return result;
        }
    }
}
