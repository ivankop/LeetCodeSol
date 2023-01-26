using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindCheapestPriceSol
    {
        Dictionary<int, HashSet<Tuple<int, int>>> graph;
        Dictionary<int, Tuple<int, int>> mem;
        Dictionary<int, bool> visited;
        public int FindCheapestPrice_DFS(int n, int[][] flights, int src, int dst, int k)
        {
            graph = new Dictionary<int, HashSet<Tuple<int, int>>>();
            mem = new Dictionary<int, Tuple<int, int>>();
            visited = new Dictionary<int, bool>();
            for (int i = 0; i < flights.Length; i++)
            {
                var from = flights[i][0];
                var to = flights[i][1];
                var price = flights[i][2];
                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new HashSet<Tuple<int, int>>());
                }
                graph[from].Add(new Tuple<int, int>(to, price));
            }
            dfs(src, dst, k, -1, 0);
            return minVal != MIN_VAL ? minVal : -1;
        }

        int MIN_VAL = 200000;
        int minVal = 200000;
        private int dfs(int src, int dst, int k, int stop, int cost) 
        {
            if (stop > k)
            {
                return MIN_VAL;
            }
            
            if (src == dst && stop <= k)
            {
                if (cost < minVal)
                {
                    minVal = cost;
                }
                return cost;
            }

            if (mem.ContainsKey(src))
            {
                if (mem[src].Item1 + cost < minVal && mem[src].Item2 + stop <= k)
                {
                    minVal = mem[src].Item1 + cost;
                    return mem[src].Item1 + cost;
                }
            }
            var minCost = MIN_VAL;
            visited[src] = true;
            if (stop < k && graph.ContainsKey(src))
            {
                
                foreach (var item in graph[src])
                {
                    if ((!visited.ContainsKey(item.Item1) || visited[item.Item1]  == false) && item.Item2 + cost <= minVal)
                    {
                        var tmp = dfs(item.Item1, dst, k, stop + 1, item.Item2 + cost);
                        minCost = Math.Min(minCost, tmp - cost);
                    }
                }

                if (!mem.ContainsKey(src))
                {
                    mem[src] = new Tuple<int, int>(minCost, stop - 1);
                }
                
                minCost += cost;
            }
            visited[src] = false;
            return minCost;
        }

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            graph = new Dictionary<int, HashSet<Tuple<int, int>>>();
            int[] cost = new int[n];
            for (int i = 0; i < flights.Length; i++)
            {
                var from = flights[i][0];
                var to = flights[i][1];
                var price = flights[i][2];
                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new HashSet<Tuple<int, int>>());
                }
                graph[from].Add(new Tuple<int, int>(to, price));
            }
            for (int i = 0; i < n; i++)
            {
                cost[i] = MIN_VAL;
            }
            Queue<Node> queue = new Queue<Node>();
            PriorityQueue<int, int> ans = new PriorityQueue<int, int>();
            queue.Enqueue(new Node(src, 0, -1, new HashSet<int>())); // from, cost, stop
            HashSet<int> visited = new HashSet<int>();
            int stop = -1;
            visited.Add(src);
            var min = MIN_VAL;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var city = queue.Dequeue();
                    if (stop > k)
                    {
                        continue;
                    }
                    if (city.city == dst )
                    {
                        min = Math.Min(min, city.cost);
                    }
                    else
                    {
                        // city.path.Add(city.city);
                        if (graph.ContainsKey(city.city))
                        {
                            foreach (var item in graph[city.city])
                            {
                                if (city.cost + item.Item2 < cost[item.Item1])
                                {
                                    cost[item.Item1] = city.cost + item.Item2;
                                    queue.Enqueue(new Node(item.Item1, city.cost + item.Item2, city.stop + 1, new HashSet<int>()));
                                    // visited.Add(item.Item1);
                                }
                            }
                        }
                    }
                    
                }
                stop++;


            }
            if (min < MIN_VAL)
            {
                return min;
            }
            return -1;
        }

        class Node
        {
            public int city;
            public int cost;
            public int stop;
            public HashSet<int> path;

            public Node(int city, int cost, int stop, HashSet<int> path)
            {
                this.city = city;
                this.cost = cost;
                this.stop = stop;
                this.path = path;
            }
        }
    }
}
