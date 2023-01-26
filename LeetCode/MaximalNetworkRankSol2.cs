using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaximalNetworkRankSol2
    {
        public int MaximalNetworkRank(int n, int[][] roads)
        {
            if (roads == null || roads.Length == 0)
            {
                return 0;
            }
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < roads.Length; i++)
            {
                if (!map.ContainsKey(roads[i][0]))
                {
                    map.Add(roads[i][0], new HashSet<int>());
                }
                if (!map.ContainsKey(roads[i][1]))
                {
                    map.Add(roads[i][1], new HashSet<int>());
                }
                map[roads[i][0]].Add(roads[i][1]);
                map[roads[i][1]].Add(roads[i][0]);
            }
            int ans = int.MinValue;
            for (int i = 0; i < n - 1; i++)
            {
                if (map.ContainsKey(i))
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (map.ContainsKey(j))
                        {
                            ans = Math.Max(ans, GetNetworkRank(i, j, map));
                        }
                    }
                }
                
            }
            return ans;
        }

        private int GetNetworkRank(int org, int dest, Dictionary<int, HashSet<int>> map)
        {
            int rank = map[org].Count + map[dest].Count;
            if (map[org].Contains(dest) || map[dest].Contains(org))
            {
                rank--;
            }
            
            return rank;
        }
    }
}
