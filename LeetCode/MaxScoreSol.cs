using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaxScoreSol
    {
        public long MaxScore(int[] nums1, int[] nums2, int k)
        {
            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
            for (int i = 0; i < nums1.Length; i++)
            {
                pairs.Add(new Tuple<int, int>(nums1[i], nums2[i]));
            }
            pairs = pairs.OrderByDescending( p => p.Item2).ToList();
            int curSum = 0;
            PriorityQueue<int, int> q = new PriorityQueue<int, int>();
            int ans = int.MinValue;
            foreach (var pair in pairs)
            {
                curSum += pair.Item1;
                q.Enqueue(pair.Item1, pair.Item2);

                if (q.Count > k)
                {
                    var removeVal = q.Dequeue();
                    curSum -= removeVal;
                }

                if (q.Count == k)
                {
                    ans = Math.Max(ans, curSum * pair.Item2);
                }
            }
            return ans;
        }
    }
}
