using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Remove_Nth_Node_From_End_of_List
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

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode fast = dummy;
            ListNode slow = dummy;
            for (int i = 0; i < n; i++)
            {
                if (fast.next == null)
                {
                    Console.WriteLine("The value of n is greater than the list length.");
                    return head;
                }
                fast = fast.next;
            }
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next?.next;

            return dummy.next;
        }

        public static void PrintList(ListNode head)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.val + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public static void run()
        {
            Remove_Nth_Node_From_End_of_List sol = new Remove_Nth_Node_From_End_of_List();

            Console.WriteLine("---- Remove Nth Node From End of List ----");
            Console.Write("Enter numbers (space separated): ");

            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(" No input provided. Exiting...");
                return;
            }

            int[] arr = Array.ConvertAll(input.Split(), int.Parse);
            ListNode head = null;
            ListNode current = null;
            foreach (int num in arr)
            {
                if (head == null)
                {
                    head = new ListNode(num);
                    current = head;
                }
                else
                {
                    current.next = new ListNode(num);
                    current = current.next;
                }
            }

            Console.Write("Enter n (which node to remove from end): ");
            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine(" Invalid input for n.");
                return;
            }
            Console.WriteLine("\nOriginal list:");
            PrintList(head);
            head = sol.RemoveNthFromEnd(head, n);
            Console.WriteLine($"\nList after removing {n} node(s) from end:");
            PrintList(head);
        }


    }
}
