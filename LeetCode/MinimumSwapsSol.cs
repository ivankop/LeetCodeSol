using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinimumSwapsSol
    {
        public int MinimumSwaps(int[] nums)
        {
            int minPos = nums.Length;
            int maxPos = -1;
            int min = nums[0];
            int max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= min)
                {
                    if (nums[i] < min)
                    {
                        minPos = i;
                    }
                    else
                    {
                        minPos = Math.Min(minPos, i);
                    }
                    
                    min = nums[i];
                }

                if (nums[i] >= max)
                {
                    maxPos = Math.Max(maxPos, i);
                    max = nums[i];
                }
            }
            int swapCount = 0;
            while (minPos != 0 || maxPos != nums.Length - 1)
            {
                var minStep = minPos - 0;
                var maxStep = nums.Length - 1 - maxPos;
                if ((minStep == 0 || maxStep < minStep) && maxStep != 0)
                {
                    // swap
                    var tmp = nums[maxPos + 1];
                    nums[maxPos + 1] = nums[maxPos];
                    nums[maxPos] = tmp;
                    if (maxPos + 1 == minPos)
                    {
                        minPos--;
                    }
                    maxPos++;
                    
                }
                else if (minPos > 0)
                {
                    var tmp = nums[minPos - 1];
                    nums[minPos - 1] = nums[minPos];
                    nums[minPos] = tmp;
                    if (minPos - 1 == maxPos)
                    {
                        maxPos++;
                    }
                    minPos--;
                }
                swapCount++;
            }
            return swapCount;
        }
    }
}
