using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    class HashChain
    {
        int hashtablesize;
        HashingLinkedList[] hashtable;

        public HashChain()
        {
            hashtablesize = 10;
            hashtable = new HashingLinkedList[hashtablesize];
            for (int i = 0; i < hashtablesize; i++)
                hashtable[i] = new HashingLinkedList();
        }

        public int hashcode(int key)
        {
            return key % hashtablesize;
        }

        public void insert(int element)
        {
            int i = hashcode(element);
            hashtable[i].insertsorted(element);
        }

        public bool search(int key)
        {
            int i = hashcode(key);
            return hashtable[i].search(key) != -1;
        }

        public void display()
        {
            for (int i = 0; i < hashtablesize; i++)
            {
                Console.Write("[" + i + "]");
                hashtable[i].display();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            HashChain h = new HashChain();
            h.insert(54);
            h.insert(78);
            h.insert(64);
            h.insert(92);
            h.insert(34);
            h.insert(86);
            h.insert(28);
            h.display();
            Console.WriteLine("Element Found: " + h.search(44));
            Console.ReadKey();
        }
    }
}
