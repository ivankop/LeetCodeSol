using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SmallestRangeCoverage
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            SortedList<int, HashSet<int>> dict = new SortedList<int, HashSet<int>>();
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 0; j < nums[i].Count; j++)
                {
                    if (!dict.ContainsKey(nums[i][j]))
                    {
                        dict.Add(nums[i][j], new HashSet<int>());
                    }
                    dict[nums[i][j]].Add(i);
                }
            }
            int k = nums.Count;
            List<int> smallestList = new List<int>();
            int smallestRange = int.MaxValue;
            for (int i = 0; i < dict.Keys.Count - 1; i++)
            {
                var num = dict.Keys[i];
                HashSet<int> set = new HashSet<int>(dict[num]);
                List<int> list = new List<int>();
                list.Add(dict.Keys[i]);
                int range = 0;
                for (int j = i + 1; j < dict.Keys.Count && set.Count < k; j++)
                {
                    set.UnionWith(dict[dict.Keys[j]]);
                    list.Add(dict.Keys[j]);
                    range = dict.Keys[j] - dict.Keys[i];
                }
                if (set.Count == k && (range < smallestRange || (range == smallestRange && list[0] < smallestList[0])))
                {
                    smallestRange = range;
                    smallestList = new List<int>();
                    smallestList.Add(list[0]);
                    smallestList.Add(list[list.Count-1]);
                }
            }
            
            return smallestList.ToArray();
        }

        
    }
}
