using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindLeavesofBinaryTree
    {
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            while (root.left != null || root.right != null)
            {
                List<int> leafNodes = new List<int>();
                FindLeaves(root, leafNodes);
                result.Add(leafNodes);
            }
            var lastNode = new List<int>();
            lastNode.Add(root.val);
            result.Add(lastNode);
            return result;
        }

        private bool FindLeaves(TreeNode node, List<int> leafNodes)
        {
            if (node == null) 
                return false;
            if (node.left == null && node.right == null)
            {
                leafNodes.Add(node.val);
                return true;
            }
            if (FindLeaves(node.left, leafNodes))
            {
                node.left = null;            
            }
            if (FindLeaves(node.right, leafNodes))
            {
                node.right = null;
            }
            return false;
        }
    }
}
