using System;
using System.Collections.Generic;

namespace Leetcode
{
    internal class Merge_k_Sorted_Lists
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

            // Helper method to print the list
            public static void PrintList(ListNode head)
            {
                while (head != null)
                {
                    Console.Write(head.val + (head.next != null ? "->" : ""));
                    head = head.next;
                }
                Console.WriteLine();
            }
        }

        public static void run()
        {
            ListNode[] lists = new ListNode[]
            {
                BuildList(new int[] {1, 4, 5}),
                BuildList(new int[] {1, 3, 4}),
                BuildList(new int[] {2, 6})
            };

            ListNode merged = MergeKLists(lists);

            Console.WriteLine("Merged Linked List:");
            ListNode.PrintList(merged);
        }

        static ListNode BuildList(int[] nums)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;
            foreach (int num in nums)
            {
                current.next = new ListNode(num);
                current = current.next;
            }
            return dummy.next;
        }

        static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            return MergeHelper(lists, 0, lists.Length - 1);
        }

        static ListNode MergeHelper(ListNode[] lists, int left, int right)
        {
            if (left == right)
                return lists[left];

            int mid = (left + right) / 2;
            ListNode l1 = MergeHelper(lists, left, mid);
            ListNode l2 = MergeHelper(lists, mid + 1, right);

            return MergeTwoLists(l1, l2);
        }

        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode current = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }

            current.next = l1 ?? l2;

            return dummy.next;
        }
    }
        
}
