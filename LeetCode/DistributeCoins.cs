using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class DistributeCoinsSol
    {
        public int DistributeCoins(TreeNode root)
        {
            int count = 0;

            return count;
        }

        private void moveCoins(TreeNode parentNode, TreeNode node, int coins, int count)
        {
            if (node == null)
            {
                return;
            }
            if (node.val > 1)
            {
                node.val = 1;
                count++;
                var remainVal = (coins - 1) / 2;
                moveCoins(parentNode, node.left, remainVal, count);
                moveCoins(parentNode, node.right, remainVal, count);
            }
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
