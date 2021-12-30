using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class QueuesLinkedNode
    {
        public int element;
        public QueuesLinkedNode next;
        public QueuesLinkedNode(int e, QueuesLinkedNode n)
        {
            element = e;
            next = n;
        }
    }

    class QueuesLinked
    {
        QueuesLinkedNode front;
        QueuesLinkedNode rear;
        int size;

        public QueuesLinked()
        {
            front = null;
            rear = null;
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

        public void enqueue(int e)
        {
            QueuesLinkedNode newest = new QueuesLinkedNode(e, null);
            if (isEmpty())
                front = newest;
            else
                rear.next = newest;
            rear = newest;
            size = size + 1;
        }

        public int dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("Queue is Empty");
                return -1;
            }
            int e = front.element;
            front = front.next;
            size = size - 1;
            if (isEmpty())
                rear = null;
            return e;
        }

        public void display()
        {
            QueuesLinkedNode p = front;
            while (p != null)
            {
                Console.Write(p.element + "-->");
                p = p.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            QueuesLinked q = new QueuesLinked();
            q.enqueue(5);
            q.enqueue(3);
            q.display();
            Console.WriteLine("Size: " + q.length());
            Console.WriteLine("Element Removed: " + q.dequeue());
            Console.WriteLine("IsEmpty: " + q.isEmpty());
            Console.WriteLine("Element Removed: " + q.dequeue());
            Console.WriteLine("IsEmpty: " + q.isEmpty());
            q.enqueue(7);
            q.enqueue(9);
            q.enqueue(4);
            q.display();
            Console.WriteLine("Size: " + q.length());
            Console.ReadKey();

        }
    }
}
