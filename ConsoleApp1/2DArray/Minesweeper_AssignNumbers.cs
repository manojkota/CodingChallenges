using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    /// <summary>
    /// Just in case you're not familiar with it, Minesweeper is a video game in which you need to clear the

    //given field while avoiding mines or bombs.

    //When you see a number in the cell, for example, three right here, that means that there are three
    

    //bombs in the surrounding cells, in this case, this location and these two cells.

    //When you click on one of them, you lose.


    //And here's the problem, you need to write a function called Minesweeper, which will take three arguments.


    //The first of those is going to be bombs, which shows a list of bomb locations, and the second one
    

    //and the third one will be the number of rows and the number of columns in a field.


    //For example, you might be given these arguments.


    //This shows that there is a bomb at zero zero zero zero and Colma index zero and zero one another, bomb

    //at zero one or going zero and column index one.

    //In the bombs, arguments assume that there is no duplicates, so once you see zero zero, you won't


    //see the same location again.

    //And because Nimroz is three and I'm called is four here, the field will have three rows and four columns.


    //You need to take these arguments and return the resulting field, which is represented as a two dimensional

    //array of integers.


    //For example, given these particular arguments, you should return this array.

    //Each bomb is represented as minus one.


    //As you can see, there's a bomb at zero zero and there is another one at zero one, the number two here


    //says that there are two bombs in the surrounding cells.

    //Which are these ones?


    //And the No one here says that there's only one bomb in the surrounding cells, it's this one.

    //You see a bunch of zeros here because there are no bombs in the surrounding cells for those cells.


    //As usual, try solving this problem on your own before going to the next video.


    //Feel free to use one of the coding exercises as well.
    /// </summary>
    internal class Minesweeper_AssignNumbers
    {
        static void Main(string[] args)
        {
            Solve(new List<(int bi, int bj)>() { (0, 0), (0, 1) }, 3, 4);
            Console.ReadLine();
        }

        static void Solve(List<(int bi, int bj)> bombs, int n, int m)
        {
            var arr = new int[n, m];
            foreach (var bomb in bombs)
            {
                arr[bomb.bi, bomb.bj] = -1;
                for (int i = bomb.bi - 1; i < bomb.bi + 2; i++)
                {
                    for (int j = bomb.bj -1; j < bomb.bj + 2; j++)
                    {
                        if (0 <= i && i < n && 0 <= j && j< m && arr[i,j] != -1)
                        {
                            arr[i, j] = arr[i, j] + 1;
                        }
                    }
                }
            }
            Print(arr, n, m);
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
