using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class NumberOfIsland
    {
        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            var visited = new int[m][];
            for (int i = 0; i < m; i++)
            {
                visited[i] = new int[n];
            }

            int islandNumber = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1' && visited[i][j] == 0)
                    {
                        findIsland(i, j , grid, visited, ++islandNumber);
                    }
                }
            }

            return islandNumber;
        }

        private void findIsland(int i, int j, char[][] grid, int[][] visited, int islandNumber)
        {
            if (i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length && visited[i][j] == 0)
            {
                visited[i][j] = islandNumber;
                if (grid[i][j] == '1')
                {
                    findIsland(i, j + 1, grid, visited, islandNumber);
                    findIsland(i, j - 1, grid, visited, islandNumber);
                    findIsland(i + 1, j, grid, visited, islandNumber);
                    findIsland(i - 1, j, grid, visited, islandNumber);
                }
            }
        }
    }
}
