using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class RottingOranges
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OrangesRotting(new int[3][]{ new int[3]{ 2,1,1}, new int[3] { 1,1,0},new int[3] { 0,1,1} }));//OP - 4
            Console.ReadLine();
        }

        static int OrangesRotting(int[][] grid)
        {
            Queue<(int, int)> q = new Queue<(int, int)>();
            var m = grid.Length;
            var n = grid[0].Length;
            var freshOranges = 0;
            //Add rotten to the queue
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        q.Enqueue((i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshOranges++;
                    }
                }
            }

            var minutes = 0;
            //proces the queue.
            while (q.Count > 0)
            {
                var queueSize = q.Count;
                for (var k = 0; k < queueSize; k++)
                {
                    var item = q.Dequeue();
                    var x = item.Item1;
                    var y = item.Item2;
                    //top
                    if (x - 1 >= 0 && grid[x - 1][y] == 1)
                    {
                        grid[x - 1][y] = 2;
                        q.Enqueue((x - 1, y));
                        freshOranges--;
                    }
                    //left
                    if (y - 1 >= 0 && grid[x][y - 1] == 1)
                    {
                        grid[x][y - 1] = 2;
                        q.Enqueue((x, y - 1));
                        freshOranges--;
                    }
                    //right
                    if (y + 1 < n && grid[x][y + 1] == 1)
                    {
                        grid[x][y + 1] = 2;
                        q.Enqueue((x, y + 1));
                        freshOranges--;
                    }
                    //bottom
                    if (x + 1 < m && grid[x + 1][y] == 1)
                    {
                        grid[x + 1][y] = 2;
                        q.Enqueue((x + 1, y));
                        freshOranges--;
                    }
                }
                if (q.Count > 0)
                {
                    minutes++;
                }
            }
            return freshOranges == 0 ? minutes : -1;
        }
    }
}
