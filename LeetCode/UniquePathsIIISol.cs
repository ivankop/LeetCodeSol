using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class UniquePathsIIISol
    {
        int[][] direction = new int[][] {
            new int[] { 1, 0 },
            new int[] { 0, 1 },
            new int[] { -1, 0 },
            new int[] { 0, -1 }
        };
        int count = 0;
        public int UniquePathsIII(int[][] grid)
        {
            count = 0;
            int emptySquareCount = 0;
            Tuple<int, int> startPos = null;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        emptySquareCount++;
                    } 
                    else if (grid[i][j] == 1)
                    {
                        startPos = new Tuple<int, int>(i, j);
                    }
                }
            }
            Walk(startPos.Item1, startPos.Item2, emptySquareCount, grid, new List<Tuple<int, int>>());

            return count;
        }

        private void Walk(int r, int c,int emptySquareCount, int[][] grid, List<Tuple<int, int>> visited)
        {
            if (grid[r][c] == -1)
            {
                return;
            }
            if (grid[r][c] == 2)
            {
                if (emptySquareCount != 0 && visited.Count == emptySquareCount + 1)
                {
                    count++;
                }
                return;
            }
            Tuple<int, int> pos= new Tuple<int, int>(r, c);
            visited.Add(pos);
            for (int i = 0; i < direction.Length; i++)
            {
                int nextR = r + direction[i][0];
                int nextC = c + direction[i][1];
                Tuple<int, int> nextPos = new Tuple<int, int>(nextR, nextC);
                if (nextR >= 0 && nextR < grid.Length && nextC >= 0 && nextC < grid[0].Length && !visited.Contains(nextPos))
                {
                    Walk(nextR, nextC, emptySquareCount, grid, new List<Tuple<int, int>>(visited));
                }
            }

        }

    }
}
