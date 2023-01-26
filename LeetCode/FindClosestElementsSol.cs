using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindClosestElementsSol
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int xIndex = FindX(arr, x);
            List<int> ans = new List<int>();
            ans.Add(arr[xIndex]);
            int left = xIndex - 1;
            int count = 0;
            PriorityQueue<int, int> rightPQ = new PriorityQueue<int, int>();
            int right = xIndex + 1;
            while(ans.Count < k)
            {
                int leftValue = left >= 0 ? x - arr[left] : int.MaxValue;
                int rightValue = right < arr.Length ? arr[right] - x : int.MaxValue;
                if(leftValue <= rightValue)
                {
                    ans.Insert(0, arr[left]);
                    left--;
                }
                else
                {
                    ans.Add(arr[right]);
                    right++;
                }
            }
            return ans;
        }
        private int FindX(int[] arr, int x)
        {
            int lower = 0;
            int upper = arr.Length - 1;
            int index = (lower + upper) / 2;
            int closestValue = int.MaxValue;
            int closestIndex = index;
            while (lower <= upper)
            {
                if (arr[index] == x)
                    return index;
                var range = Math.Abs(x - arr[index]);
                if (range < closestValue || (range == closestValue && index < closestIndex))
                {
                    closestIndex = index;
                    closestValue = range;
                }
                if (arr[index] < x)
                {
                    lower = index + 1;
                }
                else
                {
                    upper = index - 1;
                }

                index = (lower + upper) / 2;
            }
            return closestIndex;
        }
    }
}
