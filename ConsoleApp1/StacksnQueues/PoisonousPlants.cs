using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StacksnQueues
{
    internal class PoisonousPlants
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve1(new List<int> { 4, 3, 7, 5, 6, 4, 2 }));//result - 3
            Console.WriteLine(Solve1(new List<int> { 3, 2, 5, 4 }));//result - 2
            Console.ReadLine();
        }

        public static int Solve1(List<int> p)
        {
            int[] days = new int[p.Count];
            int min = p[0];
            int max = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            for (int i = 1; i < p.Count; i++)
            {
                if(p[i] > p[i-1])
                {
                    Console.WriteLine($"{p[i]} is greater than {p[i - 1]}. So adding 1 to the day array");
                    days[i] = 1;
                }

                Console.WriteLine($"check current element {p[i]} is less than min {min}. If less then change min to current element ");
                min = Math.Min(min, p[i]);// min < p[i] ? min : p[i];
                Console.WriteLine($" While condition is top of the stack is {p[stack.Peek()]} >= to the current element {p[i]}");
                while (stack.Count > 0 && p[stack.Peek()] >= p[i])
                {
                    
                    if(p[i] > min)
                    {
                        Console.WriteLine($"If current element {p[i]} is greater than min - {min} then updates days array {days[i]} by getting max of " +
                            $"current element at days array  {days[i]} or index at the stack top element plus 1 {days[stack.Peek()]+1}");
                        
                        //days[i] = days[i] > days[stack.Peek()] + 1 ? days[i] : days[stack.Peek()] + 1;
                        days[i] = Math.Max(days[i], days[stack.Peek()]+1);
                    }
                    Console.WriteLine($" Pop the stack element {stack.Peek()} {p[stack.Peek()]}");
                    stack.Pop();
                }

                
                Console.WriteLine($"Update max by chekcing is the current max value {max} is maximum or value of current index in days array {days[i]}");
                //max = max > days[i] ? max : days[i];
                max = Math.Max(max, days[i]);

                Console.WriteLine($"Add current index to stack {i}. Element {p[i]}");
                stack.Push(i);
            }
            return max;
        }

        public static int Solve(List<int> p)
        {
            var result = 0;

            while (true)
            {
                var l = p.Count();
                var queues = new List<Queue<int>>();
                var newQueue = new Queue<int>();
                if (l > 0)
                {
                    newQueue.Enqueue(p[0]);
                }
                for (var i = 1; i < l; i++)
                {
                    if (p[i - 1] >= p[i])
                    {
                        newQueue.Enqueue(p[i]);
                    }
                    else
                    {
                        queues.Add(newQueue);
                        newQueue = new Queue<int>();
                        newQueue.Enqueue(p[i]);
                    }
                    if (i + 1 == l)
                    {
                        queues.Add(newQueue);
                    }
                }

                if (queues.Count() == 1)
                {
                    break;
                }
                //remove first element from queue
                for (int i = 1; i < queues.Count; i++)
                {
                    if (queues[i].Count > 0)
                    {
                        queues[i].Dequeue();
                    }
                }

                result++;
                //merge queues
                p.Clear();
                foreach (var queue in queues)
                {
                    while (queue.Count > 0)
                    {
                        p.Add(queue.Dequeue());
                    }
                }
            }
            return result;
        }
    }
}
