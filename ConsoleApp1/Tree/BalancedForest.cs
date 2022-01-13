using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tree
{
    internal class BalancedForest
    {
        static void Main(string[] args)
        {
            Console.WriteLine(balancedForest(new List<int> { 15, 12, 8, 14, 13 },
                new List<List<int>>
                {
                    new List<int>{1,2 },
                    new List<int>{1,3 },
                    new List<int>{1,4 },
                    new List<int>{4,5 }
                }));//result - 19
            Console.WriteLine(balancedForest(new List<int> { 1, 3, 5 },
                new List<List<int>> {
                new List<int>{1,3},
                new List<int>{1,2} }));
            Console.ReadLine();
        }

        class Node
        {
            public int Cost { get; set; }
            public bool Visited { get; set; }
            public bool Visited2 { get; set; }
            public List<int> Adjacent { get; set; } = new List<int>();

            public override String ToString()
            {
                return "Node{" +
                        "cost=" + Cost +
                        ", v1=" + Visited +
                        ", v2=" + Visited2 +
                        ", adjacent=" + string.Join(",", Adjacent) +
                        '}';
            }

            public Node(int cost)
            {
                Cost = cost;
            }
        }

        static int mini, sum;
        static HashSet<long> s = new HashSet<long>();
        static HashSet<long> q = new HashSet<long>();

        public static int balancedForest(List<int> c, List<List<int>> edges)
        {
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < c.Count; i++)
            {
                nodes.Add(new Node(c[i]));
            }

            for (int i = 0; i < edges.Count; i++)
            {
                int[] edge = edges[i].ToArray();
                int a = edge[0] - 1;
                int b = edge[1] - 1;
                nodes[a].Adjacent.Add(b);
                nodes[b].Adjacent.Add(a);
            }

            mini = sum = dfs(0, nodes);
            solve(0, nodes);

            return mini == sum ? -1 : mini;
        }

        private static int dfs(int p, List<Node> nodes)
        {
            Node node = nodes[p];
            if (node.Visited) return 0;
            node.Visited = true;
            for (int i = 0; i < node.Adjacent.Count; i++)
            {
                node.Cost += dfs(node.Adjacent[i], nodes);
            }
            return node.Cost;
        }

        // s contains sums encountered during depth first search excluding those from the root to the current node.
        // q contains sums encountered during depth first search from the root to current node.
        private static void solve(int p, List<Node> nodes)
        {
            Node node = nodes[p];
            if (node.Visited2) return;
            node.Visited2 = true;

            int[] x = {2*node.Cost,
                2*sum - 4*node.Cost,
                sum-node.Cost};
            int[] y = {3*node.Cost - sum,
                (sum-node.Cost)/2 - node.Cost};

            // If removing the edge above the current node (node variable defined at the top of this method)
            // gives two trees whose total values are the same, then the node we add should have that
            // same value too to get 3 trees (one of which is our single node that we added) with the same value.
            if (sum % 2 == 0 && node.Cost == (sum / 2)) mini = Math.Min(mini, sum / 2);

            // case 1a: When two non-overlapping subtrees in the overall tree have the same total value.
            if (s.Contains(node.Cost))
            {// ||                      // case 1a
             //                q.contains(2*node.cost) ) {                  // ?
                if (y[0] >= 0) mini = Math.Min(mini, y[0]);
            }

            // case 1b: (part B): Two non-overlapping subtrees in the overall tree.
            // case 2b: One edge to be removed is below the other edge to be removed in the overall tree.
            if (s.Contains(sum - 2 * node.Cost) ||                 // case 1b (part B)
                    q.Contains(sum - node.Cost))
            {                // case 2b
                if (y[0] >= 0) mini = Math.Min(mini, y[0]);
            }

            // case 1b: (part A): Two non-overlapping subtrees in the overall tree.
            // case 2a: One edge to be removed is below the other edge to be removed in the overall tree.
            if ((sum - node.Cost) % 2 == 0)
            {
                if (s.Contains((sum - node.Cost) / 2) ||            // case 1b (part A)
                        q.Contains((sum + node.Cost) / 2))
                {        // case 2a
                    if (y[1] >= 0) mini = Math.Min(mini, y[1]);
                }
            }

            q.Add(node.Cost);

            for (int i = 0; i < node.Adjacent.Count(); i++)
            {  // DFS!!
                solve(node.Adjacent[i], nodes);           // recursive call
            }

            q.Remove(node.Cost);
            s.Add(node.Cost);
        }
    }
}
