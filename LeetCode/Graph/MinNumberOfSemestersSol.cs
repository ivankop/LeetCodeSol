using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class MinNumberOfSemestersSol
    {
        Dictionary<int, HashSet<int>> sems;
        Dictionary<int, HashSet<int>> levels;
        Dictionary<int, HashSet<int>> next;
        Dictionary<int, int> semsLevel;
        public int MinNumberOfSemesters1(int n, int[][] relations, int k)
        {
            if (k == 1)
            {
                return n;
            }
            sems = new Dictionary<int, HashSet<int>>();
            semsLevel = new Dictionary<int, int>();
            levels = new Dictionary<int, HashSet<int>>();
            next = new Dictionary<int, HashSet<int>>();
            foreach (var relation in relations)
            {
                if (!sems.ContainsKey(relation[1]))
                {
                    sems.Add(relation[1], new HashSet<int>());
                }
                if(!next.ContainsKey(relation[0]))
                {
                    next.Add(relation[0], new HashSet<int>());
                }
                sems[relation[1]].Add(relation[0]);
                next[relation[0]].Add(relation[1]);
            }
            for (int i = 1; i <= n; i++)
            {
                if (!sems.ContainsKey(i))
                {
                    sems.Add(i, new HashSet<int>());
                }
                if (!next.ContainsKey(i))
                {
                    next.Add(i, new HashSet<int>());
                }
                FindLevel(i, 0);
            }

            for (int i = 1; i <= n; i++)
            {
                if (!sems.ContainsKey(i) && !next.ContainsKey(i))
                {
                    levels[0].Add(i);
                }               
            }
            // var semsOrder = next.OrderByDescending(kv => kv.Value.Count).Select(kv => kv.Key).ToList();
            var maxLevel = levels.Keys.Max();
            int count = 0;
            HashSet<int> completed = new HashSet<int>();
            while (completed.Count < n)
            {
                HashSet<int> currentSem = new HashSet<int>();
                for (int i = maxLevel; i >= 0 && currentSem.Count < k; i--)
                {
                    var nodes = levels[i].OrderByDescending(l => next[l].Count).Select(l => l).ToList();
                    foreach (var node in nodes)
                    {
                        if (!completed.Contains(node) && (sems[node].Count == 0 || sems[node].IsSubsetOf(completed)))
                        {
                            currentSem.Add(node);
                            if (currentSem.Count == k)
                            {
                                break;
                            }
                        }
                    }
                }
                
                completed.UnionWith(currentSem);
                count++;
            }
            return count;
        }

        public int MinNumberOfSemesters(int n, int[][] relations, int k)
        {
            if (k == 1)
            {
                return n;
            }
            sems = new Dictionary<int, HashSet<int>>();
            semsLevel = new Dictionary<int, int>();
            levels = new Dictionary<int, HashSet<int>>();
            next = new Dictionary<int, HashSet<int>>();
            minStep = int.MaxValue;
            foreach (var relation in relations)
            {
                if (!sems.ContainsKey(relation[1]))
                {
                    sems.Add(relation[1], new HashSet<int>());
                }
                if (!next.ContainsKey(relation[0]))
                {
                    next.Add(relation[0], new HashSet<int>());
                }
                sems[relation[1]].Add(relation[0]);
                next[relation[0]].Add(relation[1]);
            }
            for (int i = 1; i <= n; i++)
            {
                if (!sems.ContainsKey(i))
                {
                    sems.Add(i, new HashSet<int>());
                }
                if (!next.ContainsKey(i))
                {
                    next.Add(i, new HashSet<int>());
                }
                //FindLevel(i, 0);
            }

            for (int i = 1; i <= n; i++)
            {
                if (!sems.ContainsKey(i) && !next.ContainsKey(i))
                {
                    levels[0].Add(i);
                }
            }
            // var semsOrder = next.OrderByDescending(kv => kv.Value.Count).Select(kv => kv.Key).ToList();
            DFS(new List<int>(), sems.Keys.ToList(), new HashSet<int>(), k , 0);
            return minStep;
        }

        void CreateCombination(List<int> input, int index, List<int> included, List<List<int>> combination,int k)
        {
            if (included.Count == k)
            {
                combination.Add(included);
                return;
            }

            if (index == input.Count)
            {
                return;
            }
            
            CreateCombination(input, index + 1, new List<int>(included), combination, k);
            included.Add(input[index]);
            CreateCombination(input, index + 1, new List<int>(included), combination, k);
        }
        int minStep = int.MaxValue;
        void DFS(List<int> currentSems, List<int> allSems, HashSet<int> taken, int k, int step)
        {
            taken.UnionWith(currentSems);
            if (taken.Count == allSems.Count)
            {
                minStep = Math.Min(minStep, step);
                return;
            }
            List<int> nextSems = new List<int>();
            foreach (var sem in allSems)
            {
                if (!taken.Contains(sem) && (sems[sem].Count == 0 || sems[sem].IsSubsetOf(taken)))
                {
                    nextSems.Add(sem);
                }
            }
            List<List<int>> combs = new List<List<int>>();
            if (nextSems.Count > k)
            {
                CreateCombination(nextSems, 0, new List<int>(), combs, k);
            }
            else
            {
                combs.Add(nextSems);
            }
            
            foreach (var comb in combs)
            {
                DFS(comb, allSems, new HashSet<int>(taken), k, step + 1);
            }
        }

        void FindLevel(int n, int level)
        {
            if (semsLevel.ContainsKey(n))
            {
                if (semsLevel[n] < level)
                {
                    levels[semsLevel[n]].Remove(n);
                    semsLevel[n] = level;
                }
                else
                {
                    return;
                }
            }
            else
            {
                semsLevel.Add(n, level);
            }
            if (!levels.ContainsKey(level))
            {
                levels.Add(level, new HashSet<int>());
            }
            levels[level].Add(n);

            if (sems.ContainsKey(n))
            {
                foreach (var prevSem in sems[n])
                {
                    FindLevel(prevSem, level + 1);
                }
            }
            
        }
    }
}
