using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaxProductSol
    {
        int max = 1000000007;
        long ans = long.MinValue;
        public int MaxProduct(TreeNode root)
        {
            ans = -1;
            long sum = findsum(root);
            Console.WriteLine(sum);
            dfs(root, sum);
            Console.WriteLine($"{ans} and {sum}");
            return (int)(ans % max);
        }

        long dfs(TreeNode node, long parentSum)
        {
            long sum = node.val;
            long leftSum = 0;
            long rightSum = 0;
            if (node.left != null)
            {
                leftSum = dfs(node.left, parentSum);
            }

            if (node.right != null)
            {
                rightSum = dfs(node.right, parentSum);
            }
            var p = parentSum - leftSum;
            long left = (parentSum - leftSum) * leftSum;
            long right = (parentSum - rightSum) * rightSum;

            var tmp = Math.Max(left, right);
            ans = Math.Max(ans, tmp);
            if (tmp == -1)
            {
                Console.WriteLine($"{parentSum} and {(parentSum - rightSum) * rightSum}");
                Console.WriteLine($"{leftSum} and {rightSum}");
                Console.WriteLine($"{left} and {right}");
            }

            sum += leftSum + rightSum;
            return sum;
        }

        long findsum(TreeNode node)
        {
            long sum = node.val;
            long leftSum = 0;
            long rightSum = 0;
            if (node.left != null)
            {
                leftSum = findsum(node.left);
            }

            if (node.right != null)
            {
                rightSum = findsum(node.right);
            }

            sum += leftSum + rightSum;
            return sum;
        }
    }
}
