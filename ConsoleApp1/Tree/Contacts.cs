using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tree
{
    internal class Contacts
    {
        public static void Main(string[] args)
        {
            //int queriesRows = Convert.ToInt32(Console.ReadLine().Trim());

            //List<List<string>> queries = new List<List<string>>();

            //for (int i = 0; i < queriesRows; i++)
            //{
            //    queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
            //}
            //Solve(queries);
            Console.WriteLine(String.Join("\n", Solve(new List<List<string>>()
            {
                new List<string>() { "add", "hack" },
                new List<string>() {"add", "hackerrank" },
                new List<string>() {"find", "hac" },
                new List<string>() {"find", "hak"}
            })));//result - [2, 0]
            //Console.WriteLine(Solve("{[(])}"));//result - No
            //Console.WriteLine(Solve("{{[[(())]]}}"));//result - Yes

            Console.ReadLine();
        }

        public static List<int> Solve(List<List<string>> queries)
        {
            var result = new List<int>();
            var root = new TrieNode();
            foreach (var query in queries)
            {
                switch (query[0])
                {
                    case "add":
                        Add(query[1].ToCharArray(), root);
                        break;
                    case "find":
                        result.Add(FindPrefix(query[1].ToCharArray(), root));
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public static void Add(char[] chars, TrieNode root)
        {
            TrieNode tempRoot = root;
            for (int i = 0; i < chars.Count(); i++)
            {
                TrieNode newTrie;
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                    tempRoot.Count++;
                }
                else
                {
                    newTrie = new TrieNode();
                    tempRoot.children.Add(chars[i], newTrie);
                    tempRoot = newTrie;
                }
            }
        }

        public static int FindPrefix(char[] chars, TrieNode root)
        {
            TrieNode tempRoot = root;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                }
                else
                {
                    return 0;
                }
            }
            return tempRoot.Count;
        }
    }
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public int Count { get; set; } = 1;
    }
}
