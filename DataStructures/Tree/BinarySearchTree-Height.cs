using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class BinarySearchTreeHeightNode
    {
        public int element;
        public BinarySearchTreeHeightNode left;
        public BinarySearchTreeHeightNode right;

        public BinarySearchTreeHeightNode(int e, BinarySearchTreeHeightNode l, BinarySearchTreeHeightNode r)
        {
            element = e;
            left = l;
            right = r;
        }
    }
    
    class BinarySearchTreeHeight
    {
        BinarySearchTreeHeightNode root;

        public BinarySearchTreeHeight()
        {
            root = null;
        }

        public void insert(BinarySearchTreeHeightNode temproot, int e)
        {
            BinarySearchTreeHeightNode temp = null;
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
            BinarySearchTreeHeightNode n = new BinarySearchTreeHeightNode(e, null, null);
            if (root != null)
                if (e < temp.element)
                    temp.left = n;
                else
                    temp.right = n;
            else
                root = n;
        }

        public bool delete(int e)
        {
            BinarySearchTreeHeightNode p = root;
            BinarySearchTreeHeightNode pp = null;
            while (p != null && p.element != e)
            {
                pp = p;
                if (e < p.element)
                    p = p.left;
                else
                    p = p.right;
            }
            if (p == null)
                return false;
            if (p.left != null && p.right != null)
            {
                BinarySearchTreeHeightNode s = p.left;
                BinarySearchTreeHeightNode ps = p;
                while (s.right != null)
                {
                    ps = s;
                    s = s.right;
                }
                p.element = s.element;
                p = s;
                pp = ps;
            }
            BinarySearchTreeHeightNode c = null;
            if (p.left != null)
                c = p.left;
            else
                c = p.right;
            if (p == root)
                root = null;
            else
            {
                if (p == pp.left)
                    pp.left = c;
                else
                    pp.right = c;
            }
            return true;
        }

        public void inorder(BinarySearchTreeHeightNode temproot)
        {
            if (temproot != null)
            {
                inorder(temproot.left);
                Console.Write(temproot.element + " ");
                inorder(temproot.right);
            }
        }

        public void preorder(BinarySearchTreeHeightNode temproot)
        {
            if (temproot != null)
            {
                Console.Write(temproot.element + " ");
                preorder(temproot.left);
                preorder(temproot.right);
            }
        }

        public void postorder(BinarySearchTreeHeightNode temproot)
        {
            if (temproot != null)
            {
                postorder(temproot.left);
                postorder(temproot.right);
                Console.Write(temproot.element + " ");
            }
        }

        public bool search(BinarySearchTreeHeightNode temproot, int key)
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

        public int count(BinarySearchTreeHeightNode temproot)
        {
            if (temproot != null)
            {
                int x = count(temproot.left);
                int y = count(temproot.right);
                return x + y + 1;
            }
            return 0;
        }

        public int height(BinarySearchTreeHeightNode temproot)
        {
            if (temproot != null)
            {
                int x = height(temproot.left);
                int y = height(temproot.right);
                if (x > y)
                    return x + 1;
                else
                    return y + 1;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            BinarySearchTreeHeight B = new BinarySearchTreeHeight();
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

            Console.WriteLine("Number of BinarySearchTreeHeightNode: " + B.count(B.root));
            Console.WriteLine("Height: " + (B.height(B.root)-1));
            Console.ReadKey();
        }
    }
}
