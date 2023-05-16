using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class MaxValueOfCoinsSol
    {
        Dictionary<string, int> mem;
        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            mem = new Dictionary<string, int>();
            int[][] dict = new int[piles.Count][];
            /*
            for (int i = 0; i < piles.Count; i++)
            {
                dict[i] = new int[k];
                for (int j = 0; j < k; j++)
                {
                    dict[i][j] = -1;
                }
            }
            */
            var ans = Pick(piles, k, 0, 0, dict);
            /*
            for (int i = 0; i < piles.Count; i++)
            {
                var tmp = Pick(piles, k, i, 0, 0);
                ans = Math.Max(ans, tmp);
            }
            */

            return ans;
        }
        private int Pick(IList<IList<int>> piles, int k, int pile, int coins, int[][] dict)
        {
            if (pile == piles.Count || coins == k)
            {
                return 0;
            }
            string key = $"{pile};{coins}";
            if(mem.ContainsKey(key))//if (dict[pile][coins] != -1)
            {
                return mem[key];
            }
            var curValue = 0;
            var max = Pick(piles, k, pile + 1, coins, dict);
            for (int i = 0; i < Math.Min(piles[pile].Count, k - coins); i++)
            {
                curValue += piles[pile][i];
                max = Math.Max(max, curValue + Pick(piles, k, pile + 1, coins + i + 1, dict));
            }

            mem[key] = max;
            return max;

        }

        string GetKey(Dictionary<int, int> visited)
        {
            string key = string.Empty;
            foreach (KeyValuePair<int, int> kvp in visited)
            {
                key += $"{kvp.Key}:{kvp.Value};";
            }
            return key;
        }
        IList<IList<int>> Clone(IList<IList<int>> input)
        {
            IList<IList<int>> clone = new List<IList<int>>();
            for (int i = 0; i < input.Count; i++)
            {
                clone.Add(new List<int>(input[i]));
            }
            return clone;
        }
    }
}
