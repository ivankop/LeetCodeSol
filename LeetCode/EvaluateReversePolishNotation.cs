using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class EvaluateReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack= new Stack<int>();
            HashSet<string> operators = new HashSet<string>(new string[] { "+", "-", "*", "/" });
            int ans = 0;
            foreach (string token in tokens)
            {
                if (!operators.Contains(token))
                {
                    stack.Push(int.Parse(token));
                }
                else
                {
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
                    if (token == "+")
                    {
                        ans = num1 + num2;
                    }
                    else if(token == "-")
                    {
                        ans = num2 - num1;
                    }
                    else if (token == "*")
                    {
                        ans = num2 * num1;
                    }
                    else if (token == "/")
                    {
                        ans = num2 / num1;
                    }
                    stack.Push(ans);
                }
            }

            return ans;
        }
    }
}
