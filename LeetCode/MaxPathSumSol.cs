using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaxPathSumSol
    {
        public int MaxPathSum(TreeNode root)
        {
            PathSum(root);
            return maxSum;
        }
        int MIN_VAL = -2000;
        int maxSum = -2000;
        private int PathSum(TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                if (node.val > maxSum)
                    maxSum = node.val;
                return node.val;
            }

            int leftSum = MIN_VAL, rightSum = MIN_VAL;
            if (node.left != null)
            {
                leftSum = PathSum(node.left);
            }
            if (node.right != null)
            {
                rightSum = PathSum(node.right);
            }

            var leftWithParent = leftSum + node.val;
            var rightWithParent = rightSum + node.val;
            var leftAndRight = leftSum + node.val + rightSum;
            var tmp = Math.Max(leftWithParent, rightWithParent);
            maxSum = Math.Max(Math.Max(tmp, leftAndRight), maxSum);

            return tmp;
        }
    }
}
