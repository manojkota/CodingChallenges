using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tree
{
    /// <summary>
    /// Write a function that takes a binary tree and returnstrueif it is abinary search tree, and false if not. 
    /// In our test code, we're going to use the following examples: 
    /// head1 = 0 / \ 1 2 /\ /\ 3 4 5 6 head1 is NOTa binary search tree. 
    /// head2 = 3 / \ 1 4 /\ / \ 0 2 5 6 head2 is NOT a binary search tree. 
    /// head3 = 3 / \ 1 5 /\ / \ 0 2 4 6 head3 isa binary search tree. 
    /// head4 = 3 / \ 1 5 /\ 0 4 head4 is NOTa binary search tree.
    /// </summary>
    internal class IsBinarySearchTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solve(4, new List<(int, int)>
            {
                (1,5),
                (0,2),
                (3,6)
            }));//Result - false
            Console.WriteLine(Solve(3, new List<(int, int)>
            {
                (1,5),
                (0,2),
                (4,6)
            }));//Result - True
            Console.ReadLine();
        }

        static bool Solve(int rootValue, List<(int,int)> input)
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
            return IsBST(root);
        }

        static bool IsBST(Node node, int? lowerLimit = null, int? upperLimit = null)
        {
            if(lowerLimit.HasValue && node.Data < lowerLimit.Value)
            {
                return false;
            }

            if (upperLimit.HasValue && upperLimit.Value < node.Data)
            {
                return false;
            }

            var is_left_bst = true;
            var is_right_bst = true;
            if(node.Left != null)
            {
                is_left_bst = IsBST(node.Left, lowerLimit, node.Data);
            }
            if (is_left_bst && node.Right != null)
            {
                is_right_bst = IsBST(node.Right, node.Data, upperLimit);
            }
            return is_left_bst && is_right_bst;
        }

        class Node
        {
            public int Data { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node(int value)
            {
                Data = value;
            }
        }
    }
}
