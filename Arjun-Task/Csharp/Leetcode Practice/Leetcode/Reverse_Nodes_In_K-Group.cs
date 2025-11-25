using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Reverse_Nodes_In_K_Group
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

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode current = head;
            int count = 0;

            while (current != null && count < k)
            {
                current = current.next;
                count++;
            }

            if (count == k)
            {
                current = head;
                ListNode prev = null;
                ListNode next = null;
                int i = 0;

                while (i < k && current != null)
                {
                    next = current.next;
                    current.next = prev;
                    prev = current;
                    current = next;
                    i++;
                }

                head.next = ReverseKGroup(current, k);

                return prev;
            }

            return head;
        }

        static ListNode CreateLinkedList(int[] values)
        {
            if (values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }

        static void PrintLinkedList(ListNode head)
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val);
                if (current.next != null) Console.Write(" -> ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static void run()
        {
            int[] values = { 1, 2, 3, 4, 5 };
            int k = 2;

            Console.WriteLine("Original list:");
            ListNode head = CreateLinkedList(values);
            PrintLinkedList(head);

            Reverse_Nodes_In_K_Group solution = new Reverse_Nodes_In_K_Group();
            ListNode result = solution.ReverseKGroup(head, k);

            Console.WriteLine($"\nReversed in groups of {k}:");
            PrintLinkedList(result);
        }
    }
}
