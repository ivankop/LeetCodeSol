using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class UpdateMatrixSol
    {
        int[][] adj;
        Dictionary<Tuple<int,int>, int> visited;
        int MAX_VALUE = 20000;

        public int[][] UpdateMatrix(int[][] mat)
        {
            
            visited = new Dictionary<Tuple<int, int>, int>();

            int[][] dp = new int[mat.Length][];
            for (int i = 0; i < mat.Length; i++)
            {
                dp[i] = new int[mat[i].Length];
                for (int j = 0; j < mat[i].Length; j++)
                {
                    Tuple<int, int> pos = new Tuple<int, int>(i, j);
                    if (mat[i][j] == 0)
                    {
                        dp[i][j] = 0;
                        visited[pos] = 0;
                    }
                    else
                    {
                        dp[i][j] = MAX_VALUE;
                    }
                }
            }
            adj = new int[4][];
            adj[0] = new int[] { -1, 0 }; // left
            adj[1] = new int[] { 1, 0 }; // right
            adj[2] = new int[] { 0, -1 }; // top
            adj[3] = new int[] { 0, 1 }; // top



            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    UpdateMatrixRec(i, j, mat, dp);
                }
            }

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (dp[i][j] != 1)
                    {
                        for (int k = 0; k < adj.Length; k++)
                        {
                            var posX = i + adj[k][0];
                            var posY = j + adj[k][1];
                            if (posX >= 0 && posX < mat.Length && posY >= 0 && posY < mat[i].Length)
                            {
                                dp[i][j] = Math.Min(dp[i][j], dp[posX][posY] + 1);
                            }
                        }
                    }
                }
            }

            return dp;

        }

        private int UpdateMatrixRec(int x, int y, int[][] mat, int[][] dp)
        {
            Tuple<int, int> pos = new Tuple<int, int>(x, y);
            if (visited.ContainsKey(pos) && visited[pos] != MAX_VALUE)
            {
                if (dp[x][y] != 1)
                {
                    for (int k = 0; k < adj.Length; k++)
                    {
                        var posX = x + adj[k][0];
                        var posY = y + adj[k][1];
                        if (posX >= 0 && posX < mat.Length && posY >= 0 && posY < mat[x].Length)
                        {
                            dp[x][y] = Math.Min(dp[x][y], dp[posX][posY] + 1);
                        }
                    }
                    visited[pos] = dp[x][y];
                }
                
                return visited[pos];
            }
            var min = MAX_VALUE;
            
            if (mat[x][y] == 0)
            {
                min = 0;
            }
            else
            {
                visited[pos] = MAX_VALUE;
                for (int k = 0; k < adj.Length; k++)
                {
                    var posX = x + adj[k][0];
                    var posY = y + adj[k][1];
                    Tuple<int, int> nextPos = new Tuple<int, int>(posX, posY);
                    if (posX >= 0 && posX < mat.Length && posY >= 0 && posY < mat[x].Length && (!visited.ContainsKey(nextPos) || (visited.ContainsKey(nextPos) && visited[nextPos] != MAX_VALUE)))
                    {
                        var tmp = UpdateMatrixRec(posX, posY, mat, dp);
                        min = Math.Min(min, tmp + 1);
                    }
                }
            }
            dp[x][y] = Math.Min(dp[x][y], min);
            visited[pos] = min;
            return min;
        }
    }
}
