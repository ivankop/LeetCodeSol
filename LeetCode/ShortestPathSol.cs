using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ShortestPathSol
    {
        int ans = int.MaxValue;
        Dictionary<Tuple<int, int>, int> mem = new Dictionary<Tuple<int, int>, int>();
        int[][] direction = new int[][] {
            new int[] { 1, 0 },
            new int[] { 0, 1 },
            new int[] { -1, 0 },
            new int[] { 0, -1 }
        };
        public int ShortestPath1(int[][] grid, int k)
        {
            var ans = ShortestPathRec(grid, k, 0 , 0, new HashSet<Tuple<int, int>>());
            if (ans < int.MaxValue)
            {
                return ans - 1;
            }
            return -1;
        }

        public int ShortestPath(int[][] grid, int k)
        {
            Tuple<int, int, int> pos = new Tuple<int, int, int>(0, 0, k);
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            HashSet<Tuple<int, int, int>> visited = new HashSet<Tuple<int, int, int>>();
            queue.Enqueue(pos);
            int step = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var curPos = queue.Dequeue();
                    int x = curPos.Item1;
                    int y = curPos.Item2;
                    int curK = curPos.Item3;
                    
                    if (x == grid[0].Length - 1 && y == grid.Length - 1)
                    {
                        return step;
                    }
                    for (int j = 0; j < direction.Length; j++)
                    {
                        int nextX = x + direction[j][0];
                        int nextY = y + direction[j][1];
                        if (nextX >= 0 && nextX < grid[0].Length && nextY >= 0 && nextY < grid.Length)
                        {
                            if (grid[nextY][nextX] == 0)
                            {
                                Tuple<int, int, int> nextPos = new Tuple<int, int, int>(nextX, nextY, curK);
                                if (!visited.Contains(nextPos))
                                {
                                    visited.Add(nextPos);
                                    queue.Enqueue(new Tuple<int, int, int>(nextX, nextY, curK));
                                }
                            }
                            else if (curK > 0)
                            {
                                Tuple<int, int, int> nextPos = new Tuple<int, int, int>(nextX, nextY, curK - 1);
                                if (!visited.Contains(nextPos))
                                {
                                    visited.Add(nextPos);
                                    queue.Enqueue(new Tuple<int, int, int>(nextX, nextY, curK - 1));
                                }
                            }
                        }
                    }
                }
                step++;
            }

            return -1;
        }

        private int ShortestPathRec(int[][] grid, int k, int x, int y, HashSet<Tuple<int, int>> visited)
        {
            
            Tuple<int, int> pos = new Tuple<int, int>(x, y);
            visited.Add(pos);

            if (mem.ContainsKey(pos) && visited.Count >= mem[pos])
            {
                return mem[pos];
            }

            if (x == grid[0].Length - 1 && y == grid.Length - 1)
            {
               return visited.Count;
            }
            int min = int.MaxValue;
            for (int i = 0; i < direction.Length; i++)
            {
                int nextX = x + direction[i][0];
                int nextY = y + direction[i][1];
                Tuple<int, int> nextPos = new Tuple<int, int>(nextX, nextY);
                if (nextX >= 0 && nextX < grid[0].Length && nextY >= 0 && nextY < grid.Length && !visited.Contains(nextPos))
                {
                    if (grid[nextY][nextX] == 0)
                    {
                        var tmp = ShortestPathRec(grid, k, nextX, nextY, new HashSet<Tuple<int, int>>(visited));
                        min = Math.Min(min, tmp);
                    }
                    else if (k > 0)
                    {
                        var tmp = ShortestPathRec(grid, k - 1, nextX, nextY, new HashSet<Tuple<int, int>>(visited));
                        min = Math.Min(min, tmp);
                    }
                }
            }
            if (!mem.ContainsKey(pos))
            {
                mem.Add(pos, min);
            }
            else
            {
                mem[pos] = min;
            }
            return min;

        }
    }
}
