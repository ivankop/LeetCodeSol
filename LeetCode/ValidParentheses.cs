using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ValidParentheses
    {
        public bool IsValid(string s)
        {
            Dictionary<char, char> parens = new Dictionary<char, char>();
            parens.Add(')', '(');
            parens.Add(']', '[');
            parens.Add('}', '{');
            // ([{}])
            Stack<char> stack = new Stack<char>();
            
            for (int i = 0; i < s.Length; i++)
            {
                if (parens.ContainsKey(s[i]))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    var openParen = stack.Pop();
                    if (openParen != parens[s[i]])
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            if (stack.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
