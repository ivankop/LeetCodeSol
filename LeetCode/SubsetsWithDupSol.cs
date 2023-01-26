using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SubsetsWithDupSol
    {
        IList<IList<int>> subsets = new List<IList<int>>();
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<int> list = new List<int>();
            FindSubsetsRec(nums, 0, list);

            return subsets;
        }

        private void FindSubsetsRec(int[] nums, int index, List<int> parentSet)
        {
            if (index == nums.Length )
            {
                if (subsets.Count > 0 && subsets.Any(x => parentSet.SequenceEqual(x)))                
                    return;
                subsets.Add(parentSet);
                return;
            }
            
            FindSubsetsRec(nums, index + 1, new List<int>(parentSet));

            parentSet.Add(nums[index]);
            var newSet = parentSet.OrderBy(x => x).ToList();
            FindSubsetsRec(nums, index + 1, new List<int>(newSet));
        }

    }
}
