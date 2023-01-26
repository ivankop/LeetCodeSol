using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TriangularSumSol
    {
        public int TriangularSum(int[] nums)
        {
            // int sum = 0;
            while (nums.Length > 1)
            {
                int[] newNums = new int[nums.Length - 1];
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    newNums[i] = (nums[i] + nums[i+1])%10;
                }
                nums = newNums;
            }
            return nums[0];
        }
    }
}
