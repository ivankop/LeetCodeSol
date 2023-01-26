using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ReverseKGroupSol
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            List<ListNode> list = new List<ListNode>();
            var tail = head;
            while (tail != null)
            {
                list.Add(tail);
                tail = tail.next;
            }
            var ans = ReverseKGroupRec(list, 0, k);
            return ans;
        }

        private ListNode ReverseKGroupRec(List<ListNode> nodes, int index, int k)
        {
            if (index >= nodes.Count)
                return null;
            if(index + k > nodes.Count)
                return nodes[index];
            for (int i = index + k - 1; i > index; i--)
            {
                nodes[i].next = nodes[i - 1];
            }
            nodes[index].next = ReverseKGroupRec(nodes, index + k, k); ;
            return nodes[index + k - 1];
        }
    }
}
