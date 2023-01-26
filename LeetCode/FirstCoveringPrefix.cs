using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class FirstCoveringPrefix
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var dict = A.Select(o => o).Distinct().ToDictionary(x => x, x => false);
            var count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (dict[A[i]] == false)
                {
                    dict[A[i]] = true;
                    count++;
                }
                if (count == dict.Count)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
