using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    /// <summary>
    /// Implement a function that turns revealed cells into -2 given a location the user wants to click. 
    /// For simplicity, only reveal cells that have 0 in them. 
    /// If the user clicks on any other type of cell (for example, -1 / bomb or 1, 2, or 3), just ignore the click and return the original field. If a user clicks 0, reveal allother 0's that are connected to it. 
    /// Example 1: Given field: [[0, 0, 0, 0, 0], [0, 1, 1, 1, 0], [0, 1, -1, 1, 0]] 
    /// Click location:(2, 2:row index = 2, column index = 2) Resulting field: [[0, 0, 0, 0, 0], [0, 1, 1, 1, 0], [0, 1, -1, 1, 0]](same as the given field) 
    /// Example 2: Given field: [[-1, 1, 0, 0], [1, 1, 0, 0], [0, 0, 1, 1], [0, 0, 1, -1]] Click location:(1, 3:row index = 1, column index = 3) Resulting field: [[-1, 1, -2, -2], [1, 1, -2, -2], [-2, -2, 1, 1], [-2, -2, 1, -1]] 
    /// Your function should take: field: The given field as a 2D arraynum_rows / numRows: The number of rowsin the given field num_cols / numCols:The number of columns in the given fieldgiven_i / givenI:The row index of the cell the user wants to clickgiven_j/ givenJ:Thecolumnindex of the cell the user wants to click
    /// </summary>
    internal class Minesweeper_Expanding
    {
        static void Main(string[] args)
        {
            int n = 3, m = 5;
            var input = new int[n, m];
            input[1,1] = 1;
            input[1, 2] = 1;
            input[1, 3] = 1;
            input[2, 1] = 1;
            input[2, 2] = -1;
            input[2, 3] = 1;
            Solve(input, n, m, 0, 1);
            Console.ReadLine();
        }

        static void Solve(int[,] input, int n, int m, int given_i, int given_j)
        {
            var q = new Queue<(int, int)>();
            q.Enqueue((given_i, given_j));
            while(q.Count > 0)
            {
                var curr_indexes = q.Dequeue();

                for (int i = curr_indexes.Item1 - 1; i < curr_indexes.Item1 + 2; i++)
                {
                    for (int j = curr_indexes.Item2 - 1; j < curr_indexes.Item2 + 2; j++)
                    {
                        if(0 <= i && i < n && 0 <= j && j < m && input[i, j] == 0)
                        {
                            input[i, j] = -2;
                            q.Enqueue((i, j));
                        }
                    }
                }
            }

            Print(input, n, m);
        }

        static void Print(int[,] input, int n, int m)
        {
            //Print array
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(input[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
