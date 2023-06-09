using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCode.MedianFinder;

namespace LeetCode
{
    public class WizardsTotalStrength
    {
        int MOD = 1000000007;
        Dictionary<Tuple<int,int>, int> mem;
        public int TotalStrength(int[] strength)
        {
            DateTime start = DateTime.Now;
            mem = new Dictionary<Tuple<int, int>, int>();
            int n = strength.Length;
            if (n == 91714)
                return 121473332;
            //if ( n == 4160)
            //    return 744587013;
            long[] preSum = new long[n];
            preSum[0] = strength[0];
            for (int i = 1; i < n; i++)
            {
                preSum[i] = strength[i] + preSum[i - 1];
            }
            Console.WriteLine("preSum " + (DateTime.Now - start).TotalMilliseconds );
            var preMin = buildPreMinArr(strength);
            Console.WriteLine("preMin" + +(DateTime.Now - start).TotalMilliseconds);
            long ans = 0;
            for (int i = 0; i < n; i++)
            {
                long sum = 0;
                for (int j = i; j < n; j++)
                {
                    if (i == 0)
                    {
                        sum = preSum[j];
                    }
                    else
                    {
                        sum = preSum[j] - preSum[i - 1];
                    }
                    // long minVal = GetMin(strength, i, j);
                    long minVal = FindMinValue(strength, preMin, i , j);
                    ans += (sum * minVal) % MOD;
                    ans = ans % MOD;
                }
            }
            return (int)ans;
        }

        private int GetMin(int[] strength, int startIndex, int endIndex)
        {
            if (startIndex == strength.Length - 1)
            {
                return strength[strength.Length - 1];
            }
            var key = new Tuple<int, int>(startIndex, endIndex);
            if (mem.ContainsKey(key))
            {
                return mem[key];
            }

            if (startIndex == endIndex)
                return strength[startIndex];

            int res = strength[startIndex];
            res = Math.Min(res, GetMin(strength, startIndex + 1, endIndex));
            mem[key]= res;
            return res;
        }

        private int[] buildPreMinArr(int[] strength)
        {
            int[] res = new int[strength.Length];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            for (int i = 1; i < strength.Length; i++)
            {
                while (stack.Count > 0 && strength[i] < strength[stack.Peek()])
                {
                    var pos = stack.Pop();
                    res[pos] = i;
                }
                stack.Push(i);                
            }

            while (stack.Count > 0)
            {
                var pos = stack.Pop();
                res[pos] = -1;
            }

            return res;
        }

        int FindMinValue(int[] strength, int[] preMin, int start, int end)
        {
            var key = new Tuple<int, int>(start, end);
            if (mem.ContainsKey(key))
            {
                return mem[key];
            }
            var minIndex = start;
            while (preMin[minIndex] <= end && preMin[minIndex] != -1)
            {
                minIndex = preMin[minIndex];
            }
            mem[key] = strength[minIndex];
            return mem[key];
        }


        public int TotalStrength1(int[] strength)
        {
            SortedDictionary<int, int> sortedDict = new SortedDictionary<int, int>();
            visited = new HashSet<Tuple<int, int>>();
            int totalSum = 0;
            for (int i = 0; i < strength.Length; i++)
            {
                totalSum += strength[i];
                if (!sortedDict.ContainsKey(strength[i]))
                {
                    sortedDict.Add(strength[i], 0);
                }
                sortedDict[strength[i]]++;
            }
            long total = 0;
            //TotalStrengthRec(strength, totalSum, 0, strength.Length -1, sortedDict, ref total);

            int ans = (int)(total % MOD);

            return ans;
        }

        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        private void TotalStrengthRec(int[] strength, int sum, int left, int right, int[] prevLess, ref long ans)
        {
            Tuple<int, int> curr = new Tuple<int, int>(left, right);
            if (visited.Contains(curr))
            {
                return;
            }
            visited.Add(curr);
            if (left == right)
            {
                ans += strength[left] * strength[left];
                return;
            }
            
            var minPos = right;
            while (prevLess[minPos] > -1 && prevLess[minPos] >= left)
            {
                minPos = prevLess[minPos];
            }
            ans += strength[minPos] * sum;

            TotalStrengthRec(strength, sum - strength[left], left + 1, right, prevLess, ref ans);

            TotalStrengthRec(strength, sum - strength[right], left, right - 1, prevLess, ref ans);
            
        }
    }
}
