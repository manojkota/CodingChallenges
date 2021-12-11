using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Search
{
    class SwapNodes
    {

        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Data { get; set; }
            public int Depth { get; set; }

            public Node(int data, int depth)
            {
                this.Data = data;
                this.Depth = depth;
            }

            public void SwapNodes()
            {
                Node temp = Left;
                Left = Right;
                Right = temp;
            }
        }

        public static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Data\swapnodes_testcase.txt");

            int n = Convert.ToInt32(lines[0]);

            List<List<int>> indexes = new List<List<int>>();

            for (int i = 1; i <= n; i++)
            {
                indexes.Add(lines[i].TrimEnd().Split(' ').ToList().Select(indexesTemp => Convert.ToInt32(indexesTemp)).ToList());
            }

            int queriesCount = Convert.ToInt32(lines[n+1]);

            List<int> queries = new List<int>();

            for (int i = 1; i <= queriesCount; i++)
            {
                int queriesItem = Convert.ToInt32(lines[n+1+i].Trim());
                queries.Add(queriesItem);
            }

            Print(Solve(indexes, queries));

            Print(Solve(new List<List<int>> { new List<int> { 2,3},
            new List<int> { -1, 4},
            new List<int> { -1,5},
            new List<int> { -1,-1},
            new List<int> { -1,-1}},
            new List<int> { 2 }));//result - 4 2 1 5 3
            Console.ReadLine();
        }

        public static List<List<int>> Solve(List<List<int>> indexes, List<int> queries)
        {
            var result = new List<List<int>>();
            Queue<Node> nodes = new Queue<Node>();
            var rootNode = new Node(1, 1);
            nodes.Enqueue(rootNode);
            
            foreach (var item in indexes)
            {
                var currentNode = nodes.Peek();

                if (item[0] != -1)
                {
                    currentNode.Left = new Node(item[0], currentNode.Depth + 1);
                    nodes.Enqueue(currentNode.Left);
                }

                if (item[1] != -1)
                {
                    currentNode.Right = new Node(item[1], currentNode.Depth + 1);
                    nodes.Enqueue(currentNode.Right);
                }

                nodes.Dequeue();
            }

            foreach (var item in queries)
            {
                PerformSwapNodes(rootNode, item);
                var resultArray = new List<int>();
                Inorder(rootNode, resultArray);
                result.Add(resultArray);
            }
            return result;
        }

        private static void PerformSwapNodes(Node node, int level)
        {
            if(node == null || node.Data == -1)
            {
                return;
            }
            
            if(node.Depth % level == 0)
            {
                node.SwapNodes();
            }
            PerformSwapNodes(node.Left, level);
            PerformSwapNodes(node.Right, level);
        }

        private static void Inorder(Node root, List<int> resultArray)
        {
            if (root != null && root.Data != -1)
            {
                Inorder(root.Left, resultArray);
                resultArray.Add(root.Data);
                Inorder(root.Right, resultArray);
            }
        }

        static void Print(List<List<int>> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
