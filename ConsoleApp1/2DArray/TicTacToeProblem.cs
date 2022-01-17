using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    internal class TicTacToeProblem
    {
        public static void Main(string[] args)
        {
            var t = new TicTacToe(3);
            Console.WriteLine(t.Move(0, 0, 1));
            Console.WriteLine(t.Move(0, 2, 2));
            Console.WriteLine(t.Move(2, 2, 1));
            Console.WriteLine(t.Move(1, 1, 2));
            Console.WriteLine(t.Move(2, 0, 1));
            Console.WriteLine(t.Move(1, 0, 2));
            Console.WriteLine(t.Move(2, 1, 1));
            Console.ReadLine();
        }

        public class TicTacToe
        {

            int[] rows;
            int[] cols;
            int diagonal;
            int antiDiagonal;

            public TicTacToe(int n)
            {
                rows = new int[n];
                cols = new int[n];
            }

            public int Move(int row, int col, int player)
            {
                int currentPlayer = (player == 1) ? 1 : -1;

                //update rows & cols
                rows[row] += currentPlayer;
                cols[col] += currentPlayer;

                //update diagonal
                if (row == col)
                {
                    diagonal += currentPlayer;
                }

                //update anto-diagonal
                if (col == (cols.Length - row - 1))
                {
                    antiDiagonal += currentPlayer;
                }

                int n = rows.Length;

                //check if current player wins
                if (Math.Abs(rows[row]) == n
                  || Math.Abs(cols[col]) == n
                  || Math.Abs(diagonal) == n
                  || Math.Abs(antiDiagonal) == n)
                {
                    return player;
                }

                //No one wins
                return 0;
            }
        }
    }
}
