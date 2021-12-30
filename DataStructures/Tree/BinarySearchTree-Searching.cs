using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class BinarySearchTreeSearchingNode
    {
        public int element;
        public BinarySearchTreeSearchingNode left;
        public BinarySearchTreeSearchingNode right;

        public BinarySearchTreeSearchingNode(int e, BinarySearchTreeSearchingNode l, BinarySearchTreeSearchingNode r)
        {
            element = e;
            left = l;
            right = r;
        }
    }
    
    class BinarySearchTreeSearching
    {
        BinarySearchTreeSearchingNode root;

        public BinarySearchTreeSearching()
        {
            root = null;
        }

        public void insert(BinarySearchTreeSearchingNode temproot, int e)
        {
            BinarySearchTreeSearchingNode temp = null;
            while (temproot != null)
            {
                temp = temproot;
                if (e == temproot.element)
                    return;
                else if (e < temproot.element)
                    temproot = temproot.left;
                else if (e > temproot.element)
                    temproot = temproot.right;
            }
            BinarySearchTreeSearchingNode n = new BinarySearchTreeSearchingNode(e, null, null);
            if (root != null)
                if (e < temp.element)
                    temp.left = n;
                else
                    temp.right = n;
            else
                root = n;
        }

        public void inorder(BinarySearchTreeSearchingNode temproot)
        {
            if (temproot != null)
            {
                inorder(temproot.left);
                Console.Write(temproot.element + " ");
                inorder(temproot.right);
            }
        }

        public void preorder(BinarySearchTreeSearchingNode temproot)
        {
            if (temproot != null)
            {
                Console.Write(temproot.element + " ");
                preorder(temproot.left);
                preorder(temproot.right);
            }
        }

        public void postorder(BinarySearchTreeSearchingNode temproot)
        {
            if (temproot != null)
            {
                postorder(temproot.left);
                postorder(temproot.right);
                Console.Write(temproot.element + " ");
            }
        }

        public bool search(int key)
        {
            BinarySearchTreeSearchingNode temproot = root;
            while (temproot != null)
            {
                if (key == temproot.element)
                    return true;
                else if (key < temproot.element)
                    temproot = temproot.left;
                else if (key > temproot.element)
                    temproot = temproot.right;
            }
            return false;
        }

        static void Main(string[] args)
        {
            BinarySearchTreeSearching B = new BinarySearchTreeSearching();
            B.insert(B.root, 50);
            B.insert(B.root, 30);
            B.insert(B.root, 80);
            B.insert(B.root, 10);
            B.insert(B.root, 40);
            B.insert(B.root, 60);
            B.insert(B.root, 90);
            Console.WriteLine("Inorder Traversal");
            B.inorder(B.root);
            Console.WriteLine();
            Console.WriteLine("Pre Order Traversal");
            B.preorder(B.root);
            Console.WriteLine();
            Console.WriteLine("Post Order Traversal");
            B.postorder(B.root);
            Console.WriteLine();

            Console.WriteLine("Search Result: " + B.search(70));

            Console.ReadKey();
        }
    }
}
