using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SpiralMatrixIIISol
    {
        List<Tuple<int, int>> visited;
        int[][] direction = new int[][] { 
            new int[] { 1, 0 }, 
            new int[] { 0, 1 },
            new int[] { -1, 0 },
            new int[] { 0, -1 }
        };
        public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
        {
            visited = new List<Tuple<int, int>>();
            Walk(rStart, cStart, rows, cols, 0, 1, 0, 1 );
            int[][] ans = new int[visited.Count][];
            for (int i = 0; i < visited.Count; i++)
            {
                ans[i] = new int[] { visited[i].Item1, visited[i].Item2 };
            }

            return ans;

        }

        private void Walk(int r, int c, int rows, int cols, int count, int size, int dir, int dirCount)
        {
            if (r < rows && r >= 0 && c < cols && c >= 0)
            {
                visited.Add(new Tuple<int, int>(r, c));
                if (visited.Count == rows * cols)
                {
                    return;
                }
            }
            
            if (count == size)
            {
                count = 0;
                dir = (dir + 1) % 4;
                if (dirCount == 2)
                {
                    size++;
                    dirCount = 1;
                    //var newDir = (dir + 1) % 4;
                    //Walk(r + direction[dir][1], c + direction[dir][0], rows, cols, count, size, newDir, dirCount);
                    //return;
                }
                else
                {
                    
                    dirCount++;
                }               
            }

            Walk(r + direction[dir][1], c + direction[dir][0], rows, cols, count + 1, size, dir, dirCount);
        }
    }
}
