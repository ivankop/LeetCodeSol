using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public  class MaxPointsSol
    {
        public long MaxPoints(int[][] points)
        {
            long[] dp = new long[points.Length * points[0].Length];
            long max = points[0][0];
            for (int i = 0; i < points[0].Length; i++)
            {
                if (points[0][i] > max)
                {
                    max = points[0][i];
                }
                dp[i] = points[0][i]; 
            }
            long[] l2r = new long[points[0].Length];
            long[] r2l = new long[points[0].Length];

            for (int i = 1; i < points.Length; i++)
            {
                
                BuildL2R(l2r, i - 1, dp);
                BuildR2L(r2l, i - 1, dp);
                
                // find max in current position
                for (int j = 0; j < points[i].Length; j++)
                {
                    var maxValue = points[i][j] + Math.Max(l2r[j], r2l[j]);
                    // var lastDp = dp[i * points[i].Length + j - 1];
                    // dp[i * points[i].Length + j] = Math.Max(lastDp, maxValue);
                    dp[i * points[i].Length + j] = maxValue;
                    if (maxValue > max)
                    {
                        max = maxValue;
                    }
                }
            }

            // return dp[points.Length * points[0].Length -1];
            return max;
        }

        private void BuildL2R(long[] input, int r, long[] dp)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    input[i] = dp[input.Length * r + i]; // Math.Max(dp[input.Length * r + i], dp[input.Length * r + i - 1] - 1);
                }
                else
                {
                    input[i] = Math.Max(dp[input.Length * r + i], input[i - 1] - 1);
                }
                
            }
        }

        private void BuildR2L(long[] input, int r, long[] dp)
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (i == input.Length - 1)
                {
                    input[i] = dp[input.Length * r + i]; // Math.Max(dp[input.Length * r + i], dp[input.Length * r + i + 1] - 1);
                }
                else
                {
                    input[i] = Math.Max(dp[input.Length * r + i], input[i + 1] - 1);
                }

            }
        }
    }
}
