using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class LongestZigZagSol
    {
        int maxLength = 0;
        public int LongestZigZag(TreeNode root)
        {
            var leftCount = ZigZag(root.right, true) ;
            var rightCount = ZigZag(root.left, false) ;
            var tmp = Math.Max(rightCount, leftCount);
            maxLength = Math.Max(tmp, maxLength);
            return maxLength;
        }

        private int ZigZag(TreeNode node, bool isRight)
        {
            if (node == null)
            {
                return 0;
            }
            int leftCount, rightCount;
            if (isRight)
            {
                leftCount = ZigZag(node.left,!isRight ) + 1;
                rightCount = ZigZag(node.right, isRight);
                var tmp = Math.Max(rightCount, leftCount);
                maxLength = Math.Max(tmp, maxLength);
                return leftCount;
            }
            else
            {
                rightCount = ZigZag(node.right, !isRight) + 1;
                leftCount = ZigZag(node.left, isRight);
                var tmp = Math.Max(rightCount, leftCount);
                maxLength = Math.Max(tmp, maxLength);
                return rightCount;
            }

            
        }
    }
}
