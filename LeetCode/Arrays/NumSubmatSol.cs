using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class NumSubmatSol
    {
        public int NumSubmat(int[][] mat)
        {
            int[][] countArr = new int[mat.Length][];
            for (int i = 0; i < mat.Length; i++)
            {
                countArr[i] = new int[mat[i].Length];
            }
            for (int i = 0; i < mat.Length; i++)
            {
                int c = 0;
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] != 0)
                    {
                        c++;
                    }
                    else
                    {
                        c = 0;
                    }
                    countArr[i][j] = c;
                }
            }
            int ans = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    int min = countArr[i][j];
                    for (int k = i; k < mat.Length; k++)
                    {
                        min = Math.Min(min, countArr[k][j]);
                        ans += min;
                    }
                }
            }
            return ans;
        }

        int countSubMat(int[][] mat, int row, int col)
        {
            if (mat[row][col] == 0)
            {
                return 0;
            }
            int count = 1;
            //right
            var tmpRow1 = row;
            var tmpCol1 = col + 1;
            while (tmpRow1 < mat.Length && tmpCol1 < mat[row].Length && mat[tmpRow1][tmpCol1] != 0)
            {
                count++;
                tmpCol1++;
            }
            tmpCol1--;

            //down
            var tmpRow2 = row + 1;
            var tmpCol2 = col;
            while (tmpRow2 < mat.Length && tmpCol2 < mat[row].Length && mat[tmpRow2][tmpCol2] != 0)
            {
                count++;
                tmpRow2++;
            }
            tmpRow2--;

            //right and down
            var maxSize = Math.Min(tmpCol1 - col, tmpRow2 - row);
            var tmpRow = row + 1;
            var tmpCol = col + 1;
            int size = 0;
            while (tmpRow < mat.Length && tmpCol < mat[row].Length && mat[tmpRow][tmpCol] != 0 && size < maxSize)
            {
                count++;
                tmpRow++;
                tmpCol++;
                size++;
            }
            return count;
        }
    }
}
