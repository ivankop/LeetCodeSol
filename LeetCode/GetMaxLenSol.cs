using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class GetMaxLenSol
    {
        public int GetMaxLen(int[] nums)
        {
            int maxLen = -1;
            List<int> subArr = new List<int>();
            int negativeCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    var tmp = GetMaxLen(subArr, negativeCount);
                    if (tmp > maxLen)
                    {
                        maxLen = tmp;
                    }
                    subArr.Clear();
                    negativeCount = 0;
                }
                else
                {
                    if (nums[i] < 0)
                    {
                        negativeCount++;
                    }
                    subArr.Add(nums[i]);
                }
            }

            var tmp1 = GetMaxLen(subArr, negativeCount);
            if (tmp1 > maxLen)
            {
                maxLen = tmp1;
            }
            return maxLen;
        }

        private int GetMaxLen(List<int> input, int negativeCount)
        {
            if (negativeCount % 2 == 0) //even number
            {
                return input.Count;
            }
            else
            {
                int count = 0;
                int left = 0;
                int right = input.Count-1;
                do
                {
                    if (input[left] < 0 || input[right] < 0)
                    {
                        count++;
                        break;
                    }
                    count++;
                    left++;
                    right--;
                }
                while (left <= right) ;
                return input.Count - count;
            }
        }
    }
}
