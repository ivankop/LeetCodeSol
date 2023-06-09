using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FreqStack
    {
        List<int> list;
        Dictionary<int, int> freq;
        LinkedList<int> stack;
        public FreqStack()
        {
            list = new List<int>();
            freq = new Dictionary<int, int>();
        }

        public void Push(int val)
        {
            if (!freq.ContainsKey(val))
            {
                freq.Add(val, 0);
            }
            freq[val]++;
            list.Add(val);
        }

        public int Pop()
        {
            // sort by freq value
            var mostFreq = freq.OrderByDescending(kv => kv.Value).Select(kv => kv.Value).FirstOrDefault();
            int popValue = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (freq[list[i]] == mostFreq)
                {
                    popValue = list[i];
                    freq[list[i]]--;
                    if (freq[list[i]] == 0)
                    {
                        freq.Remove(list[i]);
                    }
                    list.RemoveAt(i);
                    return popValue;
                }
            }
            return popValue;
        }
    }
}
