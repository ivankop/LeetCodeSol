using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class CopyRandomPointerLinkedList
    {
        public Node CopyRandomList(Node head)
        {
            //dictionay to store all nodes
            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
            //copy linked list
            Node first = new Node(head.val);
            dict.Add(head, first);
            Node tail = first;
            Node orgHead = head;
            head = head.next;

            while (head != null)
            {
                Node n = new Node(head.val);
                dict.Add(head, n);
                tail.next = n;
                tail = n;
                head = head.next;
            }

            //copy random link
            head = orgHead;
            while(head != null)
            {
                if (head.random != null)
                {
                    dict[head].random = dict[head.random];
                }
                head = head.next;
            }

            return first;
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
