using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public  class SiblingNumberSol
    {
        public int solution(int N)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var tmp = N.ToString().ToCharArray();
            int[] digits = N.ToString().ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToArray();
            digits.Where(c => c > 0).Count();
            digits = digits.OrderByDescending(c => c).ToArray();
            string tmpStr = string.Join("", digits);
            int res = int.Parse(tmpStr);

            if (res > 100000000)
            {
                return -1;
            }
            return res;
        }
    }
}
