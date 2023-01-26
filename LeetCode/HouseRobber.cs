using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class HouseRobber
    {
        public int Rob(int[] nums)
        {
            if (nums.Length < 2)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(dp[0], nums[1]);
            if (nums.Length == 2)
            {
                return dp[1];
            }
            
            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i-1], dp[i-2] + nums[i]);
            }
            return dp[nums.Length-1];
        }
    }
}
