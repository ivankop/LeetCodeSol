using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class TreeQueriesSol2
    {
        Dictionary<int, int> heights;
        Dictionary<int, int> depths;
        Dictionary<int, SortedList<int, int>> levels;
        public int[] TreeQueries(TreeNode root, int[] queries)
        {
            heights = new Dictionary<int, int>();
            depths = new Dictionary<int, int>();
            levels = new Dictionary<int, SortedList<int, int>>();
            // SortedList<int, int> levelHeights = new SortedList<int, int>();

            dfs(root, 0);
            Console.WriteLine("DFS");
            int[] ans = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int maxHeight = depths[queries[i]] - 1;
                int level = depths[queries[i]];
                foreach (var nodeVal in levels[level])
                {
                    if (nodeVal.Value != queries[i])
                    {
                        // var curHeight = heights[nodeVal] + depths[nodeVal];
                        maxHeight = nodeVal.Key + depths[nodeVal.Value];
                        Console.WriteLine($"{nodeVal.Value}");
                        break;
                    }
                }
                ans[i] = maxHeight;
            }
            return ans;
        }

        int dfs(TreeNode node, int depth)
        {
            if (node == null)
            {
                return -1;
            }
            int leftHeight = dfs(node.left, depth + 1) + 1;
            int rightHeight = dfs(node.right, depth + 1) + 1;
            var h = Math.Max(leftHeight, rightHeight);
            heights.Add(node.val, h);
            depths.Add(node.val, depth);
            if (!levels.ContainsKey(depth))
            {
                levels.Add(depth, new SortedList<int, int>(new DuplicateKeyComparator<int>()));
            }
            levels[depth].Add(h, node.val);

            return h;
        }

        class DuplicateKeyComparator<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = y.CompareTo(x);
                if (result == 0)
                {
                    return 1;
                }
                else
                {
                    return result;
                }
            }
        }
    }
}
