using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class GenerateMatrixSol
    {
        public int[][] GenerateMatrix(int n)
        {
            var res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
            }
            var count = 1;
            int indexX = 0, indexY = 0;
            while(count <= n*n)
            {
                GenerateMatrix(ref indexX, ref indexY, res, ref count);
                indexY++;
            }

            return res;
        }

        private void GenerateMatrix(ref int indexX, ref int indexY, int[][] input, ref int count)
        {
            // left
            while(indexY < input.GetLength(0))
            {
                if (input[indexX][indexY] != 0)
                {
                    break;
                }
                input[indexX][indexY] = count++;
                indexY++;
            }
            indexY--;
            indexX++;
            // down
            while (indexX < input[0].GetLength(0))
            {
                if (input[indexX][indexY] != 0)
                {
                    break;
                }
                input[indexX][indexY] = count++;
                indexX++;
            }
            indexX--;
            indexY--;
            // right
            while (indexY >= 0)
            {
                if (input[indexX][indexY] != 0)
                {
                    break;
                }
                input[indexX][indexY] = count++;
                indexY--;
            }
            indexY++;
            indexX--;
            // up
            while (indexX >= 0)
            {
                if (input[indexX][indexY] != 0)
                {
                    break;
                }
                input[indexX][indexY] = count++;
                indexX--;
            }
            indexX++;

        }


    }
}
