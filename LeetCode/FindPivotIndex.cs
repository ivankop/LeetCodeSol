using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindPivotIndex
    {public int PivotIndex(int[] nums)
        {
            int sum = nums.Sum();
            int left = 0;
            int right = sum;
            if (sum - nums[0] == 0)
                return 0;

            int pivotIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                left += nums[i - 1];
                right = sum - nums[i] - left;
                if (left == right)
                    return i;
            }
            return -1;
        }
    }
}
