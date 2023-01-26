using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class SumZeroSol
    {
        public int[] SumZero(int n)
        {
            var res = new int[n];
            int count = 0;
            if (n % 2 != 0)
            {
                res[0] = 0;
                count++;
            }
            int num = 1;
            while(count < n)
            {
                res[count] = num;
                count++;
                res[count] = num * -1;
                count++;
                num++;
            }
            return res;
        }
    }
}
