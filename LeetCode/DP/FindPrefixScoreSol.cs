using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class FindPrefixScoreSol
    {
        public long[] FindPrefixScore(int[] nums)
        {
            long[] dp = new long[nums.Length];
            int[] prefix = buildPrefixArr(nums);
            dp[0] = nums[0] + prefix[0];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = dp[i-1] + nums[i] + prefix[i];
            }
            return dp;
        }

        int[] buildPrefixArr(int[] nums)
        {
            int[] ans = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    ans[0] = nums[i];
                }
                else
                {
                    ans[i] = Math.Max(nums[i], ans[i - 1]);
                }
            }
            return ans;
        }
    }
}
