using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    class LinearSearch
    {
        public int linearsearch(int[] A, int n, int key)
        {
            int index = 0;
            while (index < n)
            {
                if (A[index] == key)
                    return index;
                index = index + 1;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            LinearSearch s = new LinearSearch();
            int[] A = { 84, 21, 47, 96, 15 };
            int found = s.linearsearch(A, 5, 100);
            Console.WriteLine("Result: " + found);
            Console.ReadKey();
        }
    }
}
