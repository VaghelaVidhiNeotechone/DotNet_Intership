using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Leetcode.Add_Two_Numbers;

namespace Leetcode
{
    internal class Remove_Nth_Node_From_End_Of_List
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

        public ListNode removeNthFromEnd(ListNode head, int n)
        {
            ListNode dummyNode = new ListNode(0);
            dummyNode.next = head;

            ListNode slow = dummyNode;
            ListNode fast = dummyNode;

            while (fast.next != null)
            {
                fast = fast.next;
                if (n<=0)
                {
                    slow = slow.next;
                }
                n--;
            }

            slow.next = slow.next.next;

            return dummyNode.next;
        }

        public static void run()
        {
            ListNode head = new ListNode(1,
                                new ListNode(2,
                                    new ListNode(3,
                                        new ListNode(4,
                                            new ListNode(5)))));

            int n = 2;

            Remove_Nth_Node_From_End_Of_List sol = new Remove_Nth_Node_From_End_Of_List();
            ListNode result = sol.removeNthFromEnd(head, n);

            Console.Write("Output: ");
            PrintList(result);
        }

        static void PrintList(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val);
                if (head.next != null)
                    Console.Write(" -> ");
                head = head.next;
            }
            Console.WriteLine();
        }
    }
}
