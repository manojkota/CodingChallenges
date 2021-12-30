using System.Linq;

namespace ConsoleApp1
{
    public static class MinSwapsTwo
    {
        static void swap(int a, int b, int[] arr)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public static int Execute(int[] arr)
        {
            var swaps = 0;
            int lastMatchedIndex = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i + 1)
                {
                    swap(i, arr[i] - 1, arr);
                    swaps++;
                    i = lastMatchedIndex > -1 ? lastMatchedIndex - 1 : -1;
                }
                else
                {
                    lastMatchedIndex = i;
                }
            }
            
            return swaps;
        }
    }
}
