using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LongestIncreasingSubsequence
    {
        public int LengthOfLIS2(int[] nums)
        {
            List<int> list = new List<int>();
            //list.Add(nums[0]);
            var tmp = GetSeqLen(nums, 0, list);
            
            return tmp;

        }

        public int LengthOfLIS(int[] nums)
        {
            List<int> list = new List<int>();
            list.Add(nums[0]);
            // var tmp = GetSeqLen(nums, 0, list);
            int[] map = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                map[i] = 1;
            }

            
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                        map[i] = Math.Max(map[i], map[j] + 1);
                }
            }
            

            return map.Max();

        }

        private int GetSubLength(int[] nums, int index)
        {
            int ans = 1;
            int startVal = nums[index];
            for (int i = index + 1; i < nums.Length; i++)
            {
                if (nums[i] > startVal)
                {
                    ans++;
                    startVal = nums[i];
                }
            }
            return ans;
        }

        private int GetSeqLen(int[] nums, int index, List<int> list)
        {
            if (index >= nums.Length - 1)
                return list.Count;
            
            List<int> nextIndexList = new List<int>();
            for (int i = index + 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[index])
                {
                    nextIndexList.Add(i);
                    //break;
                }
            }
            if (nextIndexList.Count > 0)
            {
                int longestSeq = 0;
                foreach (var nextIndex in nextIndexList)
                {
                    int len1 = GetSeqLen(nums, nextIndex, new List<int>(list));
                    var newList = new List<int>(list);
                    newList.Add(nums[index]);
                    int len2 = GetSeqLen(nums, nextIndex, newList);
                    var tmp = Math.Max(len1, len2);
                    longestSeq = Math.Max(longestSeq, tmp);
                }
                
                return longestSeq;
            }
            list.Add(nums[index]);
            return list.Count;
        }
    }
}
