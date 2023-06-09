using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class FindSmallestSetOfVerticesSol
    {
        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            HashSet<int> nodes = new HashSet<int>();
            foreach (var edge in edges)
            {
                nodes.Add(edge[1]);
            }
            List<int> result = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (!nodes.Contains(i))
                {
                    result.Add(i);
                }
            }    
            return result;
        }
    }
}
