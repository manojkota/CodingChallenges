using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Heap
{
    internal class Minimum_Cost_to_Connect_Sticks
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ConnectSticks(new int[3] { 2,4,3}));//OP - 14
            Console.ReadLine();

        }
        static int ConnectSticks(int[] sticks)
        {
            if (sticks.Length <= 1)
            {
                return 0;
            }

            var heap = new Heap(new List<int>(), false);
            foreach (int i in sticks)
            {
                heap.Add(i);
            }

            int minCost = 0;
            while (heap.Size() >= 2)
            {
                int first = heap.ExtractTop();
                int next = heap.ExtractTop();
                int combined = first + next;
                minCost += combined;
                heap.Add(combined);
            }
            return minCost;
        }
    }
}
