using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StacksnQueues
{
    internal class MinMaxRiddle
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(",", Solve(new long[4] { 2, 6, 1, 12 })));//Result - 12 2 1 1
            Console.ReadLine();
        }

        static long[] Solve(long[] arr)
        {
            var tArr = arr.ToList();
            tArr.Add(-1);
            arr = tArr.ToArray();
            int l = arr.Length;
            int i = 0;
            var stack = new Stack<int>();
            var result = new long[l-1];
            while(i < l)
            {
                if(stack.Count == 0 || arr[i] > arr[stack.Peek()])
                {
                    stack.Push(i++);
                }
                else
                {
                    var val = arr[stack.Pop()];
                    var len = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    result[len - 1] = Math.Max(val, result[len - 1]);
                }
            }
            for (int k = l-3; k >= 0; --k)
            {
                result[k] = Math.Max(result[k], result[k + 1]);
            }
            return result;
        }

        static long[] riddle(long[] arr)
        {
            var l = arr.Length;
            var result = new long[l];
            var left = new int[l + 1];
            var right = new int[l + 1];
            var stack = new Stack<int>();

            for (var i = 0; i < l; i++)
            {
                while(stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }
                if(stack.Count > 0)
                {
                    left[i] = stack.Peek();
                }
                stack.Push(i);
            }
            while(stack.Count>0)
            {
                stack.Pop();
            }
            for (var i = l-1; i >= 0; i--)
            {
                while (stack.Count > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    right[i] = stack.Peek();
                }
                stack.Push(i);
            }

            var ans = new long[l + 1];
            for (var i = 0;i < l;i++)
            {
                int len = right[i] - left[i] -1;
                ans[len] = Math.Max(len >=0 ? ans[len] : 0, arr[i]);
            }

            for (var i = l-1; i >=1; i--)
            {
                ans[i] = Math.Max(arr[i+1], arr[i]);
            }

            for (int i = 1; i <= l; i++)
            {
                result[i - 1] = ans[i];
            }


            //Bruteforce
            // for(var s = 1; s <= l; s++)
            // {
            //     var comparisions = new List<long>();
            //     for(var i =0; i< l; i++)
            //     {
            //         if(s + i <= l)
            //         {
            //             var subArray = arr.Skip(i).Take(s);
            //             comparisions.Add(subArray.Min());
            //         }
            //     }
            //     result.Add(comparisions.Max());
            // }
            return result.ToArray();
        }
    }
}
