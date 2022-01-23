using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Heap
{
    public class Heap
    {
        public List<int> arr { get; set; }
        public bool isMax { get; set; }
        public Heap(List<int> arr, bool isMax)
        {
            this.arr = arr;
            this.isMax = isMax;
        }

        public int Size()
        {
            return arr.Count;
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
