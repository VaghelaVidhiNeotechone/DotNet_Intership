using System;

namespace Csharp_All_Task
{
    internal class Rotate_List
    {
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

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
            {
                return head;
            }

            int len = 1;
            ListNode tail = head;
            while (tail.next != null)
            {
                len++;
                tail = tail.next;
            }
            tail.next = head;

            k = k % len;
            int stepsToNewHead = len - k;

            ListNode newTail = tail;
            while (stepsToNewHead-- > 0)
            {
                newTail = newTail.next;
            }

            ListNode newHead = newTail.next;
            newTail.next = null;

            return newHead;
        }

        private static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val);
                if (head.next != null) Console.Write(" -> ");
                head = head.next;
            }
            Console.WriteLine();
        }

        public static void run()
        {
            Rotate_List obj = new Rotate_List();

            ListNode head = new ListNode(1,
                              new ListNode(2,
                              new ListNode(3,
                              new ListNode(4,
                              new ListNode(5)))));

            Console.WriteLine("Original List:");
            PrintList(head);
            int k = 2;
            ListNode rotated = obj.RotateRight(head, k);

            Console.WriteLine($"\nList after rotating by {k} positions:");
            PrintList(rotated);
        }
    }
}
