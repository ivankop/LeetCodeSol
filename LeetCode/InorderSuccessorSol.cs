using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class InorderSuccessorSol
    {
        PriorityQueue<TreeNode, int> priorityQueue;
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            priorityQueue = new PriorityQueue<TreeNode, int>();
            dfs(root, p);
            if (priorityQueue.Count == 0)
            {
                return null;
            }
            return priorityQueue.Dequeue();
        }

        private void dfs(TreeNode node, TreeNode p)
        {
            if (node == null)
                return;
            if (node.val > p.val)
            {
                priorityQueue.Enqueue(node, node.val);
            }
            dfs(node.left, p);
            dfs(node.right, p);
        }
    }
}
