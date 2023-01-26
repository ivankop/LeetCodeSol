using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class StringBalanceMinimumDeletions
    {
        public int MinimumDeletions(string s)
        {
            s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] dp = new int[s.Length+1];
            int countB = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    dp[i + 1] = Math.Min(dp[i] + 1, countB);
                }
                else
                {
                    countB++;
                    dp[i + 1] = dp[i];
                }
            }
            return dp[dp.Length - 1];
        }

        private string deleteChar(string inputStr, int startIndex, ref int ans)
        {
            if (startIndex == inputStr.Length - 1)
            {
                return inputStr;
            }
            
            int i = startIndex;
            for (; i < inputStr.Length - 1; i++)
            {
                if (inputStr[i] == 'b' && inputStr[i + 1] == 'a')
                {
                    inputStr = inputStr.Remove(i, 1);
                    ans++;
                    break;
                }
            }
            return deleteChar(inputStr, i, ref ans);
        }
    }
}
