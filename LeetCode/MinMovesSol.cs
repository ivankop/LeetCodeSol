using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.MedianFinder;

namespace LeetCode
{
    public class MinMovesSol
    {
        public int MinMoves1(int[] nums)
        {
            SortedList<int, int> dict = new SortedList<int, int>();
            foreach (int i in nums)
            {
                if (!dict.ContainsKey(i))
                {
                    dict.Add(i, 0);
                }
                dict[i]++;
            }
            int count = 0;
            for (int i = 0; i < dict.Count - 1 && dict.Count > 1; i++)
            {
                var current = dict.Keys[i];
                var last = dict.Keys[dict.Count - 1];
                
                count += last - current;
                
            }
            if (dict[dict.Keys[dict.Count - 1]] > 1)
            {
                count += dict.Count - 1;
            }
            
            return count;
        }

        public int MinMoves(int[] nums)
        {
            int min = nums.Min();
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count = count + nums[i] - min;
            }
            return count;
        }

        public int MinMoves2(int[] nums)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            int max = nums[0];
            foreach (var i in nums)
            {
                pq.Enqueue(i, i);
                max = Math.Max(max, i);
            }
            int count = 0;
            while (pq.Peek() != max)
            {
                var gap = max - pq.Peek();
                PriorityQueue<int, int> tmpQueue = new PriorityQueue<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    var item = pq.Dequeue();
                    if (i != nums.Length - 1)
                        item += gap;
                    max = Math.Max(max, item);
                    tmpQueue.Enqueue(item, item);
                }
                count += gap;
                pq = tmpQueue;
            }
            return count;
        }
    }
}
