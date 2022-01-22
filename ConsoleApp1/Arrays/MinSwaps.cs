using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Arrays
{
    internal class MinSwaps
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(new int[5] { 1, 0, 1, 0, 1 }));//OP - 1
            Console.ReadLine();
        }

        static int Solve(int[] data)
        {
            var windowSize = data.Count(x => x == 1);

            if (windowSize <= 1)
            {
                return 0;
            }

            var currOnes = 0;
            var maxOnes = 0;
            for (int i = 0; i < data.Length; i++)
            {
                currOnes += data[i];
                if (i >= windowSize)
                {
                    currOnes -= data[i - windowSize];
                }
                maxOnes = Math.Max(maxOnes, currOnes);
            }

            return windowSize - maxOnes;

        }
    }
}
