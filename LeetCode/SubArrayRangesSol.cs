using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class SubArrayRangesSol
    {
        public long SubArrayRanges(int[] nums)
        {
            long sum = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                sum += SumRange(i, nums);
            }
            return sum;
        }

        private long SumRange(int startIndex, int[] nums)
        {
            long res = 0;
            long max = long.MinValue;
            long min = long.MaxValue;
            for (int i = startIndex; i < nums.Length; i++)
            {
                max = Math.Max(max, nums[i]);
                min = Math.Min(min, nums[i]);
                res += max - min;
            }

            return res;
        }
    }
}
