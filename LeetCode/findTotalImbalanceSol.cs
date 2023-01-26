using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class findTotalImbalanceSol
    {
        public static long findTotalImbalance(List<int> rank)
        {
            var groups = createCombinations(0, new List<int>(), rank.ToArray());
            int imbalanceCount = 0;
            foreach (var group in groups)
            {
                if (!checkImbalance(group))
                {
                    imbalanceCount++;
                }
            }
            return imbalanceCount;
        }

        private static bool checkImbalance(List<int> group)
        {
            group.Sort();
            for (int i = 0; i < group.Count - 1; i++)
            {
                if (group[i] + 1 < group[i+1])
                {
                    return false;
                }
            }
            return true;
        }

        private static List<List<int>> createCombinations(int startIndex, List<int> pairs, int[] initialArray)
        {
            var combinations = new List<List<int>>();
            for (int i = startIndex; i < initialArray.Length; i++)
            {
                var tmpList = new List<int>();
                tmpList.AddRange(pairs);
                tmpList.Add(initialArray[i]);
                combinations.Add(tmpList);
                combinations.AddRange(createCombinations(i + 1, tmpList, initialArray));
            }

            return combinations;
        }
    }
}
