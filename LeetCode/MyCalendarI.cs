using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MyCalendarI
    {
        Booking root;
        public MyCalendarI()
        {

        }

        public bool Book(int start, int end)
        {
            if (root == null)
            {
                root = new Booking(start, end);
                return true;
            }
            var res = AddEvent(root, start, end);
            return res;
        }

        private bool AddEvent(Booking node, int start, int end)
        {
            // overlap
            if ((start >= node.start && end <= node.end) || 
                (end > node.start && end <= node.end) || 
                (start < node.end && start >= node.start )|| 
                (start < node.start && end > node.end)
                )
            {
                return false;
            }
            if (end <= node.start)
            {
                if (node.left != null)
                {
                    return AddEvent(node.left, start, end);
                }
                else
                {
                    // add new event to the left
                    node.left = new Booking(start, end);
                }
            }
            if (start >= node.end)
            {
                if (node.right != null)
                {
                    return AddEvent(node.right, start, end);
                }
                else
                {
                    // add new event to the left
                    node.right = new Booking(start, end);
                }
            }
            return true;
        }

        class Booking
        {
            public int start;
            public int end;
            public Booking left;
            public Booking right;

            public Booking(int start, int end, Booking left = null, Booking right = null)
            {
                this.start = start;
                this.end = end;
                this.left = left;
                this.right = right;
            }
        }
    }


}
