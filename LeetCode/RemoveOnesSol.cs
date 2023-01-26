using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RemoveOnesSol
    {
        public bool RemoveOnes(int[][] grid)
        {
            // try to flip first row using column
            int n = grid.Length;
            int m = grid[0].Length;
            for (int i = 0; i < m; i++)
            {
                if (grid[0][i] == 1)
                {
                    // flip this column
                    for (int j = 0; j < n; j++)
                    {
                        grid[j][i] ^= 1; 
                    }
                }
            }

            // check another row
            for (int i = 0; i < n; i++)
            {
                int first = grid[i][0];
                for (int j = 1; j< m; j++)
                {
                    if (grid[i][j] != first)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
