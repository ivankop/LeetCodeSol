using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MergeKListsSol
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }
            PriorityQueue<ListNode, int> queue = new PriorityQueue<ListNode, int>();
            foreach (var list in lists)
            {
                var node = list;
                while (node != null)
                {
                    queue.Enqueue(node, node.val);
                    //Console.WriteLine(node.val);
                    node = node.next;
                }
            }

            ListNode head = null;
            if (queue.Count > 0)
                head = queue.Dequeue();
            var tail = head;
            //Console.WriteLine(head.val);
            while (queue.Count > 0)
            {
                var next = queue.Dequeue();
                tail.next = next;
                tail = next;
            }

            if(tail != null)
                tail.next = null;
            return head;
        }
    }
}
