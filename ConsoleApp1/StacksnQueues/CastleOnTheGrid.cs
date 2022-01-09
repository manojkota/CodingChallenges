using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StacksnQueues
{
    internal class CastleOnTheGrid
    {
        static void Main(string[] args)
        {
            Console.WriteLine(minimumMoves(new List<string>()
            {
                ".X.",
                ".X.",
                "..."
            },0,0,0,2));//Result - 3
            Console.ReadLine();
        }

        public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
        {
            var result = 0;
            var l = grid.Count();
            var cMatrix = new char[l, l];
            var preDesMatrix = new (int, int)[l, l];


            //Build colour matrix
            for (int i = 0; i < l; i++)
            {
                var chArray = grid[i].ToCharArray();
                for (var c = 0; c < chArray.Length; c++)
                {
                    cMatrix[i, c] = chArray[c] == '.' ? 'W' : 'X';
                    preDesMatrix[i, c] = (-1, -1);
                }
            }

            var queue = new Queue<(int, int)>();
            queue.Enqueue((startX, startY));
            var goalReached = false;
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                cMatrix[item.Item1, item.Item2] = 'R';

                // same row -- move column
                var row = item.Item1;
                var col = item.Item2;
                //Increment column
                while (col < l)
                {
                    if (cMatrix[row, col] == 'W')
                    {
                        cMatrix[row, col] = 'G';
                        queue.Enqueue((row, col));
                        preDesMatrix[row, col] = (item.Item1, item.Item2);
                        if (row == goalX && col == goalY)
                        {
                            goalReached = true;
                            break;
                        }
                    }
                    else if (cMatrix[row, col] == 'X')
                    {
                        break;
                    }

                    col++;
                }
                if (goalReached)
                {
                    break;
                }
                //decrement column
                row = item.Item1;
                col = item.Item2;
                while (col >= 0)
                {
                    if (cMatrix[row, col] == 'W')
                    {
                        cMatrix[row, col] = 'G';
                        queue.Enqueue((row, col));
                        preDesMatrix[row, col] = (item.Item1, item.Item2);
                        if (row == goalX && col == goalY)
                        {
                            goalReached = true;
                            break;
                        }
                    }
                    else if (cMatrix[row, col] == 'X')
                    {
                        break;
                    }
                    col--;
                }
                if (goalReached)
                {
                    break;
                }
                //Now keep column constant and move row
                //Increment row
                row = item.Item1;
                col = item.Item2;
                while (row < l)
                {
                    if (cMatrix[row, col] == 'W')
                    {
                        cMatrix[row, col] = 'G';
                        queue.Enqueue((row, col));
                        preDesMatrix[row, col] = (item.Item1, item.Item2);
                        if (row == goalX && col == goalY)
                        {
                            goalReached = true;
                            break;
                        }
                    }
                    else if (cMatrix[row, col] == 'X')
                    {
                        break;
                    }
                    row++;
                }
                if (goalReached)
                {
                    break;
                }
                //decrement row
                row = item.Item1;
                col = item.Item2;
                while (row >= 0)
                {
                    if (cMatrix[row, col] == 'W')
                    {
                        cMatrix[row, col] = 'G';
                        queue.Enqueue((row, col));
                        preDesMatrix[row, col] = (item.Item1, item.Item2);
                        if (row == goalX && col == goalY)
                        {
                            goalReached = true;
                            break;
                        }
                    }
                    else if (cMatrix[row, col] == 'X')
                    {
                        break;
                    }
                    row--;
                }
            }

            //create a stack and put the values of predecessors in stack
            var stack = new Stack<(int, int)>();
            (int Item1, int Item2) val = (goalX, goalY);
            while (val.Item2 != -1 && val.Item1 != -1)
            {
                stack.Push((val.Item1, val.Item2));
                val = preDesMatrix[val.Item1, val.Item2];
            }
            return stack.Count - 1;
        }
    }
}
