using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class MinDiffInBSTSol
    {
        public int MinDiffInBST(TreeNode root)
        {
            int minDiff = int.MaxValue;
            var list = DFS(root);
            for (int i = 0; i < list.Count - 1; i++)
            {
                var diff = list[i+1] - list[i];
                minDiff = Math.Min(minDiff, diff);
            }
            return minDiff;
        }

        private List<int> DFS(TreeNode node)
        {
            List<int> list = new List<int>();
            if (node.left != null)
            {
                list.InsertRange(0,DFS(node.left));
            }
            list.Add(node.val);
            if (node.right != null)
            {
                list.AddRange(DFS(node.right));
            }
            return list;
        }

    }
}
