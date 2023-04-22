using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class FirstMissingPositiveSol
    {
        public int FirstMissingPositive(int[] nums)
        {
            HashSet<int> existed = new HashSet<int>();
            int ans = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                existed.Add(nums[i]);
                if (nums[i] == ans)
                {
                    while (existed.Contains(ans))
                    {
                        ans++;
                    }
                }    
            }
            return ans;
        }
    }
}
