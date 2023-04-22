using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class ReplaceValueInTreeSol
    {
        public TreeNode ReplaceValueInTree(TreeNode root)
        {
            Queue<Tuple<TreeNode, TreeNode>> queue = new Queue<Tuple<TreeNode, TreeNode>>();
            Dictionary<TreeNode, TreeNode> parent = new Dictionary<TreeNode, TreeNode>();
            // parent.Add(root, null);
            if (root.left != null)
            {
                parent.Add(root.left, root);
                queue.Enqueue(new Tuple<TreeNode, TreeNode>(root, root.left));
            }

            if (root.right != null)
            {
                parent.Add(root.right, root);
                queue.Enqueue(new Tuple<TreeNode, TreeNode>(root, root.right));
            }

            while (queue.Count > 0)
            {
                int count = queue.Count;
                Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>();
                List<TreeNode> list = new List<TreeNode>();
                int total = 0;
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (node.Item2 == null)
                        continue;
                    if (!map.ContainsKey(node.Item1))
                    {
                        map.Add(node.Item1, 0);
                    }
                    map[node.Item1] += node.Item2.val;
                    total += node.Item2.val;
                    list.Add(node.Item2);

                    if (node.Item2.left != null)
                    {
                        parent.Add(node.Item2.left, node.Item2);
                        queue.Enqueue(new Tuple<TreeNode, TreeNode>(node.Item2, node.Item2.left));
                    }

                    if (node.Item2.right != null)
                    {
                        parent.Add(node.Item2.right, node.Item2);
                        queue.Enqueue(new Tuple<TreeNode, TreeNode>(node.Item2, node.Item2.right));
                    }

                }
                foreach (var node in list)
                {
                    if (map.ContainsKey(parent[node]))
                    {
                        node.val = total - map[parent[node]];
                    }
                    else
                    {
                        node.val = 0;
                    }
                    
                }

            }
            root.val = 0;
            return root;
        }
    }
}
