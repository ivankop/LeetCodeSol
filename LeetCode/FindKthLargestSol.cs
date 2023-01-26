using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindKthLargestSol
    {
        public int FindKthLargest(int[] nums, int k)
        {
            var ans = FindKthLargestRec(nums, 0, nums.Length - 1, k);
            return ans;
        }

        public int FindKthLargestRec(int[] nums,int left, int right, int k)
        {
            int pos = quickSelect(nums,left,right);
            var index = nums.Length  - pos;
            if (index == k)
            {
                return nums[pos];
            }
            else if (index < k)
            {
                return FindKthLargestRec(nums, left, pos - 1, k);
            }
            return FindKthLargestRec(nums, pos + 1, right, k);
        }

        int quickSelect(int[] nums, int left, int right)
        {
            int pivotValue = nums[right];
            int position = left;
            for (int i = left; i <= right; i++)
            {
                if (nums[i] < pivotValue)
                {
                    // swap
                    /*
                    int tmp1 = nums[i];
                    nums[i] = nums[position];
                    nums[position] = tmp1;
                    position++;
                    */
                    (nums[i], nums[position]) = (nums[position], nums[i]);
                    position++;
                }
            }
            //swap
            /*
            int tmp = nums[right];
            nums[right] = nums[position];
            nums[position] = tmp;
            */
            (nums[right], nums[position]) = (nums[position], nums[right]);
            return position;
        }
    }

    
}
