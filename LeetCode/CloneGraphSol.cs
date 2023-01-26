using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class CloneGraphSol
    {
        Dictionary<int, Node> _dict;
        HashSet<int> visited;
        public Node CloneGraph(Node node)
        {
            _dict = new Dictionary<int, Node>();
            visited = new HashSet<int>();
            var ans = CloneRec(node);

            return ans;
        }

        private Node CloneRec(Node node)
        {
            Node newNode;
            if (!_dict.ContainsKey(node.val))
            {
                _dict.Add(node.val, new Node(node.val));
            }
            newNode = _dict[node.val];
            if (!visited.Contains(node.val)) 
            {
                visited.Add(node.val);

                foreach (var item in node.neighbors)
                {
                    newNode.neighbors.Add(CloneRec(item));
                }
            }
            
            return newNode;
        }

        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }
    }

    
}
