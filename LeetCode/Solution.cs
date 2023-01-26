using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class Solution
    {
        public int OrangesRotting(int[][] grid)
        {
            int min = 0;
            int m = grid.Length;
            int n = grid[0].Length;
            bool hasFreshToRotten = false;
            do
            {
                hasFreshToRotten = false;
                List<RottenOrange> rottenOranges = new List<RottenOrange>();
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (grid[i][j] == 2)
                        {
                            var o = this.FreshToRotten(grid, m, n, i, j);
                            if (o != null)
                            {
                                rottenOranges.Add(o);
                                hasFreshToRotten = true;
                            }
                        }
                    }
                }

                if (hasFreshToRotten)
                {
                    min++;
                    foreach (var item in rottenOranges)
                    {
                        Rotten(ref grid, m, n, item.i, item.j, min);
                    }
                }
                
            } while (hasFreshToRotten);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        return -1;
                    }
                }
            }
            return min;
        }

        private RottenOrange FreshToRotten(int[][] grid, int m, int n, int i, int j)
        {
            if (i < 0 || i >= m || j < 0 || j >= n)
                return null;
            bool hasFreshToRotten = false;
            if (grid[i][j] == 2)
            {
                if (j > 0 && grid[i][j - 1] == 1)
                {
                    hasFreshToRotten = true;
                }
                if (j < n - 1 && grid[i][j + 1] == 1)
                {
                    hasFreshToRotten = true;
                }
                if (i > 0 && grid[i - 1][j] == 1)
                {
                    hasFreshToRotten = true;
                }
                if (i < m - 1 && grid[i + 1][j] == 1)
                {
                    hasFreshToRotten = true;
                }
                if (hasFreshToRotten)
                {
                    return new RottenOrange { i = i, j = j };
                }
            }
            return null;
        }
        private bool Rotten(ref int[][] grid, int m, int n, int i, int j, int min)
        {
            if (i < 0 || i >= m || j < 0 || j >= n)
                return false;
            bool hasFreshToRotten = false;
            if (grid[i][j] == 2)
            {
                bool left, right, top, bottom;
                left = right = top = bottom = false;
                if (j > 0 && grid[i][j - 1] == 1)
                {
                    grid[i][j - 1] = 2;
                    hasFreshToRotten = true;
                    left = true;
                }
                if (j < n - 1 && grid[i][j + 1] == 1)
                {
                    grid[i][j + 1] = 2;
                    hasFreshToRotten = true;
                    right = true;
                }
                if (i > 0 && grid[i - 1][j] == 1)
                {
                    grid[i - 1][j] = 2;
                    hasFreshToRotten = true;
                    top = true;
                }
                if (i < m - 1 && grid[i + 1][j] == 1)
                {
                    grid[i + 1][j] = 2;
                    hasFreshToRotten = true;
                    bottom = true;
                }
                if (hasFreshToRotten)
                {
                    Console.WriteLine($"{i}, {j}, min={min}");
                }
                /*

                if (left)
                    Rotten(ref grid, m, n, i, j - 1, ref min);
                if (right)
                    Rotten(ref grid, m, n, i, j + 1, ref min);
                if (top)
                    Rotten(ref grid, m, n, i - 1, j, ref min);
                if (bottom)
                    Rotten(ref grid, m, n, i + 1, j, ref min);
                */
            }
            return hasFreshToRotten;
        }

        private class RottenOrange
        {
            public int i { get; set; }
            public int j { get; set; }
        }
    }
}
