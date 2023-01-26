using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class EqualSum
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int maxSeg = 1;
            for (int i = 0; i < A.Length - 1; i++)
            {
                // get the equal sum from the starting index i
                int tmp = getEqualSumCount(A, A[i] + A[i + 1], i);
                // find the max
                if (tmp > maxSeg) 
                {
                    maxSeg = tmp;
                }
                // we can stop when the number of non-instersecting segments are greater than the number of remaning adjacen elements
                if (maxSeg > (A.Length - i) / 2)
                {
                    break;
                }
            }
            
            return maxSeg;
        }

        private int getEqualSumCount(int[] A, int value, int startIndex)
        {
            int count = 0;
            for (int i = startIndex; i < A.Length - 1; i++)
            {
                if (A[i] + A[i+1] == value)
                {
                    count++;
                    i++;
                }
            }
            return count;
        }
    }
}
