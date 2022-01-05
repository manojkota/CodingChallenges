using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedLists
{
    /// <summary>
    /// Implement a function that finds the nthnodein a linked list,counting from the end. 
    /// Your function should takealinked list (itshead element) and n, a positiveintegeras itsarguments. 
    /// Examples: head = 7 - 6 - 5 - 4 - 3 - 2 - 1 - (null / None) 
    /// Thethird element of head counting from the end is 3. 
    /// head2 = 1 - 2 - 3 - 4 - (null / None) 
    /// Thefourthelement of head2counting from the end is 1. 
    /// If the given n is larger than the number of nodes in the list, return null / None.
    /// </summary>
    internal class NthElementInTheLinkedList
    {
        static void Main(string[] args)
        {
            Node current = new Node(1, null);
            for (int i = 2; i < 8; i++)
            {
                current = new Node(i, current);
            }
            Node head = current;
            Console.WriteLine(Solve(head, 3)?.Data);
            Console.WriteLine(Solve(head, 9)?.Data);
            Console.ReadLine();
        }

        static Node Solve(Node head, int k)
        {
            var left = head;
            var right = head;
            for (int i = 0; i < k; i++)
            {
                if(right == null)
                {
                    return null;
                }
                right = right.Child;
            }
            while(right != null)
            {
                right = right.Child;
                left = left.Child;
            }
            return left;
        }

        class Node
        {
            public int Data { get; set; }

            public Node Child { get; set; }

            public Node(int value, Node node)
            {
                Data = value;
                Child = node;
            }
        }
    }

    
}
