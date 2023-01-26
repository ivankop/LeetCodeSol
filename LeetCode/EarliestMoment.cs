using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class EarliestMoment
    {
        public int EarliestAcq(int[][] logs, int n)
        {
            Dictionary<int, HashSet<int>> dict = new Dictionary<int, HashSet<int>>();
            logs = logs.OrderBy(l => l[0]).ToArray();

            for (int i = 0; i < logs.Length; i++)
            {
                HashSet<int> group = null;
                if (!dict.ContainsKey(logs[i][1]) && !dict.ContainsKey(logs[i][2]))
                {
                    group = new HashSet<int>();
                    group.Add(logs[i][1]);
                    group.Add(logs[i][2]);
                    dict.Add(logs[i][1], group);
                    dict.Add(logs[i][2], group);
                }
                else
                {
                    if (dict.ContainsKey(logs[i][1]))
                    {
                        group = dict[logs[i][1]];
                    }
                    HashSet<int> group2 = null;
                    if (dict.ContainsKey(logs[i][2]))
                    {
                        group2 = dict[logs[i][2]];
                    }
                    
                    if (group == group2 || group == null || group2 == null)
                    {
                        if (group == null)
                        {
                            group = group2;
                        }
                        
                        group.Add(logs[i][1]);
                        group.Add(logs[i][2]);
                    }
                    else if (group2 != null)
                    {
                        // merge
                        group.UnionWith(group2);
                        foreach (var item in group2)
                        {
                            dict[item] = group;
                        }
                    }

                    dict[logs[i][1]] = group;
                    dict[logs[i][2]] = group;

                    if (group.Count == n)
                    {
                        return logs[i][0];
                    }
                }
                
            }
            return -1;
        }
    }
}
