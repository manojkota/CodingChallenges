using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnDSAlgorithms
{
    public class DoublyLinkedListNode
    {
        public int element;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int e, DoublyLinkedListNode n, DoublyLinkedListNode p)
        {
            element = e;
            next = n;
            prev = p;
        }
    }

    class DoublyLinkedList
    {
        private DoublyLinkedListNode head;
        private DoublyLinkedListNode tail;
        private int size;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
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

        public void addLast(int e)
        {
            DoublyLinkedListNode newest = new DoublyLinkedListNode(e, null, null);
            if (isEmpty())
            {
                head = newest;
                tail = newest;
            }
            else
            {
                tail.next = newest;
                newest.prev = tail;
                tail = newest;
            }
            size = size + 1;
        }

        public void addFirst(int e)
        {
            DoublyLinkedListNode newest = new DoublyLinkedListNode(e, null, null);
            if (isEmpty())
            {
                head = newest;
                tail = newest;
            }
            else
            {
                newest.next = head;
                head.prev = newest;
                head = newest;
            }
            size = size + 1;
        }

        public void addAny(int e, int position)
        {
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid Position");
                return;
            }
            DoublyLinkedListNode newest = new DoublyLinkedListNode(e, null, null);
            DoublyLinkedListNode p = head;
            int i = 1;
            while (i < position - 1)
            {
                p = p.next;
                i = i + 1;
            }
            newest.next = p.next;
            p.next.prev = newest;
            p.next = newest;
            newest.prev = p;
            size = size + 1;
        }

        public int removeFirst()
        {
            if (isEmpty())
            {
                Console.WriteLine("Doubly List is Empty");
                return -1;
            }
            int e = head.element;
            head = head.next;
            size = size - 1;
            if (isEmpty())
                tail = null;
            else
                head.prev = null;
            return e;
        }

        public int removeLast()
        {
            if (isEmpty())
            {
                Console.WriteLine("Doubly List is Empty");
                return -1;
            }
            int e = tail.element;
            tail = tail.prev;
            tail.next = null;
            size = size - 1;
            return e;
        }

        public int removeAny(int position)
        {
            if (position <= 0 || position >= size - 1)
            {
                Console.WriteLine("Invalid Position");
                return -1;
            }
            DoublyLinkedListNode p = head;
            int i = 1;
            while (i < position - 1)
            {
                p = p.next;
                i = i + 1;
            }
            int e = p.next.element;
            p.next = p.next.next;
            p.next.prev = p;
            size = size - 1;
            return e;
        }

        public void display()
        {
            DoublyLinkedListNode p = head;
            while (p != null)
            {
                Console.Write(p.element + "-->");
                p = p.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            DoublyLinkedList l = new DoublyLinkedList();
            l.addLast(7);
            l.addLast(4);
            l.addLast(12);
            l.addLast(8);
            l.addLast(3);
            l.display();
            Console.WriteLine("Size: " + l.length());
            int element = l.removeAny(3);
            Console.WriteLine("Removed Element: " + element);
            l.display();
            Console.WriteLine("Size: " + l.length());

            Console.ReadKey();
        }
    }
}
