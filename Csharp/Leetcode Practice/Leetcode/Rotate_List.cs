using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Rotate_List
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0) return head;

            int length = 1;
            ListNode tail = head;
            while (tail.next != null)
            {
                tail = tail.next;
                length++;
            }

            tail.next = head;

            k = k % length;
            int stepsToNewTail = length - k;
            ListNode newTail = head;
            for (int i = 1; i < stepsToNewTail; i++)
            {
                newTail = newTail.next;
            }

            ListNode newHead = newTail.next;
            newTail.next = null;

            return newHead;
        }

        public static void run()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);

            int k = 2;

            Rotate_List solution = new Rotate_List();
            ListNode rotatedHead = solution.RotateRight(head, k);

            Console.WriteLine("Rotated List:");
            PrintList(rotatedHead);
        }

        static void PrintList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
