using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ShortestPathBinaryMatrixSol
    {
        Dictionary<Tuple<int, int>, int> mem;
        
        int MAX_VALUE = 100 * 100;
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            var res = findPathBFS(grid);
            return res;
        }

        int findPathBFS(int[][] grid)
        {
            if (grid[0][0] == 1)
            {
                return -1;
            }
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            queue.Enqueue(new Tuple<int, int, int>(0, 0, 1));
            // HashSet<int> visited = new HashSet<int>();
            int[][] dir = new int[][] {
                new int[] { 1, 1 },
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 1, -1 },
                new int[] { -1, 1 },
                new int[] { -1, 0 },
                new int[] { 0, -1 },               
                new int[] { -1, -1 }               
            };
            
            while(queue.Count > 0)
            {
                Tuple<int, int, int> pos = queue.Dequeue();
                int currentRow = pos.Item1;
                int currentCol = pos.Item2;
                int dist = pos.Item3;
                int currentPos = currentRow * grid[0].Length + currentCol;
                // visited.Add(currentPos);
                grid[currentRow][currentCol] = 1;
                if (currentRow == grid.Length - 1 && currentCol == grid[0].Length - 1)
                {
                    return dist;
                }

                for (int i = 0; i < dir.Length; i++)
                {
                    int row = pos.Item1 + dir[i][0];
                    int col = pos.Item2 + dir[i][1];

                    if (row < 0 || col < 0 || row > grid.Length - 1 || col > grid[0].Length - 1 || grid[row][col] == 1)
                    {
                        continue;
                    }

                    //if (grid[row][col] == 0 && row == grid.Length - 1 && col == grid[0].Length - 1)
                    //{
                    //    return dist + 1;
                    //}
                    // var tmpPos = row * grid[0].Length + col;
                    //if (!visited.Contains(tmpPos))
                    {
                        var nextPos = new Tuple<int, int, int>(row, col, dist + 1);
                        queue.Enqueue(nextPos);
                    }
                }
            }

            return -1;
        }
    }


}
