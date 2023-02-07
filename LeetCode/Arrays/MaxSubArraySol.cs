using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class MaxSubArraySol
    {
        int ans = int.MinValue;
        public int MaxSubArray(int[] nums) {
            ans = nums[0];
            int sum = ans;
            // MaxSubArrayRec(nums, 1, nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] + sum >= nums[i])
                {
                    sum = nums[i] + sum;
                }
                else
                {
                    sum = nums[i];
                }
                ans = Math.Max(ans, sum);
            }
            return ans;
        }

        private void MaxSubArrayRec(int[] nums, int index, int sum)
        {
            if (index == nums.Length)
            {
                return;
            }
            if (nums[index] + sum >= nums[index])
            {
                sum = nums[index] + sum;
            }
            else
            {
                sum = nums[index];
            }
            ans = Math.Max(ans, sum);
            MaxSubArrayRec(nums, index + 1, sum);
        }
    }
}
