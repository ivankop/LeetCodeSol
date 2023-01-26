using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AllPathsSourceTargetSol
    {
        IList<IList<int>> paths;
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            paths = new List<IList<int>>();
            DFS(graph, 0, new List<int>());
            return paths;
        }

        private void DFS(int[][] graph, int node, List<int> path)
        {
            if (node == graph.Length - 1)
            {
                path.Add(node);
                paths.Add(path);
                return;
            }
            path.Add(node);
            for (int i = 0; i < graph[node].Length; i++)
            {
                DFS(graph, graph[node][i], new List<int>(path));
            }
        }
    }
}
