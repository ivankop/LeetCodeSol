using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SumSubarrayMinsSol
    {
        int sum = 0;
        Dictionary<Tuple<int, int>, int> mem = new Dictionary<Tuple<int, int>, int>();
        int MOD = 1000000007;
        public int SumSubarrayMins(int[] arr)
        {
            sum = 0;
            Stack<int> stack = new Stack<int>();
            int[] previousLess = new int[arr.Length];
            Array.Fill(previousLess, -1);
            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    previousLess[i] = stack.Peek();
                }
                stack.Push(i);
            }
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                var prev= previousLess[i] > -1 ? res[previousLess[i]] : 0;
                res[i] = prev + (i - previousLess[i]) * arr[i];
                sum =  (sum + res[i]) % MOD;
            }
            return sum;
        }
        
        private int FindMin(int[] arr, int left, int right)
        {
            Tuple<int, int> pos = new Tuple<int, int>(left,right);
            if (mem.ContainsKey(pos))
                return mem[pos];
            if (left == right)
            {
                mem[pos] = arr[left];
                sum += arr [left];
                return arr[left];
            }
            int mid = (left + right) / 2;
            int minLeft = FindMin(arr, left, mid);
            int minRight = FindMin(arr, mid+1, right);
            int currMin = Math.Min(minLeft, minRight);
            //sum = (sum + currMin) % MOD;
            mem[pos] = currMin;
            return currMin;
        }
    }
}
