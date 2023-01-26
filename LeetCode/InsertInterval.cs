using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class InsertInterval
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
           
            List<int[]> ans = new List<int[]>();
            if (intervals == null || intervals.Length == 0)
            {
                ans.Add(newInterval);
                return  ans.ToArray();
            }
            int[] curInterval = new int[2];
            curInterval[0] = -1;
            curInterval[1] = -1;
            if (newInterval[1] < intervals[0][0])
            {
                curInterval[0] = newInterval[0];
                curInterval[1] = newInterval[1];
                ans.Add(curInterval);
            }
            for (int i = 0; i < intervals.Length; i++)
            {
                if (newInterval[1] < intervals[i][0] )
                {
                    if (curInterval[0] != -1 && curInterval[1] == -1)
                    {
                        curInterval[1] = newInterval[1];
                        ans.Add(curInterval);
                    }
                    ans.Add(intervals[i]);
                    continue;
                }
                if (newInterval[0] > intervals[i][1])
                {
                    ans.Add(intervals[i]);
                    continue;
                }
                if (newInterval[0] <= intervals[i][0] && newInterval[1] > intervals[i][1])
                {
                    if (curInterval[0] == -1)
                    {
                        curInterval[0] = newInterval[0];
                    }
                    continue;
                }
                if (newInterval[0] <= intervals[i][0] && newInterval[1] <= intervals[i][1])
                {
                    if (curInterval[0] == -1)
                    {
                        curInterval[0] = newInterval[0];
                    }
                    curInterval[1] = intervals[i][1];
                    ans.Add(curInterval);
                    continue;
                }
                if (newInterval[0] > intervals[i][0] && newInterval[1] <= intervals[i][1])
                {
                    curInterval[0] = intervals[i][0];
                    curInterval[1] = intervals[i][1];
                    ans.Add(curInterval);
                    continue;
                }
                if (newInterval[0] > intervals[i][0] && newInterval[0] <= intervals[i][1] && newInterval[1] > intervals[i][1])
                {
                    curInterval[0] = intervals[i][0];                    
                    continue;
                }
                if (newInterval[1] <= intervals[i][1])
                {
                    curInterval[1] = intervals[i][1];
                    ans.Add(curInterval);
                }
            }
            if (curInterval[0] == -1)
            {
                curInterval[0] = newInterval[0];
            }
            if (curInterval[1] == -1)
            {
                curInterval[1] = newInterval[1];
                ans.Add(curInterval);
            }
            
            return ans.OrderBy(i => i[0]).ToArray();
        }
    }
}
