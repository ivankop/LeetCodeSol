using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SearchRotatedArray
    {
        public int Search(int[] nums, int target)
        {
            var index = FindMinIndex(nums, 0 , nums.Length - 1);
            
            var leftAns = FindTarget(nums, 0, index.Item2 - 1, target);
            if (leftAns != -1)
            {
                return leftAns;
            }
            var rightAns = FindTarget(nums, index.Item2, nums.Length - 1, target);
            if (rightAns != -1)
            {
                return rightAns;
            }
            return -1;
        }

        Tuple<int, int> FindMinIndex(int[] nums, int left , int right)
        {
            if (left >= right)
            {
                return new Tuple<int, int>(nums[left], left);
            }
           
            var mid = (left + right) / 2;
            if (nums[left] <= nums[mid] && nums[right] >= nums[mid])
            {
                return new Tuple<int, int>(nums[left], left);
            }
            var minLeft = FindMinIndex(nums, left, mid - 1);
            var minRight = FindMinIndex(nums, mid + 1, right);
            if (minLeft.Item1 < minRight.Item1 && minLeft.Item1 < nums[mid])
            {
                return minLeft;
            }
            if (minRight.Item1 < minLeft.Item1 && minRight.Item1 < nums[mid])
            {
                return minRight;
            }

            //if (nums[mid] < minLeft.Item1 &&  nums[mid] < minRight.Item1)
            {
                return new Tuple<int, int>(nums[mid], mid);
            }
        }

        int FindTarget(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (target > nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }

    }
}
