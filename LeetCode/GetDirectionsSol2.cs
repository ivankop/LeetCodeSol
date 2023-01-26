using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    
    public class GetDirectionsSol2
    {
        Dictionary<TreeNode, TreeNode> _parent = new Dictionary<TreeNode, TreeNode>();
        HashSet<TreeNode> visited = new HashSet<TreeNode>();
        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            DateTime dateTime = DateTime.Now;
            var startNode = findNodeDFS(root, startValue);
            string path = string.Empty;
            Console.WriteLine((DateTime.Now - dateTime).TotalMilliseconds);            
            var res = findPathDFS(startNode, destValue, ref path);
            //// var res = findPathBFS(startNode, destValue);
            return path;
        }
        private TreeNode findNodeDFS(TreeNode node, int value)
        {
            if (node.val == value)
            {
                return node;
            }

            TreeNode res = null;
            if (node.left != null)
            {
                _parent[node.left] = node;
                res = findNodeDFS(node.left, value);
            }

            if (res != null)
                return res;

            if (node.right != null)
            {
                _parent[node.right] = node;
                res = findNodeDFS(node.right, value);
            }

            if (res != null)
                return res;
            return null;
        }

        private string findPathBFS(TreeNode node, int destValue)
        {
            Queue<Tuple<TreeNode, string>> queue = new Queue<Tuple<TreeNode, string>>();
            queue.Enqueue(new Tuple<TreeNode, string>(node, string.Empty));
            
            while (queue.Count > 0)
            {
                var lastNode = queue.Dequeue();
                if (visited.Contains(lastNode.Item1))
                {
                    continue;
                }
                if (lastNode.Item1.val == destValue)
                    return lastNode.Item2;
                visited.Add(lastNode.Item1);
                if (lastNode.Item1.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, string>(lastNode.Item1.left, lastNode.Item2 + "L"));
                }
                if (lastNode.Item1.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, string>(lastNode.Item1.right, lastNode.Item2 + "R"));
                }
                if (_parent.ContainsKey(lastNode.Item1))
                {
                    queue.Enqueue(new Tuple<TreeNode, string>(_parent[lastNode.Item1], lastNode.Item2 + "U"));
                }
            }
            return null;
        }

        private TreeNode findPathDFS(TreeNode node, int destValue, ref string path)
        {
            if (node == null || visited.Contains(node))   
                return null;
            if (destValue == node.val)
                return node;
            visited.Add(node);
            TreeNode res = null;
            if (node.left != null)
            {
                res = findPathDFS(node.left, destValue, ref path);
            }

            if (res != null)
            {
                path = "L" + path;
                return res;
            }

            if (node.right != null)
            {
                
                res = findPathDFS(node.right, destValue, ref path);
            }

            if (res != null)
            {
                path = "R" + path;
                return res;
            }

            if (_parent.ContainsKey(node) && !visited.Contains(_parent[node]))
            {
                res = findPathDFS(_parent[node], destValue, ref path);
            }
            
            if (res != null)
            {
                path = "U" + path;
            }
            return res;
        }
    }

    


}
