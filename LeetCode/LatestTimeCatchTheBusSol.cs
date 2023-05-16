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
            // PriorityQueue<int, int> queue = new PriorityQueue<int, int>(new MaxHeapComparer());
            List<SortedSet<int>> busesPass = new List<SortedSet<int>>();
            HashSet<int> passSet = new HashSet<int>();
            Array.Sort(passengers);
            Array.Sort(buses);
            int index = 0;
            int currentCap = 0;
            for (int i = 0; i < buses.Length; i++)
            {
                busesPass.Add(new SortedSet<int>());
                for (int j = index; j < passengers.Length; j++)
                {
                    passSet.Add(passengers[j]);
                    if (passengers[j] <= buses[i])
                    {
                        //queue.Enqueue(passengers[j], passengers[j]);
                        busesPass[i].Add(passengers[j]);
                        currentCap++;
                        if (currentCap == capacity)
                        {
                            index = j + 1;
                            currentCap = 0;
                            break;
                        }
                    }
                    else
                    {
                        index = j;
                        currentCap = 0;
                        break;
                    }

                }
            }
            int ans = 1;
            for (int i = busesPass.Count - 1; i >= 0; i--)
            {
                if (busesPass[i].Count == 0)
                {
                    ans = buses[i];
                    break;
                }
                else if (busesPass[i].Count < capacity)
                {
                    var tmp = FindBusTime(busesPass[i], buses[i]);
                    if (!passSet.Contains(tmp))
                    {
                        ans = tmp;
                        break;
                    }
                }
                else
                {
                    var tmpTime = FindTime(busesPass[i]);
                    if (i > 0 && !busesPass[i - 1].Contains(tmpTime))
                    {
                        ans = tmpTime;
                        break;
                    }
                }
            }
            return ans;
        }

        int FindTime(SortedSet<int> set)
        {
            for (int i = set.Max - 1; i > set.Min; i--)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }
            return set.Min - 1;
        }

        int FindBusTime(SortedSet<int> set, int busTime)
        {
            for (int i = busTime; i > set.Min; i--)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }
            return set.Min - 1;
        }

        public class MaxHeapComparer : IComparer<int>
        {
            public int Compare(int x, int y) => y.CompareTo(x);
        }
    }
}
