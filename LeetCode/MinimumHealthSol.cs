using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class MinimumHealthSol
    {
        public long MinimumHealth(int[] damage, int armor)
        {
            int maxDamage = 0;
            long totalDamage = 0;
            for (int i = 0; i < damage.Length; i++)
            {
                totalDamage += damage[i];
                if (damage[i] > maxDamage)
                {
                    maxDamage = damage[i];
                }
            }

            if (maxDamage <= armor)
            {
                return totalDamage - maxDamage + 1;
            }
            else
            {
                return totalDamage - armor + 1;
            }
        }
    }
}
