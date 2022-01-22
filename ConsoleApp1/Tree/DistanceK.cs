using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tree
{
    internal class DistanceK
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(" ", Solve(new int[3] { 5, 10, -5 })));//[5, 10]
            Console.ReadLine();
        }

        static Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();

        static IList<int> Solve(TreeNode root, TreeNode target, int k)
        {
            dfs(root, null);

            HashSet<TreeNode> seen = new HashSet<TreeNode>();
            seen.Add(target);
            seen.Add(null);

            Queue<TreeNode> q = new Queue<TreeNode>();
            int level = 0;
            q.Enqueue(null);
            q.Enqueue(target);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == null)
                {
                    if (level == k)
                    {
                        var ans = new List<int>();
                        while (q.Count > 0)
                        {
                            var p = q.Dequeue();
                            ans.Add(p.val);
                        }
                        return ans;
                    }
                    q.Enqueue(null);
                    level++;
                }
                if (node.left != null && !seen.Contains(node.left))
                {
                    seen.Add(node.left);
                    q.Enqueue(node.left);
                }
                if (node.right != null && !seen.Contains(node.right))
                {
                    seen.Add(node.right);
                    q.Enqueue(node.right);
                }
                if (parent[node] != null && !seen.Contains(parent[node]))
                {
                    seen.Add(parent[node]);
                    q.Enqueue(parent[node]);
                }
            }
            return new int[0];

        }

        static void dfs(TreeNode node, TreeNode par)
        {
            if (node != null)
            {
                parent.Add(node, par);
                dfs(node.left, node);
                dfs(node.right, node);
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
