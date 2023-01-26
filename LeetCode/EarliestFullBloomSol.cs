using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class EarliestFullBloomSol
    {
        public int EarliestFullBloom(int[] plantTime, int[] growTime)
        {
            List<Tuple<int, int, int>> seeds = new List<Tuple<int, int, int>>();
            for (int i = 0; i < plantTime.Length; i++)
            {
                Tuple<int, int, int> seed = new Tuple<int, int, int>(i, plantTime[i], growTime[i]);
                seeds.Add(seed);
            }
            seeds = seeds.OrderByDescending(s => s.Item3).ThenBy(s => s.Item2).ToList();
            int lastPlantTime = seeds[0].Item2;
            int lastGrowTime = lastPlantTime + seeds[0].Item3;
            int ans = lastGrowTime;
            for (int i = 1; i < seeds.Count; i++)
            {
                lastPlantTime += seeds[i].Item2;
                lastGrowTime = lastPlantTime + seeds[i].Item3;
                ans = Math.Max(ans, lastGrowTime);
            }
            return ans;
             
        }
    }
}
