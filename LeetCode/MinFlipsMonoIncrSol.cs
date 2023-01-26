using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinFlipsMonoIncrSol
    {
        public int MinFlipsMonoIncr(string s)
        {
            int ans = 0;
            int oneCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    oneCount++;
                } else if (oneCount > 0)
                {
                    oneCount--;
                    ans++;
                }

            }

            return ans;

        }
    }
}
