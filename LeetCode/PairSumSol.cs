using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class PairSumSol
    {
        public int PairSum(ListNode head)
        {
            var slow = head;
            var fast = head;
            List<int> result = new List<int>();
            while (fast != null)
            {
                result.Add(slow.val);
                slow = head.next;
                fast = head.next.next;
            }
            //show is middle
            var ans = int.MinValue;
            int index = result.Count - 1;
            while (slow != null)
            {
                var twinSum = result[index] + slow.val;
                ans = Math.Max(ans, twinSum);
                index--;
                slow = slow.next;
            }
            return ans;
        }
    }
}
