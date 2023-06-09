using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class MaxIncreasingCellsSol
    {
        public int MaxIncreasingCells(int[][] mat)
        {
            int m = mat.Length;
            int n = mat[0].Length; 
            SortedList<int, int> list = new SortedList<int, int>();
            for (int i = 0; i < m; i++)
            {
                List<Tuple<int, int>> row = new List<Tuple<int, int>>();
                for (int j = 0; j < n; j++)
                {
                    row.Add(new Tuple<int, int>(mat[i][j], j));
                }

            }
            return -1;

        }
    }
}
