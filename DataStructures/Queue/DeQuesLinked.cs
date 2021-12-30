using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class DeQueLinkedNode
    {
        public int element;
        public DeQueLinkedNode next;
        public DeQueLinkedNode(int e, DeQueLinkedNode n)
        {
            element = e;
            next = n;
        }
    }

    class DeQueLinked
    {
        private DeQueLinkedNode front;
        private DeQueLinkedNode rear;
        private int size;

        public DeQueLinked()
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

        public void addlast(int e)
        {
            DeQueLinkedNode newest = new DeQueLinkedNode(e, null);
            if (isEmpty())
                front = newest;
            else
                rear.next = newest;
            rear = newest;
            size = size + 1;
        }

        public void addFirst(int e)
        {
            DeQueLinkedNode newest = new DeQueLinkedNode(e, null);
            if (isEmpty())
            {
                front = newest;
                rear = newest;
            }
            else
            {
                newest.next = front;
                front = newest;
            }
            size = size + 1;
        }

        public int removeFirst()
        {
            if (isEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            int e = front.element;
            front = front.next;
            size = size - 1;
            if (isEmpty())
                rear = null;
            return e;
        }

        public int removeLast()
        {
            if (isEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            DeQueLinkedNode p = front;
            int i = 1;
            while (i < size - 1)
            {
                p = p.next;
                i = i + 1;
            }
            rear = p;
            p = p.next;
            int e = p.element;
            rear.next = null;
            size = size - 1;
            return e;
        }

        public int search(int key)
        {
            DeQueLinkedNode p = front;
            int index = 0;
            while (p != null)
            {
                if (p.element == key)
                    return index;
                p = p.next;
                index = index + 1;
            }
            return -1;
        }

        public void display()
        {
            DeQueLinkedNode p = front;
            while (p != null)
            {
                Console.Write(p.element + " --> ");
                p = p.next;
            }
            Console.WriteLine();
        }

        public int first()
        {
            if (isEmpty())
            {
                Console.WriteLine("DeQueue is Empty");
                return -1;
            }
            return front.element;
        }

        public int last()
        {
            if (isEmpty())
            {
                Console.WriteLine("DeQueue is Empty");
                return -1;
            }
            return rear.element;
        }

        static void Main(string[] args)
        {
            DeQueLinked d = new DeQueLinked();
            d.addFirst(5);
            d.addFirst(3);
            d.addlast(7);
            d.addlast(12);
            d.display();
            Console.WriteLine("Size: " + d.length());
            Console.WriteLine("Front Element Removed: " + d.removeFirst());
            Console.WriteLine("Rear Element Removed: " + d.removeLast());
            d.display();
            Console.WriteLine("First Element: " + d.first());
            Console.WriteLine("Last Element: " + d.last());
            Console.ReadKey();
        }
    }
}
