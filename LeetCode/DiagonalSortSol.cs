using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DiagonalSortSol
    {
        HashSet<int> visisted = new HashSet<int>();
        public int[][] DiagonalSort(int[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    Sort(mat, i, j);
                }
            }
            return mat;
        }

        void Sort(int[][] mat, int row, int col)
        {
            int startPos = row * mat.Length + col;
            if (visisted.Contains(startPos))
                return;
                
            visisted.Add(startPos);
            int orgRow = row;
            int orgCol = col;
            PriorityQueue<Tuple<int, int>, int> queue = new PriorityQueue<Tuple<int, int>, int>();
            while (row < mat.Length && col < mat[0].Length)
            {
                queue.Enqueue(new Tuple<int, int>(row, col), mat[row][col]);
                row = row + 1;
                col = col + 1;
            }
            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();
                mat[orgRow][orgCol] = mat[pos.Item2][pos.Item1];
                orgRow++;
                orgCol++;
            }
        }
    }
}
