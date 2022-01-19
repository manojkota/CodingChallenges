using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class SnakeAndLadders
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            
        }

        public class Solution
        {

            int size;
            int target;
            public int SnakesAndLadders(int[][] board)
            {

                size = board.Length;
                target = size * size;

                var queue = new Queue<int>();

                queue.Enqueue(0);

                var visited = new bool[target];
                visited[0] = true;

                int step = 0;
                while (queue.Count > 0)
                {
                    int queueSize = queue.Count;

                    for (int i = 0; i < queueSize; i++)
                    {
                        int previousLabel = queue.Dequeue();

                        if (previousLabel == this.target)
                        {
                            return step;
                        }

                        for (int currentLabel = previousLabel + 1; currentLabel <= Math.Min(this.target, previousLabel + 6); currentLabel++)
                        {

                            if (visited[currentLabel - 1])
                            {
                                continue;
                            }

                            visited[currentLabel - 1] = true;

                            int[] position = indexToPosition(currentLabel);


                            if (board[position[0]][position[1]] == -1)
                            {
                                queue.Enqueue(currentLabel);
                            }
                            else
                            {
                                queue.Enqueue(board[position[0]][position[1]]);
                            }

                        }
                    }

                    step++;
                }
                return -1;
            }

            public int[] indexToPosition(int index)
            {
                int vertical = this.size - 1 -((index - 1) / this.size);
                int horizontal;
                if ((this.size - vertical) % 2 == 1)
                {
                    horizontal = (index - 1) % this.size;
                }
                else
                {
                    horizontal = this.size - 1 - ((index - 1) % this.size);
                }

                return new int[] { vertical, horizontal };
            }

        }
    }
}
