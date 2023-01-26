using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindMinSol
    {
        public int FindMin(int[] nums)
        {
            int ans = nums[0];
            FindMinRec(nums, 0, nums.Length, ref ans);
            return ans;
        }
        private bool FindMinRec(int[] nums, int left, int right, ref int ans)
        {
            int mid = (left + right) / 2;
            int before = mid - 1 >= 0 ? mid - 1 : nums.Length - 1;
            int after = mid + 1 < nums.Length ? mid + 1 : 0;

            if (nums[mid] < nums[before] && nums[mid] < nums[after])
            {
                ans = nums[mid];
                return true;
            }

            bool ansFound = false;
            if (mid > left)
            {
                ansFound = FindMinRec(nums, left, mid, ref ans);
            }

            if (!ansFound && right > mid + 1)
            {
                ansFound = FindMinRec(nums, mid + 1, right, ref ans);
            }
            return ansFound;
        }
    }
}
