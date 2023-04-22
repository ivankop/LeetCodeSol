
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class FindColumnWidthSol
    {
        public int[] FindColumnWidth(int[][] grid)
        {
            int[] result = new int[grid[0].Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var width = grid[i][j].ToString().Length;
                    result[j] = Math.Max(result[i], width);
                }
            }
            return result;
        }
    }
}
