using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class KokoEatingBananas
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            Array.Sort(piles);
            int left = 1;
            int right = piles[piles.Length - 1];
            if (piles.Length == h)
            {
                return right;
            }
            int mid = (left + right) / 2;
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            int ans = 0;
            long hours = 0;
            while (left < right)
            {
                mid = (left + right) / 2;
                hours = FindK(piles, mid);
                //if (hours == h)
                    // return mid;
                if (hours > h)
                {
                    // need to eat more
                    left = mid + 1;
                }
                else
                {
                    // pq.Enqueue(mid, hours);
                    ans = mid;
                    right = mid - 1;
                }
            }

            hours = FindK(piles, left);
            if (hours <= h)
            {
                ans = left;
            }

            //var ans = pq.Dequeue();
            return ans;
        }

        long FindK(int[] piles, int k)
        {
            long count = 0;
            for (int i = 0; i < piles.Length; i++)
            {
                if (piles[i] <= k)
                    count++;
                else
                {
                    if (piles[i] % k == 0)
                    {
                        count += piles[i] / k;
                    }
                    else
                    {
                        count += piles[i] / k + 1;
                    }
                    
                }
            }
            return count;
        }
    }
}
