using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Search
{
    class WhatFlavour
    {
        public static void Main(string[] args)
        {
            Solve(new List<int> { 1,4,5,3,2}, 4);//result - 1 4
            Solve(new List<int> { 2,2,4,3 }, 4);//result 1 2
            Console.ReadLine();
        }

        public static void Solve(List<int> cost, int money)
        {
            var result = new Dictionary<int, int>();

            for (int i = 0; i < cost.Count; i++)
            {
                if(!result.ContainsKey(cost[i]))
                {
                    result[money - cost[i]] = i + 1;
                }
                else
                {
                    Console.WriteLine($"{result[cost[i]]} {i + 1}");
                    break;
                }
            }
        }
    }
}
