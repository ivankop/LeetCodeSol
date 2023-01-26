using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinTimeToCollectApple
    {
        Dictionary<int, List<int>> map;
        HashSet<int> visited;
        public int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            map = new Dictionary<int, List<int>>();
            visited = new HashSet<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                if (!map.ContainsKey(edges[i][0]))
                {
                    map.Add(edges[i][0], new List<int>());
                }
                if (!map.ContainsKey(edges[i][1]))
                {
                    map.Add(edges[i][1], new List<int>());
                }
                map[edges[i][0]].Add(edges[i][1]);
                map[edges[i][1]].Add(edges[i][0]);
            }
            int ans = 0;
            MinTimeRec(0, edges, hasApple, ref ans);

            return ans;
        }

        private bool MinTimeRec(int node, int[][] edges, IList<bool> hasApple, ref int time)
        {
            bool isApple = false;
            if (hasApple[node] == true)
            {
                isApple = true;
            }
            visited.Add(node);
            if (map.ContainsKey(node))
            {
                for (int i = 0; i < map[node].Count; i++)
                {
                    if (!visited.Contains(map[node][i]) && MinTimeRec(map[node][i], edges, hasApple, ref time))
                    {
                        isApple = true;
                        time += 2;
                    }
                }
            }
            

            return isApple;
        }
    }
}
