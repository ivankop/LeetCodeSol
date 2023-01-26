using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MedianFinder
    {
        SortedList<int,int> dic = new SortedList<int,int>(new DuplicateKeyComparator<int>());
        public MedianFinder()
        {

        }

        public void AddNum(int num)
        {

            dic.Add(num, num);
        }

        public double FindMedian()
        {
            if (dic.Count == 1)
            {
                return dic[dic.Keys[0]];
            }
            int mid = dic.Count / 2;
            //Console.WriteLine(mid);
            if (dic.Count % 2 == 0)
            {
                // var key = dic;
                //Console.WriteLine(dic.ElementAt(mid).Value + dic.ElementAt(mid+1).Value);
                // var tmp = dic.Keys[mid];
                mid--;
                double ans = ((double)dic.Keys[mid] + (double)dic.Keys[mid+1]) / 2;
                return ans;
            }
            else
            {
                return dic.ElementAt(mid).Value;
            }
        }
        public class DuplicateKeyComparator<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);
                if (result == 0)
                {
                    return 1;
                }
                else
                {
                    return result;
                }
            }
        }
    }

    
}
