using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class BinarySearchTreeRecursiveSearchNode
    {
        public int element;
        public BinarySearchTreeRecursiveSearchNode left;
        public BinarySearchTreeRecursiveSearchNode right;

        public BinarySearchTreeRecursiveSearchNode(int e, BinarySearchTreeRecursiveSearchNode l, BinarySearchTreeRecursiveSearchNode r)
        {
            element = e;
            left = l;
            right = r;
        }
    }
    
    class BinarySearchTreeRecursiveSearch
    {
        BinarySearchTreeRecursiveSearchNode root;

        public BinarySearchTreeRecursiveSearch()
        {
            root = null;
        }

        public void insert(BinarySearchTreeRecursiveSearchNode temproot, int e)
        {
            BinarySearchTreeRecursiveSearchNode temp = null;
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
            BinarySearchTreeRecursiveSearchNode n = new BinarySearchTreeRecursiveSearchNode(e, null, null);
            if (root != null)
                if (e < temp.element)
                    temp.left = n;
                else
                    temp.right = n;
            else
                root = n;
        }

        public void inorder(BinarySearchTreeRecursiveSearchNode temproot)
        {
            if (temproot != null)
            {
                inorder(temproot.left);
                Console.Write(temproot.element + " ");
                inorder(temproot.right);
            }
        }

        public void preorder(BinarySearchTreeRecursiveSearchNode temproot)
        {
            if (temproot != null)
            {
                Console.Write(temproot.element + " ");
                preorder(temproot.left);
                preorder(temproot.right);
            }
        }

        public void postorder(BinarySearchTreeRecursiveSearchNode temproot)
        {
            if (temproot != null)
            {
                postorder(temproot.left);
                postorder(temproot.right);
                Console.Write(temproot.element + " ");
            }
        }

        public bool search(BinarySearchTreeRecursiveSearchNode temproot, int key)
        {
            if (temproot != null)
            {
                if (key == temproot.element)
                    return true;
                else if (key < temproot.element)
                    return search(temproot.left, key);
                else if (key > temproot.element)
                    return search(temproot.right, key);
            }
            return false;
        }

        static void Main(string[] args)
        {
            BinarySearchTreeRecursiveSearch B = new BinarySearchTreeRecursiveSearch();
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

            Console.WriteLine("Search Result: " + B.search(B.root, 70));

            Console.ReadKey();
        }
    }
}
