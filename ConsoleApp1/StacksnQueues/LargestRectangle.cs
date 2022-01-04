using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StacksnQueues
{
    internal class LargestRectangle
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(new List<int> { 3, 2, 3 }));// Result - 6
            Console.ReadLine();
        }

        public static long Solve(List<int> h)
        {
            var max = 0;
            Stack<int> iStack = new Stack<int>();
            Stack<int> hStack = new Stack<int>();
            h.Add(0);

            for (int i =0; i< h.Count; i++)
            {
                var lastPeekIndex = int.MaxValue;
                while(hStack.Count != 0 &&  hStack.Peek() > h[i])
                {
                    lastPeekIndex = iStack.Peek();
                    var currentArea = (i - iStack.Pop()) * hStack.Pop();
                    max = Math.Max(max, currentArea);
                }
                if(hStack.Count == 0 || hStack.Peek() < h[i])
                {
                    hStack.Push(h[i]);
                    iStack.Push(Math.Min(lastPeekIndex, i));
                }
            }
            return max;
        }
    }
}
