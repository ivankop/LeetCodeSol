using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ThreeSumSol
    {
        List<IList<int>> ans;
        Dictionary<Tuple<int, string>, bool> mem;
        Dictionary<string, bool> dict;

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            ans = new List<IList<int>>();
            mem = new Dictionary<Tuple<int, string>, bool>();
            dict = new Dictionary<string, bool>();
            nums = nums.OrderBy(x => x).ToArray();
            HashSet<int> set = new HashSet<int>();
            Dictionary<int, HashSet<int>> posDict = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
                if (!posDict.ContainsKey(nums[i]))
                {
                    posDict[nums[i]] = new HashSet<int>();
                }
                posDict[nums[i]].Add(i);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    var tmp = nums[i] + nums[left] + nums[right];
                    if (tmp == 0)
                    {
                        List<int> triplet = new List<int>();
                        triplet.Add(nums[left]);
                        triplet.Add(nums[i]);
                        triplet.Add(nums[right]);
                        triplet = triplet.OrderBy(x => x).ToList();
                        var keyStr = string.Join(',', triplet);
                        if (!dict.ContainsKey(keyStr))
                        {
                            ans.Add(triplet);
                            dict[keyStr] = true;
                            //break;
                        }
                        left++;
                        right--;
                    }
                    else if (tmp > 0)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }
            

            return ans;
        }
        public IList<IList<int>> ThreeSum1(int[] nums)
        {
            ans = new List<IList<int>>();
            mem = new Dictionary<Tuple<int, string>, bool>();
            dict = new Dictionary<string, bool>();
            ThreeSumRec(nums, 0, new List<int>());
            return ans;
        }

        void ThreeSumRec(int[] nums, int index, List<int> triplet)
        {
            // var pos = new Tuple<int, int>(index, triplet.Count);
            var keyStr = string.Join(',', triplet);
            var key = new Tuple<int, string>(index, keyStr);
            if (mem.ContainsKey(key) || dict.ContainsKey(keyStr))
            {
                return;
            }
            mem[key] = true;
            if (triplet.Count == 3)
            {
                if (triplet.Sum() == 0)
                {
                    /*
                    foreach (var list in ans)
                    {
                        if (list.SequenceEqual(triplet))
                        {
                            mem[key] = true;
                            return;
                        }
                    }*/
                    ans.Add(triplet);
                    dict.Add(keyStr, true);
                }
                mem[key] = true;
                return;
            }
            if (index < nums.Length)
            {
                ThreeSumRec(nums, index + 1, new List<int>(triplet));
                triplet.Add(nums[index]);
                triplet = triplet.OrderBy(x => x).ToList();
                ThreeSumRec(nums, index + 1, new List<int>(triplet));
            }
            
        }
    }
}
