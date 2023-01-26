using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class MergeTwoListsSol
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
                return null;
            
            ListNode first = new ListNode(getNextValue(ref list1, ref list2));
            ListNode last = first;
            while (list1 != null || list2 != null)
            {
                ListNode node = new ListNode(getNextValue(ref list1, ref list2));
                last.next = node;
                last = node;
            }

            return first;

        }

        private int getNextValue(ref ListNode list1, ref ListNode list2)
        {
            int val;
            if (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    val = list1.val;
                    list1 = list1.next;
                }
                else
                {
                    val = list2.val;
                    list2 = list2.next;
                }
            }
            else
            {
                if (list1 == null)
                {
                    val = list2.val;
                    list2 = list2.next;
                }
                else
                {
                    val = list1.val;
                    list1 = list1.next;
                }
            }

            return val;
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
}
