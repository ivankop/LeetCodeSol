using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinAddToMakeValidSol
    {
        public int MinAddToMakeValid(string s)
        {
            Queue<int> open = new Queue<int>();
            Queue<int> close = new Queue<int>();
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    open.Enqueue(i);
                }
                else if (s[i] == ')')
                {
                    close.Enqueue(i);
                }
            }
            int count = 0;
            HashSet<int> removed = new HashSet<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    var openPos = open.Dequeue();
                    if (close.Count == 0)
                    {
                        count++;
                    }
                    else
                    {
                        removed.Add(close.Dequeue());
                    }
                }
                else if (s[i] == ')' && !removed.Contains(i))
                {
                    if (close.Count > 0 && ((open.Count > 0 && open.Peek() > i) || open.Count == 0))
                    {
                        count++;
                        close.Dequeue();
                    }
                }
            }
            return count;

        }
    }
}
