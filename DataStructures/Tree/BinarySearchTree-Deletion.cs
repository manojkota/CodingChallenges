using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class BinarySearchTreeDeletionNode
    {
        public int element;
        public BinarySearchTreeDeletionNode left;
        public BinarySearchTreeDeletionNode right;

        public BinarySearchTreeDeletionNode(int e, BinarySearchTreeDeletionNode l, BinarySearchTreeDeletionNode r)
        {
            element = e;
            left = l;
            right = r;
        }
    }
    
    class BinarySearchTreeDeletion
    {
        BinarySearchTreeDeletionNode root;

        public BinarySearchTreeDeletion()
        {
            root = null;
        }

        public void insert(BinarySearchTreeDeletionNode temproot, int e)
        {
            BinarySearchTreeDeletionNode temp = null;
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
            BinarySearchTreeDeletionNode n = new BinarySearchTreeDeletionNode(e, null, null);
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
            BinarySearchTreeDeletionNode p = root;
            BinarySearchTreeDeletionNode pp = null;
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
                BinarySearchTreeDeletionNode s = p.left;
                BinarySearchTreeDeletionNode ps = p;
                while (s.right != null)
                {
                    ps = s;
                    s = s.right;
                }
                p.element = s.element;
                p = s;
                pp = ps;
            }
            BinarySearchTreeDeletionNode c = null;
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

        public void inorder(BinarySearchTreeDeletionNode temproot)
        {
            if (temproot != null)
            {
                inorder(temproot.left);
                Console.Write(temproot.element + " ");
                inorder(temproot.right);
            }
        }

        public void preorder(BinarySearchTreeDeletionNode temproot)
        {
            if (temproot != null)
            {
                Console.Write(temproot.element + " ");
                preorder(temproot.left);
                preorder(temproot.right);
            }
        }

        public void postorder(BinarySearchTreeDeletionNode temproot)
        {
            if (temproot != null)
            {
                postorder(temproot.left);
                postorder(temproot.right);
                Console.Write(temproot.element + " ");
            }
        }

        public bool search(BinarySearchTreeDeletionNode temproot, int key)
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
            BinarySearchTreeDeletion B = new BinarySearchTreeDeletion();
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
            B.delete(50);
            Console.WriteLine("Inorder Traversal");
            B.inorder(B.root);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
