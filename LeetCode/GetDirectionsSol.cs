using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
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
    public class GetDirectionsSol
    {
        string destPath = string.Empty;
        string startPath = string.Empty;

        public string GetDirections(TreeNode root, int startValue, int destValue)
        {
            DateTime dateTime = DateTime.Now;
            TreeNode lca = null;
            TreeNode destNode = null;
            TreeNode startNode = null;
            destPath = string.Empty;
            startPath = String.Empty;
            findLCA(root, startValue, destValue, ref lca, ref destNode, ref startNode);
            if (lca != null)
            {
                Console.WriteLine((DateTime.Now - dateTime).TotalMilliseconds);
                //dateTime= DateTime.Now;
                //var val = startValue;
                //string startToLCA = string.Empty;
                //while(val != lca.val)
                //{
                //    val = parentDict[val].val;
                //    startToLCA += "U";
                //}
                //Console.WriteLine((DateTime.Now - dateTime).TotalMilliseconds);
                //dateTime = DateTime.Now;
                //string lcaToDest = destPath ;
                
                return startPath + destPath;
            }
            return "";
        }

        private bool findLCA(TreeNode node, int startValue, int destValue, ref TreeNode ans, ref TreeNode destNode, ref TreeNode startNode)
        {
            if (node == null || ans != null)
                return false;
            int mid = 0;
            if (node.val == startValue || node.val == destValue)
                mid = 1;
            //if (node.left != null)
            //{
            //    parentDict[node.left.val] = node;
            //}
            //if (node.right != null)
            //{
            //    parentDict[node.right.val] = node;
            //}
            int left = findLCA(node.left, startValue, destValue, ref ans, ref destNode, ref startNode) ? 1 : 0;
            int right = findLCA(node.right, startValue, destValue, ref ans, ref destNode, ref startNode) ? 1 : 0;

            if (mid + left + right >= 2)
            {
                ans = node;
            }

            if (mid + left + right >= 1)
            {
                if (node.val == destValue)
                {
                    destNode = node;
                }
                else if (node.val == startValue)
                {
                    startNode = node;
                }
                
                if (destNode != null)
                {
                    if (node.left == destNode)
                    {
                        destPath = "L" + destPath;
                        destNode = node;
                    }
                    else if (node.right == destNode)                  
                    {
                        destPath = "R" + destPath;
                        destNode = node;
                    }
                }

                if (startNode != null)
                {
                    if (node.left == startNode || node.right == startNode)
                    {
                        startPath = "U" + startPath;
                        startNode = node;
                    }                    
                }

                if (destNode == ans)
                {
                    destNode = null;
                }

                if (startNode == ans)
                {
                    startNode = null;
                }

                return true;
            }
            return false;
        }
    }
}
