using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LatestTimeCatchTheBusSol
    {
        public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
        {
            SortedDictionary<int, HashSet<int>> busCap = new SortedDictionary<int, HashSet<int>>();
            // Array.Sort(buses);
            // Array.Sort(passengers);
            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            for (int i = 0; i < passengers.Length; i++)
            {
                queue.Enqueue(i, passengers[i]);
            }
            for (int i = 0; i < buses.Length; i++)
            {
                busCap.Add(buses[i], new HashSet<int>());
            }
            List<int> set = new List<int>();
            while (queue.Count > 0)
            {
                var pas = queue.Dequeue();
                bool filled = false;
                foreach (var bus in busCap)
                {
                    if (passengers[pas] <= bus.Key && bus.Value.Count < capacity)
                    {
                        bus.Value.Add(passengers[pas]);
                        set.Add(passengers[pas]);
                        filled = true;
                        break;
                    }
                }
                if (!filled)
                {
                    break;
                }
            }
            int ans = 0;
            for (int i = buses.Length - 1; i >= 0; i--)
            {
                if (busCap[buses[i]].Count < capacity)
                {
                    for (int j = buses[i]; j > 0; j--)
                    {
                        if (!busCap[buses[i]].Contains(j))
                        {
                            return j;
                        }
                    }
                }
                else
                {
                    for (int j = set[set.Count - 1]; j > 0; j--)
                    {
                        if (!set.Contains(j))
                        {
                            return j;
                        }
                    }

                }
                
            }
            
            return ans;
        }
    }
}
