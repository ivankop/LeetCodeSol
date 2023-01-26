using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BuildTreeSol
    {
        HashSet<int> visited;
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> pathCount = new Dictionary<int, int>();
            pathCount.Where(x => x.Value > 0).Select(x => x.Key).ToList();
            visited = new HashSet<int>();
            TreeNode root = new TreeNode(preorder[0]);
            visited.Add(preorder[0]);
            // var parentIndex = Array.IndexOf(inorder, preorder[0]);
            BuildTreeRec(root, 0, preorder, inorder);
            return root;
        }

        private void BuildTreeRec(TreeNode parent, int preorderIndex, int[] preorder, int[] inorder)
        {
            if (preorderIndex == preorder.Length - 1)
            {
                return;
            }
            int leftVal = preorder[preorderIndex+1];
            bool hasLeftNode = false;
            
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == leftVal)
                {
                    hasLeftNode = true;
                    break;
                }
                if (inorder[i] == parent.val)
                {
                    break;
                }
            }
            if (hasLeftNode)
            {
                TreeNode leftNode = new TreeNode(leftVal);
                parent.left = leftNode;
                visited.Add(leftVal);
                BuildTreeRec(leftNode, preorderIndex +1, preorder, inorder);
            }

            int rightValIndex = 0;
            while (rightValIndex < preorder.Length && visited.Contains(preorder[rightValIndex]))
            {
                rightValIndex++;
            }
            if (rightValIndex >= preorder.Length)
            {
                return;
            }
            int rightVal = preorder[rightValIndex];
            bool hasRightNode = true;
            var inorderIndex = -1;
            for (int i = 0; i < inorder.Length - 1; i++)
            {
                if (inorder[i] == parent.val)
                {
                    inorderIndex = i;
                }
                else if (inorderIndex != -1 && inorder[i] == rightVal)
                {
                    break;
                }
                else if (inorderIndex != -1 && visited.Contains(inorder[i]))
                {
                    hasRightNode = false;
                    break;
                }
            }
            if (hasRightNode)
            {
                TreeNode rightNode = new TreeNode(rightVal);
                parent.right = rightNode;
                visited.Add(rightVal);
                BuildTreeRec(rightNode, rightValIndex, preorder, inorder);
            }
        }
    }
}
