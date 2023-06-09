using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Bitwise
{
    public class MinFlipsSol
    {
        public int MinFlips(int a, int b, int c)
        {
            BitArray arrA = new BitArray(new int[] { a });
            BitArray arrB = new BitArray(new int[] { b });
            BitArray arrC = new BitArray(new int[] { c });

            int maxLen = Math.Max(arrA.Length, arrB.Length);
            maxLen = Math.Max(maxLen, arrC.Length);
            arrA.Length = maxLen;
            arrB.Length = maxLen;
            arrC.Length = maxLen;
            int count = 0;
            for (int i = 0; i < maxLen; i++)
            {
                bool bitA = arrA[i];
                bool bitB = arrB[i];
                bool bitC = arrC[i];
                if ((bitA || bitB) != bitC)
                {
                    if (bitA && bitB && !bitC)
                    {
                        count += 2;
                    } 
                    else 
                    {
                        count += 1;
                    }
                }
            }
            return count;

        }
    }
}
