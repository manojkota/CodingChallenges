using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class StacksLinkedNode
    {
        public int element;
        public StacksLinkedNode next;

        public StacksLinkedNode(int e, StacksLinkedNode n)
        {
            element = e;
            next = n;
        }
    }

    class StacksLinked
    {
        StacksLinkedNode top;
        int size;

        public StacksLinked()
        {
            top = null;
            size = 0;
        }

        public int length()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void push(int e)
        {
            StacksLinkedNode newest = new StacksLinkedNode(e, null);
            if (isEmpty())
            {
                top = newest;
            }
            else
            {
                newest.next = top;
                top = newest;
            }
            size = size + 1;
        }

        public int pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            int e = top.element;
            top = top.next;
            size = size - 1;
            return e;
        }

        public int peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            return top.element;
        }

        public void display()
        {
            StacksLinkedNode p = top;
            while (p != null)
            {
                Console.Write(p.element + "-->");
                p = p.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            StacksLinked s = new StacksLinked();
            s.push(5);
            s.push(3);
            s.display();
            Console.WriteLine("Size: " + s.length());
            Console.WriteLine("Element Removed: " + s.pop());
            Console.WriteLine("IsEmpty: " + s.isEmpty());
            Console.WriteLine("Element Removed: " + s.pop());
            Console.WriteLine("IsEmpty: " + s.isEmpty());
            s.push(7);
            s.push(9);
            s.display();
            Console.WriteLine("Element Top: " + s.peek());
            s.display();
            Console.ReadKey();
        }
    }
}
