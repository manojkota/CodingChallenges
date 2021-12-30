using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    
    public class HourGlassProblem
    {

        // Complete the hourglassSum function below.
        static int hourglassSum(int[][] arr)
        {
            var rowLength = arr.Length;
            var finalValue = -99999;
            for (int i = 0; i < rowLength; i++)
            {
                if (i + 2 >= rowLength)
                {
                    break;
                }
                var colLength = arr[i].Length;
                for (int j = 0; j < colLength; j++)
                {
                    if (j + 2 >= colLength)
                    {
                        break;
                    }
                    var temp = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (temp > finalValue)
                    {
                        finalValue = temp;
                    }
                }

            }
            return finalValue;
        }

        public static void Execute(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(args[i].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);
            Console.WriteLine(result);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }

}
