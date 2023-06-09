using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class TopKFrequentSol
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (!map.ContainsKey(i))
                {
                    map.Add(i, 0);
                }
                map[i]++;
            }
            var ans = map.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).Take(k).ToArray();
            return ans;
        }
    }
}
