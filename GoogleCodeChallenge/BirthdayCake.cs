using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeChallenge
{
    public class BirthdayCake
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            var inputData = new List<List<int>>();
            var rectagleData = new List<List<int>>();
            var count = 1;
            var caseInputLines = 2;
            for (int i = 0; i < t * caseInputLines; i++)
            {
                if (count == 1)
                {
                    inputData.Add(Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList());
                    count++;
                }
                else if(count == 2)
                {
                    rectagleData.Add(Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList());
                    count = 1;
                }
            }

            for (int i = 0; i < inputData.Count; i++)
            {
                Execute(i+1, inputData[i], rectagleData[i]);
            }
            Console.ReadLine();
        }

        static void Execute(int caseNo, List<int> caseData, List<int> rectData)
        {
            int n = caseData[0], m = caseData[1], k = caseData[2];
            int r1 = rectData[0], c1 = rectData[1], r2 = rectData[2], c2 = rectData[3];

            //If bottom-right corner row value equals row number
            if (r2 == n)
            {
                int nr2 = n + 1 - r2;
                int nr1 = n + 1 - r1;
                r1 = nr2; r2 = nr1;
            }
            //If bottom-right corner column value equals column number
            if (c2 == m)
            {
                int nc2 = m + 1 - c2;
                int nc1 = m + 1 - c1;
                c1 = nc2; c2 = nc1;
            }
            long min = long.MaxValue;

            //if top-left is greater than 1 - means middle piece
            if (r1 > 1 && c1 > 1)
            {
                min = Math.Min(min, Math.Min((n - r1 + 1 + k - 1) / k, (r2 + k - 1) / k) + (r2 - r1 + 1 + k - 1) / k + (c2 - c1 + 1 + k - 1) / k * 2);
                min = Math.Min(min, Math.Min((m - c1 + 1 + k - 1) / k, (c2 + k - 1) / k) + (c2 - c1 + 1 + k - 1) / k + (r2 - r1 + 1 + k - 1) / k * 2);
            }
            //if top-left is equals 1 - means left edge piece
            else if (r1 == 1)
            {
                min = 0;
                if (c1 > 1)
                {
                    min += (r2 - r1 + 1 + k - 1) / k;
                }
                if (c2 < m)
                {
                    min += (r2 - r1 + 1 + k - 1) / k;
                }
                if (r2 < n)
                {
                    min += (c2 - c1 + 1 + k - 1) / k;
                }
            }
            //if top-left is equals 1 - means top edge piece
            else if (c1 == 1)
            {
                min = 0;
                if (r1 > 1)
                {
                    min += (c2 - c1 + 1 + k - 1) / k;
                }
                if (r2 < n)
                {
                    min += (c2 - c1 + 1 + k - 1) / k;
                }
                if (c2 < m)
                {
                    min += (r2 - r1 + 1 + k - 1) / k;
                }
            }
            long plus = Math.Min(
                    (long)(c2 - c1 + 1 + k - 1) / k * (r2 - r1) + (long)(c2 - c1) / k * ((r2 - r1 + 1 + k - 1) / k) + (long)((c2 - c1) - (c2 - c1) / k) * (r2 - r1 + 1),
                    (long)(r2 - r1 + 1 + k - 1) / k * (c2 - c1) + (long)(r2 - r1) / k * ((c2 - c1 + 1 + k - 1) / k) + (long)((r2 - r1) - (r2 - r1) / k) * (c2 - c1 + 1)
            );
            Console.WriteLine("Case #{0}: {1}", caseNo, min+plus);
        }
    }
}
