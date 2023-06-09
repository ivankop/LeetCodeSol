using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinOperationsSol
    {
        public int MinOperations(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            var sum1 = nums1.Sum();
            var sum2 = nums2.Sum();
            if (sum2 > sum1)
            {
                // swap
                (nums1, nums2) = (nums2, nums1);
                (sum1, sum2) = (sum2, sum1);
            }
            
            var step = 0;
            List<int> list1 = new List<int>(nums1);
            List<int> list2 = new List<int>(nums2);
            while (sum1 > nums1.Length || sum2 < nums2.Length * 6)
            {
                int gap1 = list1[list1.Count - 1] - 1;
                int gap2 = 6 - list2[0];
                if (gap1 > gap2)
                {
                    Decrease(list1, ref sum1, sum2);
                }
                else 
                {
                    Increase(list2, ref sum2, sum1);
                }
                
                
                if (sum1 == sum2)
                {
                    return step;
                }
                step++;
            }
            
            return -1;
        }

        private void Decrease(List<int> nums, ref int sum, int target)
        {
            int i = nums.Count - 1;
            if (nums[i] < sum - target + 1)
            {
                sum = sum - nums[i] + 1;
                nums.RemoveAt(i);
                nums.Insert(0, 1);
            }
            else
            {
                nums[i] = sum - target;
                sum = target;
                
            }

        }

        private void Increase(List<int> nums, ref int sum, int target)
        {
            int i = 0;
            if (sum - nums[i] + 6 < target)
            {
                sum = sum + 6 - nums[i];
                nums.RemoveAt(i);
                nums.Add(6);
            }
            else
            {
                nums[i] = nums[i] + target - sum;
                sum = target;
                
            }
        }
    }
}
