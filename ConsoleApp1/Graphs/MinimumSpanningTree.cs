using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Graphs
{
    internal class MinimumSpanningTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MinimumCost(3, new int[3][] { new int[3] { 1, 2, 5 }, new int[3] { 2, 3, 1 }, new int[3] { 1, 3, 6 } }));//OP - 6
            Console.ReadLine();
        }

        public class Solution
        {

            private int[] parent;

            private int Find(int x)
            {
                if (parent[x] == x)
                    return x;

                parent[x] = Find(parent[x]);
                return parent[x];
            }

            public int MinimumCost(int n, int[][] connections)
            {

                //Sort by weight(cost) of the edges
                Array.Sort(connections, delegate(int[] x, int[] y) { return x[2] - y[2];});

                parent = new int[n + 1];
                for (int i = 1; i <= n; i++)
                    parent[i] = i;

                int edgesCount = 0;
                int cost = 0;
                foreach (int[] connection in connections)
                {
                    int u_rep = Find(connection[0]);
                    int v_rep = Find(connection[1]);
                    if (u_rep != v_rep)
                    {
                        parent[v_rep] = u_rep;
                        edgesCount++;
                        cost += connection[2];
                    }

                    if (edgesCount == n - 1)
                        break;
                }

                return edgesCount == n - 1 ? cost : -1;
            }

        }
    }
}
