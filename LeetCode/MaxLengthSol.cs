using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaxLengthSol
    {
        public int MaxLength(IList<string> arr)
        {

            GetMaxLength(arr, 0, new HashSet<char>());
            return maxLength;
        }

        int maxLength = int.MinValue;

        void GetMaxLength(IList<string> arr, int index, HashSet<char> set)
        {
            if (index == arr.Count)
            {
                maxLength = Math.Max(maxLength, set.Count);
                return;
            }

            GetMaxLength(arr, index + 1, set);
            HashSet<char> currSet = new HashSet<char>(arr[index].ToCharArray());
            if (currSet.Count < arr[index].Length)
            {
                maxLength = 0;
                return;
            }
            if (!currSet.Overlaps(set))
            {
                currSet.UnionWith(set);
                
            }
            GetMaxLength(arr, index + 1, currSet);
        }
    }
}
