using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class MaximumMinimumPathSol
    {
        //Dictionary<Tuple<int,int, int>, int> mem;
        //int maxMinValue = int.MinValue;
        int[][] dir = new int[][] {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };
        public int MaximumMinimumPath(int[][] grid)
        {
            PriorityQueue<Tuple<int, int>, int> queue = new PriorityQueue<Tuple<int, int>, int>(new MaxHeapComparer());
            queue.Enqueue(new Tuple<int, int>(0, 0), grid[0][0]);
            HashSet<Tuple<int, int>> visisted = new HashSet<Tuple<int, int>>();
            visisted.Add(new Tuple<int, int>(0, 0));
            int maxMinValue = grid[0][0];
            int n = grid.Length;
            int m = grid[0].Length;
            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();
                maxMinValue = Math.Min(maxMinValue, grid[pos.Item1][pos.Item2]);
                if (pos.Item1 == n - 1 && pos.Item2 == m - 1)
                {
                    return maxMinValue;
                }
                for (int i = 0; i < dir.Length; i++)
                {
                    var nextRow = pos.Item1 + dir[i][0];
                    var nextCol = pos.Item2 + dir[i][1];
                    var nextPos = new Tuple<int, int>(nextRow, nextCol);
                    if (nextRow < n && nextCol < m && nextRow >= 0 && nextCol >= 0 && !visisted.Contains(nextPos))
                    {
                        queue.Enqueue(nextPos, grid[nextRow][nextCol]);
                        visisted.Add(nextPos);
                    }
                }
            }
            return maxMinValue;

        }

        class MaxHeapComparer : IComparer<int>
        {
            public int Compare(int x, int y) => y.CompareTo(x);
        }
    }


}
