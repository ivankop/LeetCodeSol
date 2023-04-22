using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class NumberOfGoodPathsSol
    {
        Dictionary<int, HashSet<int>> map;
        HashSet<int> removedNodes;
        public int NumberOfGoodPaths(int[] vals, int[][] edges)
        {
            map = new Dictionary<int, HashSet<int>>();
            removedNodes = new HashSet<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                if (!map.ContainsKey(edges[i][0]))
                {
                    map.Add(edges[i][0], new HashSet<int>());
                }

                if (!map.ContainsKey(edges[i][1]))
                {
                    map.Add(edges[i][1], new HashSet<int>());
                }
                map[edges[i][0]].Add(edges[i][1]);
                map[edges[i][1]].Add(edges[i][0]);
            }
            int ans = 0;
            for (int i = 0; i < vals.Length; i++)
            {
                countGoodPath(vals[i], i, vals, ref ans);
                removedNodes.Add(i);
            }
            return ans;
        }

        void countGoodPath(int startNode, int node, int[] vals, ref int count)
        {
            // visited.Add(node);
            
            if (vals[node] == vals[startNode] )
            {
                count++;
                if(node != startNode && !removedNodes.Contains(node))
                {
                    removedNodes.Add(node);
                }
            }
            if (map.ContainsKey(node))
            {
                foreach (var nextNode in map[node])
                {
                    if (vals[nextNode] <= vals[startNode] && !removedNodes.Contains(nextNode))
                    {
                        countGoodPath(startNode, nextNode, vals, ref count);
                    }
                }
            }
            
        }
        
    }
}
