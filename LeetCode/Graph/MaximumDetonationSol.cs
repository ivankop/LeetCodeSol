using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class MaximumDetonationSol
    {
        Dictionary<int, int> map;
        public int MaximumDetonation(int[][] bombs)
        {
            map = new Dictionary<int, int>();
            int ans = int.MinValue;
            for (int i = 0; i < bombs.Length; i++)
            {
                int tmp = DFS(bombs, i, new HashSet<int>());
                ans = Math.Max(ans, tmp);
            }
            return ans;
        }

        int DFS(int[][] bombs, int index, HashSet<int> visited)
        {
            if (map.ContainsKey(index))
            {
                //return map[index];
            }
            visited.Add(index);
            int count = 1;
            for (int i = 0; i < bombs.Length; i++)
            {
                if (i != index && !visited.Contains(i))
                {
                    double dis = GetDistance(bombs, index, i);
                    if (dis <= bombs[index][2])
                    {
                        //count++;
                        count += DFS(bombs, i, visited);
                    }
                }
            }
            //map.Add(index, count);
            return count;
        }

        double GetDistance(int[][] bombs, int source, int target)
        {
            return Math.Sqrt(Math.Pow(bombs[source][0] - bombs[target][0], 2) + Math.Pow(bombs[source][1] - bombs[target][1], 2));
        }
    }
}
