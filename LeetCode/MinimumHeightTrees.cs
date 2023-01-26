using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinimumHeightTrees
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (edges == null || edges.Length == 0)
                return new List<int>(new int[] { 0 });

            if (n == 2)
                return new List<int>(new int[] { edges[0][1], edges[0][0] });

            Dictionary<int, HashSet<int>> pathCount = new Dictionary<int, HashSet<int>>();

            int[] nodeCount = new int[n];
            for (int i = 0; i < edges.Length; i++)
            {
                nodeCount[edges[i][0]]++;
                nodeCount[edges[i][1]]++;

                if (!pathCount.ContainsKey(edges[i][0]))
                {
                    pathCount.Add(edges[i][0], new HashSet<int>());
                }
                pathCount[edges[i][0]].Add(edges[i][1]);


                if (!pathCount.ContainsKey(edges[i][1]))
                {
                    pathCount.Add(edges[i][1], new HashSet<int>());
                }
                pathCount[edges[i][1]].Add(edges[i][0]);
            }
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < nodeCount.Length; i++)
            {
                if (nodeCount[i] == 1)
                {
                    queue.Enqueue(i);
                }
                
            }
            var remaining = n;
            while (remaining > 2 && queue.Count > 0)
            {
                Queue<int> tmp = new Queue<int>();
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    remaining--;
                    foreach (var item in pathCount[node])
                    {
                        nodeCount[item]--;
                        if (nodeCount[item] == 1)
                        {
                            tmp.Enqueue(item);
                        }
                    }
                }
                queue = tmp;
            }
            var ans = new List<int>();
            while (queue.Count > 0)
            {
                ans.Add(queue.Dequeue());
            }
            
            return ans;
        }
        
    }
}
