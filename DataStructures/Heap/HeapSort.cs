using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    class HeapSort
    {
        public void heapsort(int[] A, int n)
        {
            Heap h = new Heap();
            for (int i = 0; i < n; i++)
                h.insert(A[i]);
            int k = n - 1;
            for (int i = 0; i < n; i++)
            {
                A[k] = h.deletemax();
                k = k - 1;
            }
        }

        public void display(int[] A, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(A[i] + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            HeapSort s = new HeapSort();
            int[] A = { 63, 250, 835, 947, 651, 28 };
            Console.WriteLine("Original Array");
            s.display(A, 6);
            s.heapsort(A, 6);
            Console.WriteLine("Sorted Array");
            s.display(A, 6);
            Console.ReadKey();
        }
    }
}
