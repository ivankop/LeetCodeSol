using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class ParallelCourses
    {
        public int MinimumSemesters(int n, int[][] relations)
        {
            Dictionary<int, HashSet<int>> previousCourses = new Dictionary<int, HashSet<int>>();
            int semCount = 0;
            for (int i = 0; i < relations.Length; i++)
            {
                if (!previousCourses.ContainsKey(relations[i][1]))
                {
                    previousCourses.Add(relations[i][1], new HashSet<int>());
                }
                previousCourses[relations[i][1]].Add(relations[i][0]);
            }

            HashSet<int> taken = new HashSet<int>();
            while (taken.Count < n)
            {
                HashSet<int> currentSem = new HashSet<int>();
                for (int i = 1; i <= n; i++)
                {
                    if (!previousCourses.ContainsKey(i) && !taken.Contains(i))
                    {
                        currentSem.Add(i);
                    }
                    else if(!taken.Contains(i))
                    {
                        if (previousCourses[i].All(c => taken.Contains(c)))
                        {
                            currentSem.Add(i);
                        }
                        else
                        {
                            //return -1;
                        }
                    }
                }
                if (currentSem.Count == 0)
                {
                    return -1;
                }
                taken.UnionWith(currentSem);
                semCount++;
            }
            return semCount;
        }
    }
}
