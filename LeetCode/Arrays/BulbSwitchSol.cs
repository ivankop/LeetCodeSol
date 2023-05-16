using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class BulbSwitchSol
    {
        public int BulbSwitch(int n)
        {
            BitArray builbs = new BitArray(n + 1, true) ;
            builbs[0] = false ;
            int ans = n;
            var step = 2;
            for (int i = 1; i <= n; i++)
            {
                for (int j = step; j <= n; j += step)
                {
                    builbs[j] = !builbs[j];
                    if (builbs[j])
                        ans++;
                    else
                        ans--;
                }
                step++;
            }
            // var ans = builbs.Where(b => b).Count();
            return ans;
        }
    }
}
