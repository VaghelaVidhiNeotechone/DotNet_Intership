using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Swap_Nodes_in_Pairs
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
            if ((head == null) || (head.next == null)) { return head; }
            ListNode node = SwapPairs(head.next.next);

            // Swap
            ListNode temp = head;
            head = head.next;
            head.next = temp;

            // Attach
            head.next.next = node;

            return head;
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
            Swap_Nodes_in_Pairs obj = new Swap_Nodes_in_Pairs();
            Console.WriteLine("---- Swap Nodes in Pairs ----");
            Console.Write("Enter Node List To Swap (space separated): ");
            int[] arr1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            ListNode head = obj.CreateLinkedList(arr1);
            ListNode result = obj.SwapPairs(head);
            Console.WriteLine("Swap Nodes pairs:");
            obj.PrintLinkedList(result);
        }

    }
}
