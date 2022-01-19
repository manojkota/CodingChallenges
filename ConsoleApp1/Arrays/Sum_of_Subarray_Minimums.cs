using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    internal class Sum_of_Subarray_Minimums
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumSubarrayMins(new int[] {3,1,2,4 }));//result - 17
            Console.ReadLine();
        }

		static int SumSubarrayMins(int[] arr)
		{
			var mod = 1e9 + 7;
			var n = arr.Length;
			var smallToLeft = Enumerable.Repeat(-1, n).ToArray(); //TRack next smaller index to the left
			var smallToRight = Enumerable.Repeat(n, n).ToArray(); //TRack next smaller index to the right

			var stack = new Stack<int>(); //Just track the index. This strictly stores indexes with non-decreasing values
			for (int i = 0; i < n; i++)
			{
				while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
				{ //If val at top index is > arr[i], top's small to right is "i". Repeat this
					var top = stack.Pop();
					smallToRight[top] = i;
				}
				if (stack.Count > 0) smallToLeft[i] = stack.Peek(); //If there is a top index, it will be i's small to the left.
				stack.Push(i);
			}

			long result = 0;
			for (int i = 0; i < n; i++)
			{
				result = (result + (long)arr[i] * (i - smallToLeft[i]) * (smallToRight[i] - i));
			} //https://lh3.googleusercontent.com/-GyygvrTJ3GY/XRlvmDTxEHI/AAAAAAAAO4E/yDc-Xvo3isgM8QFOSiVp6yUK_j9E8cwGACK8BGAs/s0/2019-06-30.jpg          
			return Convert.ToInt32(result % mod);
		}

		static int DP(int[] arr)
        {
            var mod = 1e9 + 7;
            long sum = 0;
            var l = arr.Length;
            var matrix = new int[l, l];

            for (int i = 0; i < l; i++)
            {
                matrix[i, i] = arr[i];
                sum += arr[i];
            }


            for (int k = 2; k <= l; k++)
            {
                for (int i = 0; i < l - k + 1; i++)
                {
                    var j = i + k - 1;
                    matrix[i, j] = Math.Min(matrix[i, j - 1], matrix[i + 1, j]);
                    sum += matrix[i, j];
                }
            }
            return Convert.ToInt32(sum % mod);
        }
	}
}
