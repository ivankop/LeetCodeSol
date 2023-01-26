using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            SortedSet<int> set = new SortedSet<int>();
            List<int> list = new List<int>();
            Dictionary<int, int> count = new Dictionary<int, int>();

            for (int i = 0; i < k; i++)
            {
                set.Add(nums[i]);
                IncreaseKey(count, nums[i]);
            }
            list.Add(set.Max);

            for (int i = 1; i <= nums.Length - k; i++)
            {
                set.Add(nums[i + k - 1]);
                IncreaseKey(count, nums[i + k - 1]);

                set.Remove(nums[i-1]);
                DecreaseKey(count, nums[i - 1]);

                if (count[nums[i - 1]] > 0)
                {
                    set.Add(nums[i - 1]);
                }

                list.Add(set.Max);
            }

            return list.ToArray();
        }

        private void IncreaseKey(Dictionary<int, int> count, int key)
        {
            if (!count.ContainsKey(key))
            {
                count[key] = 0;
            }
            count[key]++;
        }

        private void DecreaseKey(Dictionary<int, int> count, int key)
        {
            if (!count.ContainsKey(key))
            {
                return;
            }
            count[key]--;
        }
    }
}
