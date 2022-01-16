using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class NumberOfIslands
    {
        static void Main(string[] args)
        {
            var input = new char[4][];
            input[0] = new char[5] { '1', '1', '1', '1', '0' };
            input[1] = new char[5] { '1', '1', '0', '1', '0' };
            input[2] = new char[5] { '1', '1', '0', '0', '0' };
            input[3] = new char[5] { '0', '0', '0', '0', '0' };
            Console.WriteLine(NumIslands(input));
            Console.ReadLine();
        }

        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            var nr = grid.Length;
            var nc = grid[0].Length;



            var noOfIslands = 0;
            for (var r = 0; r < nr; r++)
            {
                for (var c = 0; c < nc; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        ++noOfIslands;
                        grid[r][c] = '0';

                        Queue<int> neighbors = new Queue<int>();
                        neighbors.Enqueue(r * nc + c);
                        while (neighbors.Count > 0)
                        {
                            int id = neighbors.Dequeue();
                            int row = id / nc;
                            int col = id % nc;
                            if (row - 1 >= 0 && grid[row - 1][col] == '1')
                            {
                                neighbors.Enqueue((row - 1) * nc + col);
                                grid[row - 1][col] = '0';
                            }
                            if (row + 1 < nr && grid[row + 1][col] == '1')
                            {
                                neighbors.Enqueue((row + 1) * nc + col);
                                grid[row + 1][col] = '0';
                            }
                            if (col - 1 >= 0 && grid[row][col - 1] == '1')
                            {
                                neighbors.Enqueue(row * nc + col - 1);
                                grid[row][col - 1] = '0';
                            }
                            if (col + 1 < nc && grid[row][col + 1] == '1')
                            {
                                neighbors.Enqueue(row * nc + col + 1);
                                grid[row][col + 1] = '0';
                            }
                        }
                    }
                }
            }
            return noOfIslands;


        }
    }
}
