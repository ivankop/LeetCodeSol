using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WidthOfBinaryTreeSol
    {
        public int WidthOfBinaryTree(TreeNode root)
        {
            Queue<Tuple<TreeNode, int, long>> queue = new Queue<Tuple<TreeNode, int, long>>();
            // node, level, parent width
            queue.Enqueue(new Tuple<TreeNode, int, long>(root, 1, 1));
            Dictionary<int, HashSet<long>> widthByLevel = new Dictionary<int, HashSet<long>>();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var level = node.Item2;
                if (!widthByLevel.ContainsKey(level))
                {
                    widthByLevel.Add(level, new HashSet<long>());
                }
                widthByLevel[level].Add(node.Item3);
                var pos = node.Item3 * 2;
                if (node.Item1.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int, long>(node.Item1.left, level + 1, pos - 1));
                }
                if (node.Item1.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int, long>(node.Item1.right, level + 1, pos));
                }
            }
            long maxWidth = 0;
            foreach (var level in widthByLevel.Keys)
            {
                var min = widthByLevel[level].Min();
                var max = widthByLevel[level].Max();
                var tmp = max - min;
                if (tmp > maxWidth)
                {
                    maxWidth = tmp;
                }
            }
            return maxWidth > int.MaxValue ? int.MaxValue : (int)maxWidth;
        }
    }
}
