using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SubsetsSol
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            FindSubsetsRec(nums, 0, new List<int>(), ans);

            return ans;
        }

        private void FindSubsetsRec(int[] nums, int index, List<int> parentList, IList<IList<int>> ans)
        {
            if(index == nums.Length)
            {
                ans.Add(parentList);
                return;
            }
            FindSubsetsRec(nums, index + 1, new List<int>(parentList), ans);
            parentList.Add(nums[index]);
            FindSubsetsRec(nums, index + 1, new List<int>(parentList), ans);
        }
    }
}
