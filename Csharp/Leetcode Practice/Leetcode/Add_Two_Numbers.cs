using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
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

        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                ListNode dummyHead = new ListNode(0);
                ListNode current = dummyHead;
                int carry = 0;

                while (l1 != null || l2 != null || carry != 0)
                {
                    int x = (l1 != null) ? l1.val : 0;
                    int y = (l2 != null) ? l2.val : 0;

                    int sum = x + y + carry;
                    carry = sum / 10;

                    current.next = new ListNode(sum % 10);
                    current = current.next;

                    if (l1 != null) l1 = l1.next;
                    if (l2 != null) l2 = l2.next;
                }

                return dummyHead.next;
            }
        }



        public static void run()
        {
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));

            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            Solution sol = new Solution();
            ListNode result = sol.AddTwoNumbers(l1, l2);

            PrintList(result);
        }

        static void PrintList(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null)
                    Console.Write(" -> ");
                node = node.next;
            }
            Console.WriteLine();
        }

    }
}
