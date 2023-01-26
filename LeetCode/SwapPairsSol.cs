using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SwapPairsSol
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head.next == null)
                return head;
            var ans = SwapRec(head);
            return ans;
        }

        private ListNode SwapRec(ListNode currentNode)
        {
            if (currentNode == null)
            {
                return null;
            }
            var nextNext = currentNode.next.next;
            var next = currentNode.next;
            next.next = currentNode;
            currentNode.next = SwapRec(nextNext);
            return next;
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
