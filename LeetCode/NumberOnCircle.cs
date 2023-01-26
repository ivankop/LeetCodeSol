using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class NumberOnCircle
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int num1 = A[i];
                int num2;
                if (i >= A.Length -1 )
                {
                    num2 = A[0];
                }
                else
                {
                    num2 = A[i + 1];
                }
                if ((num1 + num2) % 2 == 0)
                {
                    count++;
                    i = i + 1;
                }
            }

            return count;
        }

        private class Pair
        {
            public int num1 { get; set; }
            public int num2 { get; set; }

            public bool Equal(Pair p)
            {
                if (p.num1 == num1 && p.num2 == num2 ||
                    p.num2 == num1 && p.num1 == num2)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

