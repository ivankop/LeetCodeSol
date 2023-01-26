using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MyAtoiSol
    {
        public int MyAtoi(string s)
        {
            bool isNegative = false;
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
                return 0;
            var strList = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            s = strList[0];
            int index = 0;
            if (s[index] == '-')
            {
                isNegative = true;
                index++;
            } else if (s[index] == '+')
            {
                index++;
            }
            if (index == s.Length || !char.IsDigit(s[index]))
            {
                return 0;
            }
            StringBuilder stringBuilder = new StringBuilder();
            while (index < s.Length)
            {
                //var c = s[index];
                if (!char.IsDigit(s[index]))
                    break;
                stringBuilder.Append(s[index]);
                index++;
            }
            long longValue;
            if (!long.TryParse(stringBuilder.ToString(), out longValue))
                return isNegative ? int.MinValue : int.MaxValue;
            int intValue;
            if (longValue > int.MaxValue)
            {
                if (isNegative)
                {
                    intValue = int.MinValue;
                }
                else
                {
                    intValue = int.MaxValue ;
                }
            }
            else
            {
                intValue = (int)longValue;
                intValue = isNegative ? -intValue : intValue;
            }
                
            return intValue;

        }

    }
}
