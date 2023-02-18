using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class ShortestAlternatingPathsSol
    {
        Dictionary<int, HashSet<int>> redPaths;
        Dictionary<int, HashSet<int>> bluePaths;
        public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
        {
            redPaths = new Dictionary<int, HashSet<int>>();
            bluePaths = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < redEdges.Length; i++)
            {
                if (!redPaths.ContainsKey(redEdges[i][0]))
                {
                    redPaths.Add(redEdges[i][0], new HashSet<int>());
                }
                redPaths[redEdges[i][0]].Add(redEdges[i][1]);
            }

            for (int i = 0; i < blueEdges.Length; i++)
            {
                if (!bluePaths.ContainsKey(blueEdges[i][0]))
                {
                    bluePaths.Add(blueEdges[i][0], new HashSet<int>());
                }
                bluePaths[blueEdges[i][0]].Add(blueEdges[i][1]);
            }
            int[] ans = new int[n];
            for (int i = 0; i < n; i++)
            {
                int redPath = ShortestPath(i, true);
                int bluePath = ShortestPath(i, false);
                int tmp = Math.Min(redPath, bluePath);
                ans[i] = tmp == int.MaxValue ? -1 : tmp;
            }
            return ans;
        }

        int ShortestPath(int target, bool isRed)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int step = 0;
            HashSet<Tuple<int, bool>> visited = new HashSet<Tuple<int, bool>>();
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    int node = queue.Dequeue();
                    if (node == target)
                        return step;

                    visited.Add(new Tuple<int, bool>(node, isRed));
                    if (isRed)
                    {
                        if (bluePaths.ContainsKey(node))
                        {
                            foreach (var nextNode in bluePaths[node])
                            {
                                var tmp = new Tuple<int, bool>(nextNode, !isRed);
                                if (!visited.Contains(tmp))
                                {
                                    queue.Enqueue(nextNode);
                                }
                            }
                        }
                    }
                    else if (redPaths.ContainsKey(node))
                    {
                        foreach (var nextNode in redPaths[node])
                        {
                            var tmp = new Tuple<int, bool>(nextNode, !isRed);
                            if (!visited.Contains(tmp))
                            {
                                queue.Enqueue(nextNode);
                            }
                        }
                    }
                }
                
                isRed = !isRed;
                step++;
            }

            return int.MaxValue;
        }
    }
}
