using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class NumOfMinutesSol
    {
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(manager[i]))
                {
                    map.Add(manager[i], new HashSet<int>());
                }
                map[manager[i]].Add(i);
            }
            Queue<Tuple<int,int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(headID, informTime[headID]));
            var ans = 0;
            while (queue.Count > 0)
            {
                var count = queue.Count();
                for (int i = 0; i < count; i++)
                {
                    var emp = queue.Dequeue();
                    ans = Math.Max(ans, emp.Item2);
                    if (map.ContainsKey(emp.Item1))
                    {
                        foreach (var sub in map[emp.Item1])
                        {
                            queue.Enqueue(new Tuple<int, int>(sub, emp.Item2  + informTime[sub]));
                        }
                    }                    
                }
            }
            return ans;
        }
    }
}
