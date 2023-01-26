using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class VerticalOrderSol
    {
        Dictionary<int, IList<int>> nodeByLevel;
        Dictionary<int, Dictionary<int, int>> nodesInCol;
        Dictionary<TreeNode, int> nodeCol;
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            nodeByLevel = new Dictionary<int, IList<int>>();
            nodesInCol = new  Dictionary<int, Dictionary<int, int>>();
            nodeCol = new Dictionary<TreeNode, int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            nodeCol.Add(root, 0);
            
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                int currentColumn = nodeCol[node];
                if(!nodeByLevel.ContainsKey(currentColumn))
                {
                    nodeByLevel[currentColumn] = new List<int>();
                    nodeByLevel[currentColumn].Add(node.val);
                }
                else
                {
                    nodeByLevel[currentColumn].Add(node.val);
                }

                if (node.left != null)
                {
                    nodeCol[node.left] = currentColumn - 1;
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {

                    nodeCol[node.right] = currentColumn + 1;
                    queue.Enqueue(node.right);
                }
            }


            // VerticalOrderTraversal(root, 0, 0);

            IList<IList<int>> res = new List<IList<int>>();
            foreach (var item in nodeByLevel.Keys.OrderBy(kv => kv))
            {
                List<int> list = new List<int>();
                foreach (var val in nodeByLevel[item])
                {
                    list.Add(val);
                }
                res.Add(list);
                
            }
            return res;
        }
        private void VerticalOrderTraversal(TreeNode node, int currentColumn, int currentLevel)
        {
            if (node == null)
            {
                return;
            }
            if (!nodesInCol.ContainsKey(currentColumn))
            {
                nodesInCol[currentColumn] = new Dictionary<int, int>();
                nodesInCol[currentColumn].Add(currentLevel, node.val);
            }
            else
            {
                nodesInCol[currentColumn].Add(currentLevel, node.val);
            }
            

            VerticalOrderTraversal(node.left, currentColumn - 1, currentLevel++);
            VerticalOrderTraversal(node.right, currentColumn + 1, currentLevel++);

        }

    }
}
