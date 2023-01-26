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
        public int TotalStrength(int[] strength)
        {
            int sum = 0;
            Stack<int> stack = new Stack<int>();
            visited = new HashSet<Tuple<int, int>>();
            int[] previousLess = new int[strength.Length];
            Array.Fill(previousLess, -1);
            for (int i = 0; i < strength.Length; i++)
            {
                while (stack.Count > 0 && strength[stack.Peek()] > strength[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    previousLess[i] = stack.Peek();
                }
                stack.Push(i);
                sum += strength[i];
            }
            /*
            int[] res = new int[strength.Length];
            for (int i = 0; i < strength.Length; i++)
            {
                var prev = previousLess[i] > -1 ? res[previousLess[i]] : 0;
                res[i] = prev + (i - previousLess[i]) * strength[i];
                sum = (sum + res[i]) % MOD;
            }
            */
            long total = 0;
            TotalStrengthRec(strength, sum, 0, strength.Length - 1, previousLess, ref total);

            int ans = (int)(total % MOD);

            return ans;
        }

        private int GetMin(int startIndex, int endIndex, int[] prefix, int[] subfix)
        {
            var startMin = Math.Min(prefix[startIndex], subfix[startIndex]);
            var endMin = Math.Min(prefix[endIndex], subfix[endIndex]);

            return Math.Min(startMin, endMin);
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
