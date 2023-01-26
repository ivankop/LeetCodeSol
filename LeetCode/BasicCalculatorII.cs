using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BasicCalculatorII
    {
        public int Calculate(string s)
        {
            s = s.Replace(" ", "").Trim();
            int index = 0;
            int firstNum = getNumber(s, ref index);
            int ans = firstNum;
            calculate(s, index, ref ans);
            return ans;
        }

        int getNumber(string s, ref int index)
        {
            StringBuilder sb = new StringBuilder();
            while(index <  s.Length && char.IsDigit(s[index]))
            {
                sb.Append(s[index]);
                index++;
            }
            return int.Parse(sb.ToString());
        }

        void calculate(string s, int index, ref int ans)
        {
            if (index >= s.Length)
            {
                return;
            }
            char op = s[index];
            index++;
            int number = getNumber(s, ref index);

            if (op == '*')
            {
                ans *= number;
                calculate(s, index, ref ans);
            } 
            else if (op == '/')
            {
                ans /= number;
                calculate(s, index, ref ans);
            }
            else if (op == '+')
            {
                calculate(s, index, ref number);
                ans += number;
            }
            else if (op == '-')
            {
                number = number * -1;
                calculate(s, index, ref number);
                ans += number;
            }
        }
    }
}
