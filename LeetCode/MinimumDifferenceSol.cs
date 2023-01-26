using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinimumDifferenceSol
    {
        HashSet<string> visited;
        int ans = int.MaxValue;
        int sum = 0;
        public int MinimumDifference1(int[] nums)
        {
            visited = new HashSet<string>();
            MinimumDifferenceRec(nums, 1, new HashSet<int>( new int[] { 0 }));
            return ans;
        }

        public int MinimumDifference(int[] nums)
        {
            sum = nums.Sum();
            MinimumDifferenceRec2(nums, 0, new HashSet<int>(), 0);
            return ans;
        }

        void MinimumDifferenceRec2(int[] nums, int index, HashSet<int> list, int total)
        {
            if (index == nums.Length)
                return;
            /*
            if (list.Count == nums.Length / 2)
            {
                var diff = difference(nums, list);
                ans = Math.Min(ans, diff);
                return;
            }
            */
            // List<int> tmp = new List<int>(list);
            list.Add(index);
            total += nums[index];
            if (list.Count == nums.Length / 2)
            {
                var diff = Math.Abs(total - (sum - total)); //difference(nums, list);
                ans = Math.Min(ans, diff);
                return;
            }
            for (int i = index + 1; i < nums.Length; i++)
            {
                HashSet<int> tmp = new HashSet<int>(list);
                // tmp.Add(i);
                MinimumDifferenceRec2(nums, i, tmp, total);
            }
        }

        void MinimumDifferenceRec(int[] nums, int index, HashSet<int> list)
        {
            if (index == nums.Length)
                return;
            if (list.Count == nums.Length / 2)
            {
                var diff = difference(nums, list);
                ans = Math.Min(ans, diff);
                return;
            }
            HashSet<int> tmp = new HashSet<int>(list);
            tmp.Add(index);
            MinimumDifferenceRec(nums, index + 1, tmp);
            MinimumDifferenceRec(nums, index + 1, new HashSet<int>(list));
        }

        int difference(int[] nums, HashSet<int> list)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (list.Contains(i))
                {
                    sum1 += nums[i];
                }
                else
                {
                    sum2 += nums[i];
                }
            }
            return Math.Abs(sum1 - sum2);
        }
        void updateMem(int[] nums, List<int> list)
        {
            string key1 = string.Empty;
            string key2 = string.Empty;
            for (int i = 0; i < nums.Length; i++)
            {
                if (list.Contains(i))
                {
                    key1 += i.ToString() + "-";
                }
                else
                {
                    key2 += i.ToString() + "-";
                }
            }
            visited.Add(key1);
            visited.Add(key2);
        }
    }
}
