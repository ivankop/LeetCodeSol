using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindMinDifferenceSol
    {
        public int FindMinDifference(IList<string> timePoints)
        {
            timePoints = timePoints.OrderBy(x => x).ToList();
            int[] dp = new int[timePoints.Count];
            dp[0] = int.MaxValue;
            for (int i = 1; i < timePoints.Count; i++)
            {
                var minDiffWithPrev = MinDiff(timePoints[i], timePoints[i - 1]);

                var minDiffWithFirst = MinDiff(timePoints[i], timePoints[0]);
                dp[i] = Math.Min(Math.Min(minDiffWithPrev, minDiffWithFirst), dp[i - 1]);
            }

            return dp[timePoints.Count - 1];
        }

        private int MinDiff(string first, string second)
        {
            if (first == second)
                return 0;
            TimeSpan firtsTime = TimeSpan.Parse(first);
            TimeSpan secondTime = TimeSpan.Parse(second);
            var min1 = Math.Abs((int)(firtsTime - secondTime).TotalMinutes);
            var min2 = Math.Abs((int)(firtsTime - secondTime.Add(new TimeSpan(1, 0, 0, 0, 0))).TotalMinutes);
            return Math.Min(min1, min2);
        }
    }
}
