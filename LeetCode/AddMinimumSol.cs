using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AddMinimumSol
    {
        public int AddMinimum(string word)
        {
            int count = 0;
            Stack<char> stack = new Stack<char>();

            if (word[word.Length - 1] != 'c')
            {
                stack.Push('c');
                count++;
            }

            for (int i = word.Length - 1; i >= 0; i--)
            {
                stack.Push(word[i]);
            }

            if (word[0] != 'a')
            {
                stack.Push('a');
                count++;
            }
            
            while (stack.Count > 0)
            {
                var c = stack.Pop();
                if (c == 'a' && (stack.Count == 0 || stack.Peek() != 'b'))
                {
                    stack.Push('b');
                    count++;
                }
                else if (c == 'b' && (stack.Count == 0 || stack.Peek() != 'c'))
                {
                    stack.Push('c');
                    count++;
                }
                else if (c == 'c' && stack.Count > 0 && stack.Peek() != 'a')
                {
                    stack.Push('a');
                    count++;
                }
            }
            return count;
        }
    }
}
