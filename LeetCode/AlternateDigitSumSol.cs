using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AlternateDigitSumSol
    {
        public int AlternateDigitSum(int n)
        {
            var charList = n.ToString().ToList() ;
            //var sigDigitIndex = charList.FindIndex(x => x == charList.Max());
            int sum = charList[0] - '0';
            int index = 1;
            int sign = -1;
            
            while (index < charList.Count)
            {
                sum += (charList[index] - '0') * sign;
                sign = -sign;
                index++;
            }
            return sum;
        }
    }
}
