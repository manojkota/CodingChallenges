using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2DArray
{
    /// <summary>
    /// A2-dimensional array is an array of arrays. 
    /// Implement a function that takes asquare2D array (#columns = #rows) and rotates it by 90 degrees. 
    /// Example: [[1, 2, 3], [4, 5, 6], [7, 8, 9]] - [[7, 4, 1], [8, 5, 2], [9, 6, 3]] When you are done,tryimplementing this function so that you can solve this problemin place.Solving itin placemeans thatyour functionwon't create a new array to solve this problem. 
    /// Instead, modify the content of the given array with O(1)extra space.
    /// </summary>
    internal class MatrixRotation
    {
        static void Main(string[] args)
        {
            var k = 4;
            var input = new int[k, k];
            var ini = 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    input[i, j] = ini;
                    ini++;
                }
            }

            Console.WriteLine("input");
            Print(input, k);
            Console.WriteLine("output by new array");
            SolveByNewArray(input, k);
            Console.WriteLine("output by InPlace");
            SolveByInPlace(input, k);
            Console.ReadLine();
        }

        static void SolveByNewArray(int[,] input, int n)
        {
            var newArray = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var new_j = (n - i - 1);
                for (int j = 0; j < n; j++)
                {
                    newArray[j, new_j] = input[i, j];
                }
            }
            Print(newArray, n);
        }

        static void SolveByInPlace(int[,] input, int n)
        {
            for (int i = 0; i < Math.Floor((n * 1.0) / 2); i++)
            {
                for (int j = 0; j < Math.Ceiling((n * 1.0) / 2); j++)
                {
                    var current_i = i;
                    var current_j = j;
                    var temp = new int[4];
                    for (int k = 0; k < 4; k++)
                    {
                        temp[k] = input[current_i, current_j];
                        var newIndexes = RotateIndex(current_i, current_j, n);
                        current_i = newIndexes.Item1;
                        current_j = newIndexes.Item2;
                    }
                    for (int k = 0; k < 4; k++)
                    {
                        input[current_i, current_j] = temp[(k + 3) % 4];
                        var newIndexes = RotateIndex(current_i, current_j, n);
                        current_i = newIndexes.Item1;
                        current_j = newIndexes.Item2;
                    }
                }
            }


            ///using dictionary
            //var dict = new Dictionary<Tuple<int, int>, int>();
            //for (int i = 0; i < n; i++)
            //{
            //    var new_j = (n - i - 1);
            //    for (int j = 0; j < n; j++)
            //    {
            //        if (!dict.ContainsKey(new Tuple<int, int>(j, new_j)))
            //        {
            //            dict.Add(new Tuple<int, int>(j, new_j), input[j, new_j]);
            //        }

            //        if(dict.ContainsKey(new Tuple<int, int>(i, j)))
            //        {
            //            input[j, new_j] = dict[new Tuple<int, int>(i, j)];
            //            dict.Remove(new Tuple<int, int>(i, j));
            //        }
            //        else
            //        {
            //            input[j, new_j] = input[i, j];
            //        }
            //    }
            //}
            Print(input, n);
        }

        static Tuple<int, int> RotateIndex(int i, int j, int n)
        {
            return new Tuple<int, int>(j, n - 1 - i);
        }

        static void Print(int[,] input, int k)
        {
            //Print array
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write(input[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
