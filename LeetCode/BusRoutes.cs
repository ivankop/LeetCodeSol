using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BusRoutes
    {
        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            Dictionary<int, HashSet<int>> routeSet = new Dictionary<int, HashSet<int>>();
            Queue<int> queue = new Queue<int>();
            int targetRoute = -1;
            for (int i = 0; i < routes.Length; i++)
            {
                routeSet.Add(i, new HashSet<int>());
                for (int j = 0; j < routes[i].Length; j++)
                {
                    routeSet[i].Add(routes[i][j]);
                    if (routes[i][j] == source)
                    {
                        queue.Enqueue(source);
                    }
                    else if (routes[i][j] == target)
                    {
                        targetRoute = i;
                    }
                }
            }
            // bfs

            int stopCount = 0;
            HashSet<int> visited = new HashSet<int>();
            visited.Add(source);
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var stop = queue.Dequeue();
                    if (stop == target)
                    {
                        return stopCount;
                    }
                    else
                    {
                        foreach (var r in routeSet)
                        {
                            if (r.Value.Contains(stop))
                            {
                                for (int j = 0; j < routes[r.Key].Length; j++)
                                {
                                    if (!visited.Contains(routes[r.Key][j]))
                                    {
                                        queue.Enqueue(routes[r.Key][j]);
                                        visited.Add(routes[r.Key][j]);
                                    }
                                }
                            }
                        }
                    }
                }
                stopCount++;
            }
            return -1;
        }

        public int NumBusesToDestination2(int[][] routes, int source, int target)
        {
            Dictionary<int, HashSet<int>> routeSet = new Dictionary<int, HashSet<int>>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < routes.Length; i++)
            {
                for (int j = 0; j < routes[i].Length; j++)
                {
                    if (!routeSet.ContainsKey(routes[i][j]))
                    {
                        routeSet.Add(routes[i][j], new HashSet<int>());
                    }
                    routeSet[routes[i][j]].Add(i);
                }
            }
            // bfs

            int stopCount = 0;
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> visitedRoute = new HashSet<int>();
            queue.Enqueue(source);
            visited.Add(source);
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var stop = queue.Dequeue();
                    if (stop == target)
                    {
                        return stopCount;
                    }
                    else
                    {
                        foreach (var r in routeSet[stop])
                        {
                            if (!visitedRoute.Contains(r))
                            {
                                for (int j = 0; j < routes[r].Length; j++)
                                {
                                    if (!visited.Contains(routes[r][j]))
                                    {
                                        queue.Enqueue(routes[r][j]);
                                        visited.Add(routes[r][j]);
                                    }
                                }
                                visitedRoute.Add(r);
                            }
                        }
                    }
                }
                stopCount++;
            }
            return -1;
        }
    }
    
}
