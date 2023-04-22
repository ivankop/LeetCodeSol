using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SmallestStringWithSwapsSol
    {
        Dictionary<int, HashSet<int>> pairSet;

        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            pairSet = new Dictionary<int, HashSet<int>>();
            foreach (var pair in pairs)
            {
                if (!pairSet.ContainsKey(pair[0]))
                {
                    pairSet.Add(pair[0], new HashSet<int>());
                }

                if (!pairSet.ContainsKey(pair[1]))
                {
                    pairSet.Add(pair[1], new HashSet<int>());
                }
                pairSet[pair[0]].Add(pair[1]);
                pairSet[pair[1]].Add(pair[0]);
            }


            Dictionary<int, PriorityQueue<int, char>> dict = new Dictionary<int, PriorityQueue<int, char>>();
            
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(i))
                {
                    PriorityQueue<int, char> links = new PriorityQueue<int, char>();
                    HashSet<int> visited = new HashSet<int>();
                    dfs(s, i, links, visited);
                    foreach (var index in visited)
                    {
                        dict.Add(index, links);
                    }
                }
            }
            
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                var index = dict[i].Dequeue();
                sb.Append(s[index]);
            }

            return sb.ToString();

        }

        void dfs(string s, int index, PriorityQueue<int, char> links, HashSet<int> visited)
        {
            if (visited.Contains(index))
            {
                return;
            }
            visited.Add(index);
            links.Enqueue(index, s[index]);
            if (pairSet.ContainsKey(index))
            {
                foreach (var pair in pairSet[index])
                {
                    if (!visited.Contains(pair))
                    {
                        //links.Enqueue(pair.Item1, s[pair.Item1]);
                        dfs(s, pair, links, visited);
                    }
                }
            }
            
        }
    }
}
