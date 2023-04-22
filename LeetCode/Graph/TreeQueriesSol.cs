using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class TreeQueriesSol
    {
        List<List<int>> paths;
        PriorityQueue<List<int>, int> queue;
        public int[] TreeQueries1(TreeNode root, int[] queries)
        {
            paths = new List<List<int>>();
            queue = new PriorityQueue<List<int>, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            FindPathDFS(root, new List<int>());

            //paths = paths.OrderByDescending(p => p.Count).ToList();
            while (queue.Count > 0)
            {
                paths.Add(queue.Dequeue());
            }

            // Console.WriteLine($"{queue.Peek().Count}-{paths[0].Count}");
            
            //Array.Sort(paths, p => p.Count);
            int[] ans = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int maxHeight = int.MinValue;
                for (int j = 0; j < paths.Count; j++)
                {                    
                    if (!paths[j].Contains(queries[i]))
                    {
                        if (paths[j].Count - 1 >= maxHeight)
                        {
                            ans[i] = paths[j].Count - 1;
                            break;
                        }

                        // maxHeight = Math.Max(maxHeight, paths[j].Count - 1);
                    }
                    else if (maxHeight == int.MinValue)
                    {
                        maxHeight = Math.Max(maxHeight, paths[j].IndexOf(queries[i]) - 1);
                        // break;
                    }
                }
                ans[i] = Math.Max(ans[i], maxHeight);
            }

            return ans;
        }

        void FindPathDFS(TreeNode node, List<int> path)
        {
            var newPath = new List<int>(path);
            newPath.Add(node.val);
            if (node.left == null && node.right == null)
            {
                queue.Enqueue(newPath, path.Count);
                
                return;
            }
            
            if (node.left != null)
            {
                FindPathDFS(node.left, newPath);
            }

            if (node.right != null)
            {
                FindPathDFS(node.right, newPath);
            }
        }

        public int[] TreeQueries(TreeNode root, int[] queries)
        {
            
            int[] ans = new int[queries.Length];
            int maxHeight = int.MinValue;
            BuildPathDFS(root, ref maxHeight, 0);
            for (int i = 0; i < queries.Length; i++){

                maxHeight = int.MinValue;
                FindDFS(root, ref maxHeight, 0, queries[i]);
                ans[i] = maxHeight;
            }

            return ans;
        }

        Dictionary<int, HashSet<int>> treeNodes = new Dictionary<int, HashSet<int>>();
        Dictionary<int, int> nodeLevels = new Dictionary<int, int>();

        HashSet<int> BuildPathDFS(TreeNode node, ref int maxLevel, int level, int query)
        {
            HashSet<int> childNodes = new HashSet<int>();
            if (node.val == query)
            {
                maxLevel = level - 1;
                return childNodes;
            }

            if (node.left == null && node.right == null)
            {
                maxLevel = level;

                // return childNodes;
            }

            if (treeNodes.ContainsKey(node.val))
            {
                if (treeNodes[node.val].Contains(query))
                {
                    if (node.left != null)
                    {
                        BuildPathDFS(node.left, ref maxLevel, level + 1, query);
                    }
                    if (node.right != null)
                    {
                        BuildPathDFS(node.right, ref maxLevel, level + 1, query);
                    }
                }
                else
                {
                    maxLevel = Math.Max(maxLevel, nodeLevels[node.val]);
                }
                return treeNodes[node.val];
            }

            if (node.left != null)
            {
                childNodes.Add(node.left.val);
                int leftLevel = level;
                var leftNodes = BuildPathDFS(node.left, ref leftLevel, level + 1);
                childNodes.UnionWith(leftNodes);
                maxLevel = leftLevel;
            }

            if (node.right != null)
            {
                childNodes.Add(node.right.val);
                int rightLevel = level;
                var rightNodes = BuildPathDFS(node.right, ref rightLevel, level + 1);
                childNodes.UnionWith(rightNodes);
                maxLevel = Math.Max(maxLevel, rightLevel);
            }
            treeNodes.Add(node.val, childNodes);
            nodeLevels.Add(node.val, maxLevel);
            return childNodes;
        }
        HashSet<int> BuildPathDFS(TreeNode node, ref int maxLevel, int level)
        {
            HashSet<int> childNodes = new HashSet<int>();
           
            if (node.left == null && node.right == null)
            {
                maxLevel = level;
                
                // return childNodes;
            }
            
            if (node.left != null)
            {
                childNodes.Add(node.left.val);
                int leftLevel = level;
                var leftNodes = BuildPathDFS(node.left, ref leftLevel, level + 1);
                childNodes.UnionWith(leftNodes);
                maxLevel = leftLevel;
            }

            if (node.right != null)
            {
                childNodes.Add(node.right.val);
                int rightLevel = level;
                var rightNodes = BuildPathDFS(node.right, ref rightLevel, level + 1);
                childNodes.UnionWith(rightNodes);
                maxLevel = Math.Max(maxLevel, rightLevel);
            }
            treeNodes.Add(node.val, childNodes);
            nodeLevels.Add(node.val, maxLevel);
            return childNodes;
        }

        void FindDFS(TreeNode node, ref int maxLevel, int level, int query)
        {
            if (node == null)
                return;
            if (node.val == query)
            {
                maxLevel = Math.Max(maxLevel, level - 1);
                return;
            }
            if (treeNodes[node.val].Contains(query))
            {
                FindDFS(node.left, ref maxLevel, level + 1, query);
                FindDFS(node.right, ref maxLevel, level + 1, query);
            }
            else
            {
                maxLevel = Math.Max(maxLevel, nodeLevels[node.val]);
            }
        }
    }
}
