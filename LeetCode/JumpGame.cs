using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class JumpGame
    {
        Dictionary<int, bool> mem;
        public bool CanJump(int[] nums)
        {
            mem = new Dictionary<int, bool>();
            var ans = Jump(nums, 0);
            return ans;
        }

        private bool Jump(int[] nums, int index)
        {
            if (mem.ContainsKey(index))
            {
                return mem[index];
            }
            if (index >= nums.Length - 1 || nums[index] >= nums.Length - index)
            {
                return true;
            }
            //if (index > nums.Length)
            //{
            //    return false;
            //}
            for (int i = nums[index]; i > 0; i--)
            {
                var tmp = Jump(nums, index + i);
                if (tmp)
                    return true;
            }
            mem[index] = false;
            return false;
        }

    }
}
