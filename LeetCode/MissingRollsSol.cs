using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MissingRollsSol
    {
        List<int> ans;
        Dictionary<Tuple<int, int, int>, bool> mem;
        public int[] MissingRolls(int[] rolls, int mean, int n)
        {
            ans = new List<int>();
            mem = new Dictionary<Tuple<int, int, int>, bool>();
            int m = rolls.Length;
            int sum = rolls.Sum();
            
            int target = mean * (m + n) - sum;
            Console.WriteLine($"{target}-{n}");
            if (target < n || n * 6 < target)
            {
                return ans.ToArray(); ;
            }
            int r = n;
            do
            {
                int avg = target / r;
                int[] tmpArr = new int[r - target % r];
                Array.Fill(tmpArr, avg);
                ans.AddRange(tmpArr);
                target = target - avg * tmpArr.Length;
                r = r - tmpArr.Length;
            }
            while (r != 0);
            /*
            int avg = target / n;
            int[] tmpArr = new int[n - target % n];
            Array.Fill(tmpArr, avg);
            RollsToTarget(target - avg * tmpArr.Length, n, new List<int>(tmpArr), avg * tmpArr.Length);
            */
            // Rolls(mean, sum, 0,m, n, new List<int>());
            return ans.ToArray();
        }

        private bool RollsToTarget(int target,int n, List<int> list, int currentSum)
        {
            var pos = new Tuple<int, int, int>(target, currentSum, list.Count);
            if (mem.ContainsKey(pos))
            {
                return mem[pos];
            }
            
            if (list.Count == n)
            {
                if (target == 0)
                {
                    ans = list;
                    return true;
                }
                mem[pos] = false;
                return false;
            }
            int r = n - list.Count;
            if (target < r || r * 6 < target)
            {
                return false;
            }
            int avg = target / r;
            for (int i = avg; i <= avg+1; i++)
            {
                if (target - i >= 0)
                {
                    var tmpList = new List<int>(list);
                    tmpList.Add(i);
                    var tmp = RollsToTarget(target - i, n, tmpList, currentSum + i);
                    if (tmp == true)
                        return true;

                }
                
            }
            mem[pos] = false;
            return false;
        }

    }
}
