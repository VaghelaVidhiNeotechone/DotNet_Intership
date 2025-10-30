using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Merge_Two_Sorted_Lists
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

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            ListNode head = null;
            
            if (list1.val>list2.val)
            {
                head = list2;
                list2 = list2.next;
            }
            else
            {
                head = list1;
                list1 = list1.next;
            }

            ListNode curr = head;

            while (list1 != null && list2 != null)
            {
                if (list1.val > list2.val)
                {
                    curr.next = list2;
                    list2 = list2.next;
                }
                else
                {
                    curr.next = list1;
                    list1 = list1.next;
                }
                curr = curr.next;
            }

            if (list1 != null) curr.next = list2;
            else curr.next = list2;

            return head;
        }

        public static void run()
        {
            ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));

            ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            Merge_Two_Sorted_Lists merger = new Merge_Two_Sorted_Lists();
            ListNode merged = merger.MergeTwoLists(list1, list2);

            Console.WriteLine("Merged Sorted List:");
            PrintList(merged);

            Console.ReadLine();
        }

        static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + " -> ");
                head = head.next;
            }
            Console.WriteLine("null");
        }
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

