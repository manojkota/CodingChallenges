using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp1.Search
{
    class MachineMinTime
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Solve(new long[] { 2,3 }, 5));//result - 6
            Console.WriteLine(Solve(new long[] { 1, 3, 4 }, 10));//result - 7
            
            Console.ReadLine();
        }

        static long Solve(long[] machines, long goal)
        {
            Array.Sort(machines);
            
            long lowRate = machines.FirstOrDefault();
            long lowerBound = 0;// (goal / (machines.Count() / lowRate));
            long highRate = machines.LastOrDefault();
            long higherBound = goal * highRate; //(goal / (machines.Count() / highRate)) + 1;
            
            while(lowerBound < higherBound)
            {
                long numOfDays = (lowerBound + higherBound) / 2;
                var total = GetNumItems(machines, numOfDays);
                if (total >= goal)
                    higherBound = numOfDays;
                else
                    lowerBound = numOfDays + 1;
            }

            return lowerBound;
        }

        private static long GetNumItems(long[] machines, long numDays)
        {
            long total = 0;

            foreach (var machine in machines)
            {
                total += numDays / machine;
            }
            return total;
        }
    }
}
