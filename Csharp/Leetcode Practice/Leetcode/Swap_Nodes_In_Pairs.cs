using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Swap_Nodes_In_Pairs
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

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode firstNode = head;
            ListNode secondNode = head.next;

            firstNode.next = SwapPairs(secondNode.next);

            secondNode.next = firstNode;

            return secondNode;
        }

        public static void run()
        {
            ListNode head = CreateLinkedList(new int[] { 1, 2, 3, 4 });

            Console.WriteLine("Original list:");
            PrintLinkedList(head);

            Swap_Nodes_In_Pairs solution = new Swap_Nodes_In_Pairs();
            ListNode swapped = solution.SwapPairs(head);

            Console.WriteLine("Swapped list:");
            PrintLinkedList(swapped);
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
                if (current.next != null)
                    Console.Write(" -> ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}

