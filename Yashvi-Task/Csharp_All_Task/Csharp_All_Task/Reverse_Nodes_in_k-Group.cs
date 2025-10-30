using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Reverse_Nodes_in_k_Group
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
            var carrier = new ListNode(next: head);

            var nodes = new ListNode[k];
            var count = 0;
            var start = carrier;
            var node = carrier.next;
            while (node != null)
            {
                nodes[count++] = node;
                node = node.next;
                if (count == k)
                {
                    for (var i = count - 1; i >= 1; i--)
                    {
                        nodes[i].next = nodes[i - 1];
                    }
                    start.next = nodes[count - 1];
                    start = nodes[0];
                    nodes[0].next = node;
                    count = 0;
                }
            }

            return carrier.next;
        }
        private ListNode CreateList(int[] arr)
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

        private void PrintList(ListNode head)
        {
            ListNode curr = head;
            while (curr != null)
            {
                Console.Write(curr.val);
                if (curr.next != null) Console.Write(" -> ");
                curr = curr.next;
            }
            Console.WriteLine();
        }

        public static void run()
        {
            Reverse_Nodes_in_k_Group obj = new Reverse_Nodes_in_k_Group();
            Console.WriteLine("---- Reverse Nodes in k Group ----");
            Console.Write("Enter list elements (space separated): ");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Enter value of k: ");
            int k = Convert.ToInt32(Console.ReadLine());
            ListNode head = obj.CreateList(arr);
            Console.WriteLine("\nOriginal List:");
            obj.PrintList(head);
            ListNode result = obj.ReverseKGroup(head, k);
            Console.WriteLine($"\nList after reversing in groups of {k}:");
            obj.PrintList(result);
        }
    }
}
