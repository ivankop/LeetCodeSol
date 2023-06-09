using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Graph
{
    public class FindCircleNumSol
    {
        int[] parent;
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
            int ans = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isConnected[i][j] == 1 && !Union(i, j))
                    {
                        ans--;
                    }
                }
            }
            return ans;
        }

        private int FindParent(int f)
        {
            if (parent[f] == f)
            {
                return f;
            }
            return FindParent(parent[f]);
        }

        private bool Union(int f1, int f2)
        {
            int p1 = FindParent(f1);
            int p2 = FindParent(f2);
            if (p1 == p2)
                return true;
            parent[p2] = p1;
            return false;

        }
    }
}
