using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedLists
{
    internal class LeastRecentlyUsedCache
    {
        static void Main(string[] args)
        {
            var cc = new LRUCache(2);
            cc.Put(1, 1);
            cc.Put(2, 2);
            Console.WriteLine(cc.Get(1));
            cc.Put(3, 3);
            Console.WriteLine(cc.Get(2));
            cc.Put(4, 4);
            Console.WriteLine(cc.Get(1));
            Console.WriteLine(cc.Get(3));
            Console.WriteLine(cc.Get(4));


            //cc = new LRUCache(2);
            //cc.Put(2, 1);
            //cc.Put(2, 2);
            //Console.WriteLine( cc.Get(2));
            Console.ReadLine();
        }

        public class LRUCache
        {

            public class Cache
            {
                public int Data { get; set; }
                public DateTime IndexOnList { get; set; }
            }
            protected Dictionary<int, Cache> dict = new Dictionary<int, Cache>();

            protected SortedDictionary<DateTime, int> list = new SortedDictionary<DateTime, int>();
            protected int CacheCapacity = 0;

            public LRUCache(int capacity)
            {
                CacheCapacity = capacity;
            }

            public int Get(int key)
            {
                if (dict.ContainsKey(key))
                {
                    list.Remove(dict[key].IndexOnList);
                    var dateTime = DateTime.UtcNow;
                    list.Add(dateTime, key);
                    dict[key].IndexOnList = dateTime;
                    return dict[key].Data;
                }
                else
                {
                    return -1;
                }
            }

            public void Put(int key, int value)
            {
                if (dict.ContainsKey(key))
                {
                    list.Remove(dict[key].IndexOnList);
                }
                else
                {
                    if (dict.Count >= CacheCapacity)
                    {
                        var firstList = list.First();
                        dict.Remove(firstList.Value);
                        list.Remove(firstList.Key);
                    }
                    dict.Add(key, new Cache());
                }
                var dateTime = DateTime.UtcNow;
                list.Add(dateTime, key);
                dict[key].IndexOnList = dateTime;
                dict[key].Data = value;

            }

        }
    }
}
