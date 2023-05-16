using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class MaxNumEdgesToRemoveSol
    {
        int[] parentA; 
        int[] parentB;
        int[] edgesCountA;
        int[] edgesCountB;
        // int maxEdgeCount = int.MinValue;
        public int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            parentA = new int[n + 1];
            parentB = new int[n + 1];
            edgesCountA = new int[n + 1];
            edgesCountB = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                parentA[i] = i;
                parentB[i] = i;
                edgesCountA[i] = 1;
                edgesCountB[i] = 1;
            }
            int count = 0;
            int headA = 1, headB = 1;
            List<int> remain = new List<int>();
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i][0] == 3)
                {
                    var tmp1 = Union(parentA, edgesCountA, edges[i][1], edges[i][2], ref headA) > 0;
                    var tmp2 = Union(parentB, edgesCountB, edges[i][1], edges[i][2], ref headB) > 0;
                    if (tmp1  || tmp2)
                        count++;
                    
                }
                else
                {
                    remain.Add(i);
                }
                if (edgesCountA[headA] == n && edgesCountB[headB] == n)
                {
                    return edges.Length - count;
                }
            }
            foreach (var i in remain)
            {
                if (edges[i][0] == 1)
                {
                    count += Union(parentA, edgesCountA, edges[i][1], edges[i][2], ref headA);
                }
                else if (edges[i][0] == 2)
                {
                    count += Union(parentB, edgesCountB, edges[i][1], edges[i][2], ref headB);
                }

                if (edgesCountA[headA] == n && edgesCountB[headB] == n)
                {
                    return edges.Length - count;
                }

            }
            
            return -1;
        }

        private int FindParent(int[] parent, int f)
        {
            if (parent[f] == f)
            {
                return f;
            }
            return FindParent(parent, parent[f]);
        }

        private int Union(int[] parent, int[] edgesCount, int f1, int f2, ref int head)
        {
            int p1 = FindParent(parent, f1);
            int p2 = FindParent(parent, f2);
            if (p1 == p2)
                return 0;
            
            parent[p2] = p1;
            edgesCount[p1] += edgesCount[p2];
            head = p1;
            return 1;
        }
    }
}
