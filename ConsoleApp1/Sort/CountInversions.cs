using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CountInversions
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
            st.Start();
            //Console.WriteLine(Solve(new List<int>() { 1,1,1,2,2 }));
            Console.WriteLine(Solve(new List<int>() { 2,1,3,1,2}));
            st.Stop();
            Console.WriteLine(st.Elapsed.TotalSeconds);
            Console.ReadLine();
        }

        private static long Solve(List<int> arr)
        {
            return MergeSort(arr.ToArray());
        }

        private static long MergeSort(Span<int> arr)
        {
            long swaps = 0;
            var center = arr.Length / 2;
            if(arr.Length > 1)
            {
                swaps += MergeSort(arr.Slice(0, center));
                swaps += MergeSort(arr.Slice(center));
                swaps += Merge(arr, center);
            }
            return swaps;
        }

        private static long Merge(Span<int> arr, int startOfRightHalf)
        {
            long swaps = 0;
            var unsorted = arr.ToArray();
            var lhs = 0;
            var rhs = startOfRightHalf;
            var offset = 0;

            while(lhs < startOfRightHalf && rhs < unsorted.Length)
            {
                if(unsorted[lhs] <= unsorted[rhs])
                {
                    arr[offset++] = unsorted[lhs++];
                    //swaps++;
                }
                else
                {
                    arr[offset++] = unsorted[rhs++];
                    swaps++;
                }
            }
            while(lhs < startOfRightHalf)
            {
                arr[offset++] = unsorted[lhs++];
            }
            while (rhs < unsorted.Length)
            {
                arr[offset++] = unsorted[rhs++];
            }
            Print(arr.ToArray());
            return swaps;
        }

        //private static long Solve(List<int> arr)
        //{
        //    var aux = (int[])arr.ToArray().Clone(); 
        //    return MergeSort(arr.ToArray(), 0, arr.Count - 1, aux);
        //}

        private static long MergeSort(int[] arr, int left, int right, int[] aux)
        {
            long swaps = 0;
            if(left < right)
            {
                var mid = left + (right - left) / 2;
                swaps += MergeSort(aux, left, mid, arr);
                swaps += MergeSort(aux, mid + 1,right, arr);

                swaps += Merge(arr, left, mid, right, aux);
            }
            return swaps;
        }

        private static long Merge(int[]arr, int left, int mid, int right, int[] aux)
        {
            long swaps = 0;
            int i = left, j = mid + 1, k = left;
            while (i <= mid || j <= right)
            {
                if (i > mid)
                {
                    arr[k++] = aux[j++];
                }
                else if (j > right)
                {
                    arr[k++] = aux[i++];
                }
                else if (aux[i] <= aux[j])
                {
                    arr[k++] = aux[i++];
                }
                else
                {
                    arr[k++] = aux[j++];
                    swaps += mid + 1 - i;
                }
            }
            //Print(arr);
            return swaps;
        }

        private static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("\t" + arr[i]);
            }
            Console.WriteLine();
        }
    }
}
