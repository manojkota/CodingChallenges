using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tree
{
    /// <summary>
    /// Find the lowest common ancestor of two items in a binary tree. 
    /// Assumptions: Each value in the tree is unique (there are no two nodes with the same value).
    /// Each node has at most two children, left and right.
    /// You donothave alevelattribute in each of your node (for example, 1st layer, 2nd layer, and so on).
    /// Each nodehas pointersto left and right children, but there's no back link (a child node does not point back to its parent node). 
    /// Example: head = 5 / \ 1 4 /\ /\ 3 8 9 2 /\ 6 7 LCA of 8 and 7 is 1.LCA of 4 and 2 is 4. 
    /// NOTE:In our test code, the following two trees will be used. 
    /// head1 = 0 / \ 1 2 /\ /\ 3 4 5 6 
    /// head2 = 5 / \ 1 4 /\ / \ 3 8 9 2 /\ 6 7
    /// </summary>
    internal class LowestCommonAncestor
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(5, new List<(int, int)>
            {
                (1,4),
                (3,8),
                (9,2),
                (6,7)
            }, 8,7));//Result - 1
            Console.ReadLine();
        }

        static int? Solve(int rootValue, List<(int, int)> input, int x, int y)
        {
            Node root = new Node(rootValue);
            var q = new Queue<Node>();
            q.Enqueue(root);
            foreach (var item in input)
            {
                var temp = q.Dequeue();
                if (item.Item1 >= 0)
                {
                    Node left = new Node(item.Item1);
                    temp.Left = left;
                    q.Enqueue(left);
                }
                if (item.Item2 >= 0)
                {
                    Node right = new Node(item.Item2);
                    temp.Right = right;
                    q.Enqueue(right);
                }
            }

            var x_path = LCS(root, x);
            var y_path = LCS(root, y);

            if(x_path.Count == 0 || y_path.Count == 0)
            {
                return null;
            }
            int? lcsValue = null;
            while(x_path.Count > 0 && y_path.Count > 0)
            {
                var xItem = x_path.Pop();
                var yItem = y_path.Pop();
                if(xItem == yItem)
                {
                    lcsValue = xItem;
                }
                {
                    break;
                }
            }
            return lcsValue;
        }

        static Stack<int> LCS(Node node, int x)
        {
            if(node == null)
            {
                return null;
            }
            if(node.Value == x)
            {
                Stack<int> path = new Stack<int>();
                path.Push(x);
                return path;
            }

            var lPath = LCS(node.Left, x);
            if (lPath != null)
            {
                lPath.Push(node.Value);
                return lPath;
            }

            var rPath = LCS(node.Right, x);
            if (rPath != null)
            {
                rPath.Push(node.Value);
                return rPath;
            }

            return null;
        }

        class Node
        {
            public int Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }

    }
}
