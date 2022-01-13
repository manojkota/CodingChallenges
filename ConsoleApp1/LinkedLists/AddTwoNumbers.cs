using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedLists
{
    internal class AddTwoNumbers
    {
        static void Main(string[] args)
        {
            Print(Solve(BuildLinkedList(342), BuildLinkedList(465)));//Result - 708
            Console.ReadLine();
        }

        static ListNode BuildLinkedList(int number)
        {
            var head = new ListNode(0);
            var current = head;
            while (number > 0)
            {
                current.next = new ListNode(number % 10);
                current = current.next;
                number = number / 10;
            }
            return head.next;
        }

        static void Print(ListNode l)
        {
            while(l != null)
            {
                Console.WriteLine(l.val);
                l = l.next;
            }
        }

        static ListNode Solve(ListNode l1, ListNode l2)
        {
            var head = new ListNode(0);
            var current = head;
            var carry = 0;
            while (l1 != null || l2 != null)
            {
                current.next = ReturnResultWithCarry((l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry, ref carry);
                current = current.next;
                l1 = l1?.next;
                l2 = l2?.next;
            }
            if (carry == 1)
            {
                current.next = new ListNode(1);
            }
            return head.next;
        }

        static ListNode ReturnResultWithCarry(int n, ref int carry)
        {
            if (n >= 10)
            {
                carry = 1;
            }
            else
            {
                carry = 0;
            }
            return new ListNode(n % 10);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
