using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class NumberOfGoodPathsSol2
    {
        Dictionary<int, HashSet<int>> map;
        List<HashSet<int>> paths;
        Dictionary<int, HashSet<int>> nodeToPath;
        Dictionary<int, int> nodeCount;
        public int NumberOfGoodPaths(int[] vals, int[][] edges)
        {
            map = new Dictionary<int, HashSet<int>>();
            paths = new List<HashSet<int>>();
            nodeToPath = new Dictionary<int, HashSet<int>>();
            nodeCount = new Dictionary<int, int>();
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
                countGoodPath(i, i, vals, ref ans, new HashSet<int>());
            }
            
            // ans += vals.Length;
            return ans;
        }

        void countGoodPath(int startNode, int node, int[] vals, ref int count, HashSet<int> visited)
        {
            visited.Add(node);
            
            if (vals[node] == vals[startNode] )
            {
                if (nodeToPath.ContainsKey(node))
                {
                    return;
                }
                if (!nodeToPath.ContainsKey(startNode))
                {
                    
                    nodeToPath.Add(startNode, new HashSet<int>());
                    paths.Add(nodeToPath[startNode]);
                    nodeToPath[startNode].Add(startNode);
                    count += 1;
                }
                if (!nodeToPath.ContainsKey(node))
                {
                    nodeToPath[startNode].Add(node);
                    nodeToPath.Add(node, nodeToPath[startNode]);
                    count += nodeToPath[startNode].Count;
                    //return;
                }
                else
                {
                    // union
                    if (nodeToPath[node] != nodeToPath[startNode])
                    {
                        nodeToPath[node].Add(startNode);
                        paths.Remove(nodeToPath[startNode]);
                        nodeToPath[startNode] = nodeToPath[node];
                        count += nodeToPath[startNode].Count;
                        // return;
                    }
                    else
                    {
                        // skip
                    }
                }
                

            }
            if (map.ContainsKey(node))
            {
                foreach (var nextNode in map[node])
                {
                    if (vals[nextNode] <= vals[startNode] && !visited.Contains(nextNode))
                    {
                        countGoodPath(startNode, nextNode, vals, ref count, new HashSet<int>(visited));
                    }
                }
            }
            
        }
        
    }
}
