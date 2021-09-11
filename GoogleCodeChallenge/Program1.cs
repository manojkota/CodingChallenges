using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeChallenge
{
    class Program1
    {
        static void Main1(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            
            var inputData = new List<List<int>>();
            //inputData.Add(new List<int>()
            //{
            //    3,4,11
            //});
            //inputData.Add(new List<int>()
            //{
            //    10, 9
            //});
            //inputData.Add(new List<int>()
            //{
            //    -1,6,7
            //});
            var count = 1;
            for (int i = 0; i < t * 3; i++)
            {
                inputData.Add(Console.ReadLine().Split(' ').ToList().Select(q => Convert.ToInt32(q)).ToList());
            }
            for (int i = 0; i < t*3; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    Execute(inputData, count);
                    count++;
                }
            }
            Console.ReadLine();
        }

        static void Execute(List<List<int>> input, int caseNo)
        {
            var result = 0;
            int[,,] lines = new int[3, 3, 3];
            for (int i = 0; i < input.Count; i++)
            {
                lines[i, i, 0] = input[i][0];
                lines[i, i, 1] = i == 1 ? 0 : input[i][1];
                lines[i, i, 2] = i == 1 ? input[i][1] : input[i][2];
            }
            var calBestValueFit = new List<int>();
            //calculate missing value
            calBestValueFit.Add((lines[0, 0, 0] + lines[2, 2, 2]) / 2);
            calBestValueFit.Add((lines[2, 2, 0] + lines[0, 0, 2]) / 2);
            calBestValueFit.Add((lines[1, 1, 0] + lines[1, 1, 2]) / 2);
            calBestValueFit.Add((lines[0, 0, 1] + lines[2, 2, 1]) / 2);
            
            var g = calBestValueFit.GroupBy(x => x);
            var bestValue = g.OrderByDescending(x => x.Count()).FirstOrDefault();
            lines[1,1,1] = bestValue.Key;
            result = bestValue.Count();

            //horizontal
            for (int i = 0; i < input.Count; i++)
            {
                if ((lines[i, i, 0] + lines[i, i, 2]) / 2 == lines[i, i, 1])
                {
                    result++;
                }
            }

            //vertical
            if ((lines[0, 0, 0] + lines[2, 2, 0]) / 2 == lines[1, 1, 0])
            {
                result++;
            }
            if ((lines[0, 0, 1] + lines[2, 1, 1]) / 2 == lines[1, 1, 1])
            {
                result++;
            }
            if ((lines[0, 0, 2] + lines[2, 2, 2]) / 2 == lines[1, 1, 2])
            {
                result++;
            }
                       

            Console.WriteLine($"Case #{caseNo}: {result}");
        }
    }
}
