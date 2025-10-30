using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
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
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if(lists != null || lists.Count() > 0)
            {
                List<int> vals= new List<int>();
                foreach(var item in lists)
                {
                    vals = Read(item, vals);
                }
                var oderedList = vals.OrderBy(x => x).ToArray();
                ListNode currNode = default, preNode = default;
                for(int i = oderedList.Length - 1; i >= 0; i--)
                {
                    preNode = currNode;
                    currNode=new ListNode (oderedList[i], preNode);
                }
                return currNode;
            }
            else
            {
                return default;
            }
        }
        private List<int> Read(ListNode node, List<int> val)
        {
            if(node != null)
            {
                val.Add(node.val);
                val=Read(node.next, val);
            }
            return val;
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
                if (current.next != null) Console.Write(" , ");
                current = current.next;
            }
            Console.WriteLine("]");
        }

        public static void run()
        {
            Merge_k_Sorted_Lists obj = new Merge_k_Sorted_Lists();
            Console.WriteLine("---- Merge k Sorted Lists ----");
            Console.Write("Enter the number of lists to merge: ");
            int k;
            while (!int.TryParse(Console.ReadLine(), out k) || k < 0)
            {
                Console.Write("Invalid input. Please enter a non-negative integer: ");
            }
            ListNode[] lists = new ListNode[k];
            for (int i = 0; i < k; i++)
            {
                Console.Write($"Enter List {i + 1} (space separated): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    int[] arr = Array.ConvertAll(input.Split(), int.Parse);
                    lists[i] = obj.CreateLinkedList(arr);
                }
                else
                {
                    lists[i] = null;
                }
            }
            ListNode result = obj.MergeKLists(lists);
            Console.WriteLine("Merged Sorted List:");
            obj.PrintLinkedList(result);
        }
    }
}
