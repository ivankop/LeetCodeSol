using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class MergeIntervals
    {
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));
            List<int[]> ans = new List<int[]>();
            ans.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= ans[ans.Count-1][1])
                {
                    ans[ans.Count - 1][1] = Math.Max(intervals[i][1], ans[ans.Count - 1][1]);
                }
                else
                {
                    ans.Add(intervals[i]);
                }
            }
            return ans.ToArray();
        }
    }
}
