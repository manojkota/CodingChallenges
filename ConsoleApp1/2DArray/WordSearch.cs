using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class WordSearch
    {
        static void Main(string[] args)
        {
            var input = new char[3][];
            input[0] = new char[4] { 'A', 'B', 'C', 'E' };
            input[1] = new char[4] { 'S', 'F', 'C', 'S' };
            input[2] = new char[4] { 'A', 'D', 'E', 'E' };
            Console.WriteLine(Exist(input, "ABCCED"));
            Console.ReadLine();
        }

        static int Rows;
        static int Cols;
        static char[][] inputBoard;

        public static bool Exist(char[][] board, string word)
        {
            inputBoard = board;
            Rows = board.Length;
            Cols = board[0].Length;

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                {
                    if(Search(i, j, word, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool Search(int row, int col, string word, int index)
        {
            /* Step 1). check the bottom case. */
            if (index >= word.Length)
                return true;

            /* Step 2). Check the boundaries. */
            if (row < 0 || row == Rows || col < 0 || col == Cols
                || inputBoard[row][col] != word[index])
                return false;

            /* Step 3). explore the neighbors in DFS */
            // mark the path before the next exploration
            inputBoard[row][col] = '#';

            int[] rowOffsets = { 0, 1, 0, -1 };
            int[] colOffsets = { 1, 0, -1, 0 };
            for (int d = 0; d < 4; ++d)
            {
                if (Search(row + rowOffsets[d], col + colOffsets[d], word, index + 1))
                    // return without cleanup
                    return true;
            }

            /* Step 4). clean up and return the result. */
            inputBoard[row][col] = word[index];
            return false;
        }

    }
}
