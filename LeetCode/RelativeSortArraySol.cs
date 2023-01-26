using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RelativeSortArraySol
    {
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            foreach (var item in arr1)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }
                dict[item]++;
            }
            List<int> list = new List<int>();
            foreach (var item in arr2)
            {
                for (int i = 0; i < dict[item]; i++)
                {
                    list.Add(item);
                }
                dict.Remove(item);
            }
            foreach (var item in dict)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    list.Add(item.Key);
                }
            }
           
            return list.ToArray();

        }
    }
}
