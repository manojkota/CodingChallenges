using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.GreedyAlogorithms
{
    internal class Sell_Diminishing_Valued_Colored_Balls
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit(new int[] { 5, 2 }, 4));//OP - 14
            Console.ReadLine();
        }

        static int MaxProfit(int[] inventory, int orders)
        {

            long result = 0;
            long curOrdersSize = 0;
            int i = 0;

            var x = inventory.OrderByDescending(k => k).ToArray();
            // Imagine the costs as these triangluraly organized containers based on inventory in descending sorted order.
            //
            // Each Column height represent the cost of order.
            //
            // Note we have to pick up first the balls that are most costly .. i.e left columns from left triangles
            // We can repeate pick up until all the left triangle is now same as the adjacent right triangle.
            //
            // Basically if the difference between the two triangles is d we can pick up d columns from left triangle, costing us the area of trapezoid
            // smallerbase = x - (d-1), largerbase = x, height = d
            //
            // trapezoidarea = (smallerbase+largerbase)/2 * height;
            //
            // The same area of of cost will be charged from all traingles left of current triangle
            // area             = (trapezoidarea)*i;
            // columns consumed = requiredCostToCoverArea = d * i; 
            // 
            // If we still have more orders left "accumulative cost of requiredCostToCoverArea" is less than "orders" continue the same process with x[i+1].
            //
            // If we cant consume the requiredCostToCoverArea we need to be less greedy and adjust the remaining orders and loop over tallest left columns from all the higher order triangles as per capacity.
            // Find the d columns we can still gobble from all of the higher order triangles d = (orders-curOrdersSize)/i;
            // 
            // 

            //      x[i-1]                   x[i]                           x[i+1]                       x[i+2]
            // _ 
            // d    .
            // _    . .                     _
            //      . . | .                    .                           
            //      . . | . .               d1 . .
            //      . . | . . .             _  . . .                        
            // a    . . | . . . |.             . . . |.                     .                          
            //      . . | . . . |. |        a1 . . . |. |.                  . |.                        .
            //      . . | . . . |. |. .        . . . |. |. .                . |. .                      . .
            // _    . . | . . . |. |. . .   _  . . . |. |. . .              . |. . .                    . . .
            //     
            //     | d  | d1    |d2|  d3 |     | d1  |d2| d3  |             |d2| d3  |



            for (i = 1; i < x.Length; i++)
            {
                long d = x[i - 1] - x[i];
                long requiredCostToCoverArea = d * i;

                if (requiredCostToCoverArea + curOrdersSize <= orders)
                {
                    long area = (calcAreaOfTrapezoid(x[i - 1] - (d - 1), x[i - 1], d)) * i;
                    result += area;
                    curOrdersSize += requiredCostToCoverArea;
                }
                else
                {
                    break;
                }
            }

            if (i <= x.Length)
            {
                long d = (orders - curOrdersSize) / i;
                long area = (calcAreaOfTrapezoid(x[i - 1] - d + 1, x[i - 1], d)) * i;

                long residueCols = (orders - curOrdersSize) % i;
                long colHeights = (x[i - 1] - d);
                long residueColsArea = colHeights * residueCols;

                result += residueColsArea + area;
            }


            return (int)((result % (1000000007)));
        }

        // base1 and base2 are parallel
        static long calcAreaOfTrapezoid(long base1, long base2, long height)
        {
            return ((base1 + base2) * height) / 2;
        }

        static int Sol1(int[] inventory, int orders)
        {

            // sort the colored balles by inventory in descending order
            Array.Sort(inventory, (a, b) => b - a);
            int idx = 0;
            long currPrice = inventory[0], nextPrice = 0, sell = 0, res = 0;

            while (orders > 0)
            {
                // count the number of colors that can be sold together
                while (idx < inventory.Length && inventory[idx] == currPrice)
                    idx++;

                // next price when new colors can be sold together with current colors
                nextPrice = idx == inventory.Length ? 0 : inventory[idx];

                // actual number of balls will be sold in this round
                sell = Math.Min(orders, idx * (currPrice - nextPrice));

                // profit when all the balls of a specific color can be sold in this round
                long priceDiff = currPrice - nextPrice;
                int remainder = 0;

                // don't need to sell all the saleable balls to satisfy orders
                if (orders < idx * (currPrice - nextPrice))
                {
                    priceDiff = orders / idx;
                    remainder = orders % idx;
                    nextPrice = currPrice - priceDiff;
                }

                res = (res + (currPrice + nextPrice + 1) * priceDiff / 2 * idx + nextPrice * remainder) % 1000000007;
                orders -= (int)sell;
                currPrice = nextPrice;
            }

            return (int)res;
        }
    }
}
