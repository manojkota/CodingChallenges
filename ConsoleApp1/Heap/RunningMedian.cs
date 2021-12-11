using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Heap
{
    internal class RunningMedian
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(String.Join("\n", Solve(new List<int> { 12, 4, 5, 3, 8, 7 })));//Result - 12.0
//            8.0
//5.0
//4.5
//5.0
//6.0
            Console.ReadLine();
        }

        public static List<double> Solve(List<int> a)
        {
            double[] result = new double[a.Count()];
            Heap maxHeap = new Heap(new List<int>(), true);
            Heap minHeap = new Heap(new List<int>(), false);
            for (int i = 0; i < a.Count(); i++)
            {
                if (maxHeap.arr.Count == 0)
                {
                    maxHeap.Add(a[i]);
                }
                else if (maxHeap.arr.Count == minHeap.arr.Count)
                {
                    if (a[i] < minHeap.Peek())
                    {
                        maxHeap.Add(a[i]);
                    }
                    else
                    {
                        minHeap.Add(a[i]);
                        maxHeap.Add(minHeap.ExtractTop());
                    }
                }
                else if (maxHeap.arr.Count > minHeap.arr.Count)
                {
                    if (a[i] > maxHeap.Peek())
                    {
                        minHeap.Add(a[i]);
                    }
                    else
                    {
                        maxHeap.Add(a[i]);
                        minHeap.Add(maxHeap.ExtractTop());
                    }
                }

                result[i] = Median(maxHeap, minHeap);
            }

            return result.ToList();
        }

        static double Median(Heap maxHeap, Heap minHeap)
        {
            if (maxHeap.arr.Count == 0)
                return 0;
            else if (maxHeap.arr.Count == minHeap.arr.Count)
                return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
            else
                return maxHeap.Peek();
        }
    }

    public class Heap
    {
        public List<int> arr { get; set; }
        public bool isMax { get; set; }
        public Heap(List<int> arr, bool isMax)
        {
            this.arr = arr;
            this.isMax = isMax;
        }

        public void Add(int element)
        {
            arr.Add(element);
            int i = arr.Count / 2;
            while (i > 0)
            {
                Heapify(i);
                i = i / 2;
            }

            return;
        }

        public void Heapify(int index)
        {
            var left = 2 * index;
            var right = 2 * index + 1;

            int root = index;
            if (left <= arr.Count && Compare(arr[left - 1], arr[index - 1], isMax))
            {
                root = left;
            }

            if (right <= arr.Count && Compare(arr[right - 1], arr[root - 1], isMax))
            {
                root = right;
            }

            if (root != index)
            {
                int temp = arr[root - 1];
                arr[root - 1] = arr[index - 1];
                arr[index - 1] = temp;
                Heapify(root);
            }

            return;
        }

        public int ExtractTop()
        {
            int tmp = arr[0];
            arr[0] = arr[arr.Count - 1];
            arr.RemoveAt(arr.Count - 1);
            Heapify(1);
            return tmp;
        }

        public int Peek()
        {
            return arr[0];
        }

        public bool Compare(int a, int b, bool isMax)
        {
            if (isMax)
                return a > b;
            else
                return a < b;
        }
    }
}
