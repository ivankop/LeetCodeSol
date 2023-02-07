using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class Largest1BorderedSquareSol
    {
        int[][] direction = new int[][] {
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 0, -1 },
            new int[] { -1, 0 }
        };
        public int Largest1BorderedSquare(int[][] grid)
        {
            int ans = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    ans = Math.Max(ans, DetectSquare(grid, i, j));
                }
            }
            return ans;
        }

        private int DetectSquare(int[][] grid, int row, int col)
        {
            if (grid[row][col] == 0)
            {
                return 0;
            }
            int size = 1;
            for (int i = 2; i < 100; i++)
            {
                if ((col + i - 1 < grid[0].Length && grid[row][col + i - 1] == 0) || col + i - 1 >= grid[0].Length)
                {
                    return size;
                }
                int startRow = row;
                int startCol = col;
                for (int j = 0; j < direction.Length; j++)
                {
                    int step = 1;
                    bool invalid = false;
                    while (step < i)
                    {
                        startRow += direction[j][0];
                        startCol += direction[j][1];
                        step++;
                        if (startRow < 0 || startCol < 0 || startRow >= grid.Length || startCol >= grid[0].Length || grid[startRow][startCol] == 0)
                        {
                            invalid = true;
                            break;
                        }
                    }
                    if (invalid)
                        break;
                }
                if (startRow == row && startCol == col)
                    size = i;
            }
            return size;
        }
    }
}
