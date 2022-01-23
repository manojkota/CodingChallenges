using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class Shortest_Path_to_Get_Food
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetFood(new char[4][]
            {
                new char[]{ 'X', 'X', 'X', 'X', 'X', 'X' },
                new char[]{ 'X', '*', 'O', 'O', 'O', 'X' },
                new char[]{ 'X', 'O', 'O', '#', 'O', 'X' },
                new char[]{ 'X', 'X', 'X', 'X', 'X', 'X' },

            }));//OP - 3
            Console.ReadLine();
        }

        static int GetFood(char[][] grid)
        {
            //find users location
            var m = grid.Length;
            var n = grid[0].Length;
            (int, int) current = (0, 0);
            var q = new Queue<(int, int)>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '*')
                    {
                        current = (i, j);
                        q.Enqueue(current);
                        break;
                    }
                }
                if (q.Count > 0)
                {
                    break;
                }
            }

            var directions = new int[4][]{
            new int[]{-1,0},//top
        new int[]{1,0},//down
        new int[]{0,-1},//left
        new int[]{0,1}};//right


            var foodFound = false;
            var steps = 1;
            while (q.Count > 0)
            {
                var queueSize = q.Count;
                for (int k = 0; k < queueSize; k++)
                {
                    var item = q.Dequeue();

                    foreach (var dir in directions)
                    {
                        var x = item.Item1 + dir[0];
                        var y = item.Item2 + dir[1];

                        if (!(x >= 0 && x < m && y >= 0 && y < n))
                        {
                            continue;
                        }
                        if (grid[x][y] == '#')
                        {

                            foodFound = true;
                            break;
                        }
                        else if (grid[x][y] == 'O')
                        {
                            q.Enqueue((x, y));
                            grid[x][y] = 'v';

                        }
                    }
                    if (foodFound)
                    {
                        break;
                    }
                }
                if (foodFound)
                {
                    break;
                }
                steps++;
            }


            return foodFound ? steps : -1;
        }
    }
}
