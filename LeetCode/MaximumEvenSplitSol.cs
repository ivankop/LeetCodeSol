using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaximumEvenSplitSol
    {
        public IList<long> MaximumEvenSplit(long finalSum)
        {
            List<long> result = new List<long>(); 
            if (finalSum % 2 != 0) //odd number
            {
                return result;
            }
            // result.Add(2);
            long k = 0;
            long sum = 0;
            while (k < finalSum)
            {
                while (result.Contains(k) || k == 0)
                    k += 2;
                result.Add(k);
                sum += k;
                if (finalSum - sum < k+2 + k+4)
                {
                    if (finalSum - sum != 0)
                    {
                        result.Add(finalSum - sum);
                    }
                    break;
                }
                
            }

            return result;

        }


    }
}
