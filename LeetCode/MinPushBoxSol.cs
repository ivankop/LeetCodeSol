using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinPushBoxSol
    {
        public int MinPushBox(char[][] grid)
        {
            int[][] direction = new int[][] {
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                new int[] { -1, 0 },
                new int[] { 0, -1 }
            };

            List<Tuple<int, int>> PushablePos(Tuple<int, int> pos)
            {
                var res = new List<Tuple<int, int>>();
                int row = pos.Item1;
                int col = pos.Item2;
                if (row - 1 >= 0 && row + 1 < grid.Length && grid[row -1][col] != '#' && grid[row + 1][col] != '#')
                {
                    res.Add(new Tuple<int, int>(row + 1, col));
                    res.Add(new Tuple<int, int>(row - 1, col));
                }

                if (col - 1 >= 0 && col + 1 < grid[0].Length && grid[row][col - 1] != '#' && grid[row + 1][col + 1] != '#')
                {
                    res.Add(new Tuple<int, int>(row, col + 1));
                    res.Add(new Tuple<int, int>(row, col - 1));
                }

                return res;
            }

            bool IsReachable(Tuple<int,int> pos, Tuple<int, int> s, HashSet<Tuple<int, int>> visited)
            {
                if (pos == s)
                    return true;
                visited.Add(s);
                for (int i = 0; i < direction.Length; i++)
                {
                    var nextRow = s.Item1 + direction[i][0];
                    var nextCol = s.Item1 + direction[i][1];
                    Tuple<int, int> nextPos = new Tuple<int, int>(nextRow, nextCol);
                    if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length && !visited.Contains(nextPos) && grid[nextRow][nextCol] == '.')
                    {
                        if (IsReachable(pos, nextPos, visited))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            Tuple<int, int> target = new Tuple<int, int>(0, 0);
            Tuple<int, int> box = new Tuple<int, int>(0, 0);
            Tuple<int, int> s = new Tuple<int, int>(0, 0);
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 'T')
                    {
                        target = new Tuple<int, int>(i, j);
                    }
                    else if(grid[i][j] == 'B')
                    {
                        box = new Tuple<int, int>(i, j);
                    }
                    else if (grid[i][j] == 'S')
                    {
                        s = new Tuple<int, int>(i, j);
                    }
                }
            }

            Queue<Tuple<int,int>> queue = new Queue<Tuple<int,int>>();
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
            queue.Enqueue(box);
            while(queue.Count > 0)
            {
                var pos = queue.Dequeue();
                var nextPos = PushablePos(pos);

            }

            return -1;

        }

        
    }
}
