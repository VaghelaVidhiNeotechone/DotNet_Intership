using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_All_Task
{
    internal class Add_Two_Numbers
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode curr = dummyHead;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int x = l1?.val ?? 0;
                int y = l2?.val ?? 0;
                int sum = carry + x + y;
                carry = sum / 10;

                curr.next = new ListNode(sum % 10);
                curr = curr.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return dummyHead.next;
        }

        private static ListNode ArrayToList(int[] arr)
        {
            ListNode head = null, curr = null;
            foreach (var n in arr)
            {
                if (head == null)
                {
                    head = curr = new ListNode(n);
                }
                else
                {
                    curr.next = new ListNode(n);
                    curr = curr.next;
                }
            }
            return head;
        }

        private static void PrintList(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val + (node.next != null ? " -> " : ""));
                node = node.next;
            }
            Console.WriteLine();
        }

        public static void run()
        {
            int[] arr1 = { 2, 5, 3 };
            int[] arr2 = { 7, 2, 5 };

            ListNode l1 = ArrayToList(arr1);
            ListNode l2 = ArrayToList(arr2);

            Add_Two_Numbers solver = new Add_Two_Numbers();
            ListNode res = solver.AddTwoNumbers(l1, l2);

            Console.WriteLine("---- Add Two Numbers ----");
            PrintList(res);
        }
    }
}
