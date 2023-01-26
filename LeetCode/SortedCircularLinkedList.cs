using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SortedCircularLinkedList
    {
        public Node Insert(Node head, int insertVal)
        {
            if (head == null)
            {
                head = new Node(insertVal);
                head.next = head;
                return head;
            }

            if (head.next == null || head.next == head)
            {
                var newNode = new Node(insertVal);
                head.next = newNode;
                newNode.next = head;
                return head;
            }

            Dictionary<Node, Node> prevNodeDict = new Dictionary<Node, Node>();
            Node prevNode = null;
            Node nextNode = null;
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            Queue<Node> queue = new Queue<Node>();
            Node currentNode = null;
            queue.Enqueue(head);
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                if (currentNode.val < minValue && currentNode.val >= insertVal)
                {
                    nextNode = currentNode;
                    minValue = currentNode.val;
                }
                if (currentNode.val > maxValue && currentNode.val <= insertVal)
                {
                    prevNode = currentNode;
                    maxValue = currentNode.val;
                }
                prevNodeDict.Add(currentNode.next, currentNode);
                if (currentNode.next != null && currentNode.next != head)
                    queue.Enqueue(currentNode.next);
            }

            Node node = new Node(insertVal);
            if (prevNode == null && nextNode != null)
            {
                prevNode = prevNodeDict[nextNode];
            }
            else if (nextNode == null && prevNode != null)
            {
                nextNode = prevNode.next;
            }
            else
            {
                prevNode = prevNodeDict[nextNode];
            }
            
            prevNode.next = node;
            node.next = nextNode;
            
            
            return head;
        }
    }

    public class Node
    {
        public int val;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            next = null;
        }

        public Node(int _val, Node _next)
        {
            val = _val;
            next = _next;
        }
    }
}
