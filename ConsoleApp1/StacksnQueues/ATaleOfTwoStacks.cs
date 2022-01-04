using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StacksnQueues
{
    internal class ATaleOfTwoStacks
    {
        static Stack<int> stackNewstOnTop = new Stack<int>();
        static Stack<int> stackOldestOnTop = new Stack<int>();
        
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 0; i < t; i++)
            {
                var query = Console.ReadLine().Trim().Split(' ');
                switch (Convert.ToInt32(query[0]))
                {
                    case 1:
                        Put(Convert.ToInt32(query[1]));
                        break;
                    case 2:
                        Pop();
                        break;
                    case 3:
                        Console.WriteLine(Peek());
                        break;
                }
            }
            Console.ReadLine();
        }

        static void Pop()
        {
            var isStackOldestEmpty = stackOldestOnTop.Count == 0;

            if (isStackOldestEmpty)
            {
                while (stackNewstOnTop.Count > 0)
                {
                    stackOldestOnTop.Push(stackNewstOnTop.Pop());
                }
            }

            stackOldestOnTop.Pop();
        }

        static void Put(int value)
        {
            stackNewstOnTop.Push(value);
        }

        static int Peek()
        {
            var isStackOldestEmpty = stackOldestOnTop.Count == 0;

            if (isStackOldestEmpty)
            {
                while (stackNewstOnTop.Count > 0)
                {
                    stackOldestOnTop.Push(stackNewstOnTop.Pop());
                }
            }

            return stackOldestOnTop.Peek();
        }
    }
}
