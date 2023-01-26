using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LongestArithSeqLengthSol
    {
        int ans = int.MinValue;
        public int LongestArithSeqLength1(int[] nums)
        {
            ans = int.MinValue;
            LongestArithSeqLengthRec(nums, 0, new List<int>());
            return ans;
        }

        public int LongestArithSeqLength(int[] nums)
        {
            List<Dictionary<int, int>> dp = new List<Dictionary<int, int>>();
            dp.Add(new Dictionary<int, int>());
            //dp[0].Add()
            for (int i = 1; i < nums.Length; i++)
            {
                dp.Add(new Dictionary<int, int>());
                for (int j = 0; j < i; j++)
                {
                    int diff = nums[i] - nums[j];
                    if (dp[j].ContainsKey(diff))
                    {
                        if (dp[i].ContainsKey(diff))
                        {
                            dp[i][diff] = Math.Max(dp[i][diff], dp[j][diff] + 1);
                        }
                        else
                        {
                            dp[i].Add(diff, dp[j][diff] + 1);
                        }
                            
                    }
                    else
                    {
                        if (!dp[i].ContainsKey(diff))
                            dp[i].Add(diff, 2);

                    }
                }
            }

            int ans = int.MinValue;
            for (int i = 0; i < dp.Count; i++)
            {
                if (dp[i].Count > 0)
                {
                    ans = Math.Max(ans, dp[i].Values.Max());
                }
            }

            return ans;
        }

        private void LongestArithSeqLengthRec(int[] nums, int index, List<int> seq)
        {
            if (index == nums.Length)
            {
                ans = Math.Max(ans, seq.Count);
                return;
            }
            if (ans >= nums.Length - index)
            {
                return;
            }
            if (seq.Count <= 1 || seq[1] - seq[0] == nums[index] - seq[seq.Count - 1])
            {
                var newSeq = new List<int>(seq);
                newSeq.Add(nums[index]);
                LongestArithSeqLengthRec(nums, index + 1, newSeq);
            }
            LongestArithSeqLengthRec(nums, index + 1, new List<int>(seq));
        }
    }
}
