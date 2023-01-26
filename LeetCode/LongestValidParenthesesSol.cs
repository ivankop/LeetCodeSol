using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LongestValidParenthesesSol
    {
        public int LongestValidParentheses1(string s)
        {
            SortedList<int, int> result = new SortedList<int, int>();
            int ans = 0;
            int count = 0;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count > 0 && stack.Peek() == '(')
                    {
                        stack.Pop();
                        count += 2;
                    }
                    else
                    {
                        ans = Math.Max(ans, count);
                        count = 0;
                    }
                }
            }
            ans = Math.Max(ans, count);
            return ans;
        }

        public int LongestValidParentheses(string s)
        {
            int ans = 0;
            int count = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        count += 2;
                    }
                    else
                    {
                        ans = Math.Max(ans, count);
                        count = 0;
                    }
                }
            }
            ans = Math.Max(ans, count);

            if (stack.Count > 0)
            {
                // find substrings
                List<string> subStrings = new List<string>();
                int index = stack.Pop();
                var subString1 = s.Substring(0, index);
                var subString2 = s.Substring(index + 1, s.Length - index - 1);
                var len1 = LongestValidParentheses(subString1);
                var len2 = LongestValidParentheses(subString2);
                ans = Math.Max(len2, len1);  
            }
            return ans;
        }
    }
}
