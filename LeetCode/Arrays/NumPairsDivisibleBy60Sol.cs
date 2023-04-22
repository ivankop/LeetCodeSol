using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class NumPairsDivisibleBy60Sol
    {
        public int NumPairsDivisibleBy60(int[] time)
        {
            long count = 0;
            int maxTime = int.MinValue;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < time.Length; i++)
            {
                var mod = time[i] % 60;
                if (!map.ContainsKey(mod))
                {
                    map.Add (mod, 0);
                }
                map[mod]++;
                maxTime = Math.Max(maxTime, time[i]);
            }
            HashSet<int> visited = new HashSet<int>();
            foreach (var kv in map)
            {
                if (kv.Key == 30 || kv.Key == 0)
                {
                    count += ((kv.Value - 1) * kv.Value) / 2;
                }
                //for (int i = 1; i * 60 - kv.Key <= maxTime; i++)
                //{
                //    var key = i * 60 - kv.Key;
                //    if (key != kv.Key && map.ContainsKey(key) && !visited.Contains(key))
                //    {
                //        count += map[key] * kv.Value;
                //    }
                //}

                foreach (var kv2 in map)
                {
                    if (kv2.Key != kv.Key && kv.Key + kv2.Key == 60 && !visited.Contains(kv2.Key))
                    {
                        count += kv2.Value * kv.Value;
                    }
                }

                visited.Add(kv.Key);

            }
            return (int)count;
        }
    }
}
