using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class BoundaryOfBinaryTreeSol
    {
        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            List<int> result = new List<int>();
            result.Add(root.val);
            findBoundary(root.left, true, ref result);
            findBoundary(root.right, false, ref result);

            return result;
        }

        private void findBoundary(TreeNode node, bool leftBoundary, ref List<int> ans)
        {
            if (node == null)
            {
                return;
            }
            if (leftBoundary)
            {
                if (node.left != null)
                {
                    findBoundary(node.left, true, ref ans);
                }
                else if (node.right != null)
                {
                    ans.Add(node.right.val);
                }
            }
            else
            {
                if (node.right != null)
                {
                    findBoundary(node.right, false, ref ans);
                }
                else if (node.left != null)
                {
                    ans.Add(node.left.val);
                }
            }
        }

    }
}
