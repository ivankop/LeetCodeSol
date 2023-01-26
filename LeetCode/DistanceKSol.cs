using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DistanceKSol
    {
        Dictionary<TreeNode, TreeNode> _parent;
        List<int> _ans;
        HashSet<TreeNode> _visited;
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            _parent = new Dictionary<TreeNode, TreeNode>();
            _ans = new List<int>();
            _visited = new HashSet<TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.val == target.val)
                    break;
                
                if (node.left != null)
                {
                    _parent.Add(node.left, node);
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    _parent.Add(node.right, node);
                    queue.Enqueue(node.right);
                }
            }

            dfs(target, k, 0);

            return _ans;

        }

        private void dfs (TreeNode node, int k, int pathLength)
        {
            if (_visited.Contains(node))
                return;
            _visited.Add(node);
            if (pathLength == k)
            {
                _ans.Add(node.val);
                return;
            }
            if(node.left != null)
            {
                dfs(node.left, k, pathLength + 1);
            }
            if (node.right != null)
            {
                dfs(node.right, k, pathLength + 1);
            }
            if (_parent.ContainsKey(node))
            {
                dfs(_parent[node], k, pathLength + 1);
            }
        }

    }
}
