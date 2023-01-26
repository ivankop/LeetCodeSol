using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class NumRollsToTargetSol
    {
        Dictionary<Tuple<int, int, int>, int> mem;
        int MOD = 1000000007;
        public int NumRollsToTarget(int n, int k, int target)
        {
            mem = new Dictionary<Tuple<int, int, int>, int>();
            var ans = Roll(n, k, target);
            return ans;
        }

        int Roll(int n, int k, int target)
        {
            var pos = new Tuple<int, int, int>(n, k, target);
            if (mem.ContainsKey(pos))
            {
                return mem[pos];
            }
            if (target <= 0 || (n == 1 && target > k))
            {
                return 0;
            }

            if (n == 1 && target <= k)
            {
                return 1;
            }

            int count  = 0;
            for (int i = 1; i <= k; i++)
            {
                count += Roll(n - 1, k, target - i);
                count %= MOD;
            }
            mem.Add(pos, count);
            return count;
        }
    }
}
