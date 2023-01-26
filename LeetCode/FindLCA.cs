using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class FindLCA
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode ans = null;
            dsa(root, p,q, ref ans);
            return ans;
        }

        private bool dsa(TreeNode node, TreeNode p, TreeNode q, ref TreeNode ans)
        {
            if (node == null)
                return false;
            int mid = 0;
            if (node.val == p.val || node.val == q.val)
                mid = 1;
            int left = dsa(node.left, p, q, ref ans) ? 1 : 0;
            int right = dsa(node.right, p, q, ref ans) ? 1 : 0;

            if (mid + left + right >= 2)
            {
                ans = node;
            }

            if (mid + left + right >= 1 )
            {
                return true;
            }
            return false;
        }
    }
}
