using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class NumsSameConsecDiffSol
    {
        List<List<int>> ans;
        public int[] NumsSameConsecDiff(int n, int k)
        {
            ans = new List<List<int>>();

            for (int i = 1; i <= 9; i++)
            {
                FindNums(n, k, new List<int>(new int[] { i }));
            }

            int[] res= new int[ans.Count];
            for (int i=0; i<ans.Count; i++)
            {
                string numStr = string.Empty;
                for (int j = 0; j < ans[i].Count; j++)
                {
                    numStr += ans[i][j].ToString();
                }
                res[i] = int.Parse(numStr);
            }
            return res;
        }
        void FindNums(int n , int k , List<int> nums)
        {
            if (nums.Count == n)
            {
                ans.Add(nums);
                return;
            }
            var lastDigit = nums[nums.Count - 1];
            for (int i = 0; i <= 9; i++)
            {
                var tmp = Math.Abs(lastDigit - i);
                if (tmp == k)
                {
                    List<int> temp = new List<int>(nums);
                    temp.Add(i);
                    FindNums(n , k, temp);
                }
            }

        }
    }
}
