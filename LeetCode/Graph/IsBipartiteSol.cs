using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class IsBipartiteSol
    {
        public bool IsBipartite1(int[][] graph)
        {
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            Dictionary<Tuple<int, int>, bool> mem = new Dictionary<Tuple<int,int>, bool>();
            bool dfs(int target, int node, bool isOdd, HashSet<int> visited)
            {
                if (node == target)
                {
                    if (isOdd)
                    {
                        return true;
                    }
                    return false;
                }
                Tuple<int,int> pos = new Tuple<int, int>(node, target);
                if(mem.ContainsKey(pos))
                {
                    return mem[pos];
                }
                visited.Add(node);
                bool ans = false;
                foreach (var item in map[node])
                {
                    if (!visited.Contains(item))
                    {
                        if(dfs(target, item,!isOdd, visited))
                        {
                            ans = true;
                            break;
                        }
                            

                    }
                }
                mem[pos] = ans;
                return ans;
            }

            for (int i = 0; i < graph.Length; i++)
            {
                map.Add(i, new HashSet<int>());
                for (int j = 0; j < graph[i].Length; j++)
                {
                    map[i].Add(graph[i][j]);
                }
            }
            for (int i = 0; i < graph.Length; i++)
            {
                foreach (var item in map[i])
                {
                    foreach (var item2 in map[item])
                    {
                        if (item2 != i && (map[i].Contains(item2) || dfs(i, item2, false, new HashSet<int>())))
                        {
                            return false;
                        }
                    }

                }
            }
            return true;
        }
        
    }
}
