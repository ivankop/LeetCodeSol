using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MatrixLongestIncreasingPath
    {
        int[][] dir = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { -1, 0 },
                new int[] { 0, -1 }
            };

        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        Dictionary<Tuple<int, int>, int> mem;
        public int LongestIncreasingPath(int[][] matrix)
        {
            visited = new HashSet<Tuple<int, int>>();
            mem = new Dictionary<Tuple<int, int>, int>();
            int longestPath = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    var path = LongestIncreasingPathRec(matrix, i, j);
                    longestPath = Math.Max(longestPath, path);
                }
            }
            return longestPath;
        }

        private int LongestIncreasingPathRec(int[][] matrix, int x, int y)
        {
            Tuple<int,int> pos = new Tuple<int, int>(x, y);
            if (mem.ContainsKey(pos))
            {
                return mem[pos];
            }
            int longestPath = 1;
            visited.Add(pos);
            for (int i = 0; i < dir.Length; i++)
            {
                int nextX = x + dir[i][0];
                int nextY = y + dir[i][1];
                Tuple<int, int> nextPos = new Tuple<int, int>(nextX, nextY);
                if (nextX >= 0 && nextX < matrix.Length && nextY >= 0 && nextY < matrix[x].Length && !visited.Contains(nextPos))
                {
                    if (matrix[nextX][nextY] > matrix[x][y])
                    {
                        var tmpPath = 1 + LongestIncreasingPathRec(matrix, nextX, nextY);
                        longestPath = Math.Max(longestPath, tmpPath);
                    }
                }
            }
            visited.Remove(pos);
            mem[pos] = longestPath;
            return longestPath;
        }
    }
}
