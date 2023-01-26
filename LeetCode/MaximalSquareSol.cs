using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaximalSquareSol
    {
        public int MaximalSquare(char[][] matrix)
        {
            int size = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    while (CheckSquare(matrix, i, j, size))
                    {
                        size++;
                    }
                }
            }
            var ans = Math.Pow(size - 1,2);
            return (int)ans;
        }

        private bool CheckSquare(char[][] matrix, int x, int y, int size)
        {
            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                    if (i < matrix.Length && j < matrix[0].Length)
                    {
                        if (matrix[i][j] == '0')
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
