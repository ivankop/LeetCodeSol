using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class EarliestFriendMoment
    {
        int[] parent;
        int[] friendCount;
        int maxFriendCount = int.MinValue;
        public int EarliestAcq(int[][] logs, int n)
        {
            parent= new int[n];
            friendCount= new int[n];
            Array.Sort(logs, (a,b) => a[0].CompareTo(b[0]));
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                friendCount[i] = 1;
            }
            for (int i = 0; i < logs.Length; i++)
            {
                Union(logs[i][1], logs[i][2]);
                if (maxFriendCount == n)
                {
                    return logs[i][0];
                }
            }

            return -1;
        }

        private int FindParent(int f)
        {
            if (parent[f] == f)
            {
                return f;
            }
            return FindParent(parent[f]);
        }

        private void Union(int f1, int f2)
        {
            int p1 = FindParent(f1);
            int p2 = FindParent(f2);
            if (p1 == p2)
                return;
            parent[p2]= p1;
            friendCount[p1] += friendCount[p2];
            maxFriendCount = Math.Max(maxFriendCount, friendCount[p1]);
        }
    }
}
