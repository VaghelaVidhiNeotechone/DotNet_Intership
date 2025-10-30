using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
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

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val <= l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

        public ListNode CreateLinkedList(int[] arr)
        {
            if (arr.Length == 0) return null;

            ListNode head = new ListNode(arr[0]);
            ListNode current = head;

            for (int i = 1; i < arr.Length; i++)
            {
                current.next = new ListNode(arr[i]);
                current = current.next;
            }
            return head;
        }

        public void PrintLinkedList(ListNode head)
        {
            ListNode current = head;
            Console.Write("[");
            while (current != null)
            {
                Console.Write(current.val);
                if (current.next != null) Console.Write(" ");
                current = current.next;
            }
            Console.WriteLine("]");
        }

        public static void run()
        {
            Merge_Two_Sorted_Lists obj = new Merge_Two_Sorted_Lists();
            Console.WriteLine("---- Merge Two Sorted Lists ----");
            Console.Write("Enter First List (space separated): ");
            int[] arr1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Enter Second List (space separated): ");
            int[] arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            ListNode l1 = obj.CreateLinkedList(arr1);
            ListNode l2 = obj.CreateLinkedList(arr2);
            ListNode result = obj.MergeTwoLists(l1, l2);
            Console.WriteLine("Merged Sorted List:");
            obj.PrintLinkedList(result);
        }
    }
}

