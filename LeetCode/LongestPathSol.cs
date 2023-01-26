using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LongestPathSol
    {
        Dictionary<int, int> mem;
        int longestPath = int.MinValue;
        public int LongestPath(int[] parent, string s)
        {
            mem = new Dictionary<int, int>();
            longestPath = int.MinValue;
            Dictionary<int, CharNode> dict = new Dictionary<int, CharNode>();
            CharNode root = new CharNode(s[0], 0);
            dict.Add(0, root);
            for (int i = 1; i < parent.Length; i++)
            {
                if (!dict.ContainsKey(i))
                {
                    dict.Add(i, new CharNode(s[i], i));
                }
                if (!dict.ContainsKey(parent[i]))
                {
                    dict.Add(parent[i], new CharNode(s[parent[i]], parent[i]));
                }
                dict[i].parent = dict[parent[i]];
                dict[parent[i]].children.Add(dict[i]);
            }

            var tmp = dfs2(root);
            longestPath = Math.Max(longestPath, tmp);
            /*
            int ans = int.MinValue;
            foreach (var kv in dict)
            {
                var tmp = dfs(kv.Value, new HashSet<int>());
                ans = Math.Max(tmp, ans);
            }*/
            return longestPath;
        }

        

        private int dfs2(CharNode node)
        {
            List<int> list = new List<int>();
            if (node.children.Count > 0)
            {
                foreach (var child in node.children)
                {
                    if (child.value != node.value)
                    {
                        var tmp = dfs2(child);
                        list.Add(tmp);
                    }
                    else
                    {
                        dfs2(child);
                    }
                }
            }
            else
            {
                return 1;
            }
            int maxLength = 1;
            //top 2
            list = list.OrderByDescending(x => x).ToList();
            int index = 0;
            while (list.Count > 0 && index < 2 && index <= list.Count - 1)
            {
                maxLength += list[index];
                index++;
            }
            longestPath = Math.Max(longestPath, maxLength);
            return list.Count > 0 ? list[0] + 1 : 1;
        }

        private int dfs(CharNode node, HashSet<int> visited)
        {
            if (visited.Contains(node.id))
            {
                return 0;
            }
            visited.Add(node.id);
            int pathLength = 1;
            if (node.parent != null && node.parent.value != node.value)
            {
                pathLength = dfs(node.parent, visited) + 1;
            }
            if (node.children != null)
            {
                foreach (var child in node.children)
                {
                    if (child.value != node.value && !visited.Contains(child.id))
                    {
                        int childLength;
                        if (mem.ContainsKey(child.id))
                            childLength = mem[child.id] + 1;
                        else
                        {
                            childLength = dfs(child, visited) + 1;
                            mem.Add(child.id, childLength - 1);
                        }
                        pathLength = Math.Max(pathLength, childLength);
                    }
                }
            }
            return pathLength;
        }


        class CharNode
        {
            public int id;
            public char value;
            public List<CharNode> children;
            public CharNode parent;

            public CharNode(char value, int id)
            {
                this.value = value;
                this.id = id;
                this.children = new List<CharNode>();
                // this.parent = parent;
            }
        }
    }
}
