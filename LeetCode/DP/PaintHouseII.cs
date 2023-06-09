using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class PaintHouseII
    {
        public int MinCostII(int[][] costs)
        {
            int n = costs.Length;
            int k = costs[0].Length;
            List<List<int>> sortedCost = new List<List<int>>();
            int[][] dp = new int[n][];
            List<HashSet<int>> visited = new List<HashSet<int>>();
            
            for (int i = 0; i < costs[0].Length; i++)
            {
                visited.Add(new HashSet<int>());
                visited[i].Add(i);
            }
            foreach (int[] row in costs)
            {
                List<Tuple<int, int>> list = new List<Tuple<int, int>>();

                for (int i = 0; i < row.Length; i++)
                {
                    list.Add(new Tuple<int, int>(row[i], i));
                }
                sortedCost.Add(list.OrderBy(x => x.Item1).Select(x => x.Item2).ToList());
            }
            
            dp[0] = costs[0];
            if (n == 1)
            {
                return costs[0][sortedCost[0][0]];
            }
            int ans = int.MaxValue;
            for (int i = 1; i < costs.Length; i++)
            {
                dp[i] = new int[k];
                for (int j = 0; j < costs[i].Length; j++)
                {
                    int index = FindMinCost(i,j, sortedCost, visited);
                    visited[j].Add(index);
                    dp[i][j] = dp[i-1][j] + costs[i][index];
                    if (i == costs.Length - 1)
                    {
                        ans = Math.Min(ans, dp[i][j]);
                    }
                    
                }
            }
            return ans;
        }
        int FindMinCost(int row, int col, List<List<int>> sortedCost, List<HashSet<int>> visited)
        {
            for (int i = 0; i < sortedCost[row].Count; i++)
            {
                if (!visited[col].Contains(sortedCost[row][i]))
                {
                    return sortedCost[row][i];
                }
            }
            return 0;
        }
    }
}
