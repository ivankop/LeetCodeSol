using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SummaryRanges
    {
        SortedDictionary<int, Number> dict;
        public SummaryRanges()
        {
            dict = new SortedDictionary<int, Number>();
        }

        public void AddNum(int value)
        {
            if (dict.ContainsKey(value))
            {
                return;
            }

            Number number = new Number(value);
            dict.Add(value, number);
            if (dict.ContainsKey(value + 1))
            {
                number.Next = dict[value + 1];
            }
            
            if (dict.ContainsKey(value - 1))
            {
                dict[value - 1].Next = number;
            }
        }

        public int[][] GetIntervals()
        {
            List<int[]> ans = new List<int[]>();
            HashSet<int> visited = new HashSet<int>();
            foreach (var kv in dict)
            {
                if (!visited.Contains(kv.Key))
                {
                    List<int> list = new List<int>();
                    list.Add(kv.Key);
                    int last = kv.Key;
                    var next = kv.Value.Next;
                    while (next != null)
                    {
                        visited.Add(next.Value);
                        last = next.Value;
                        next = next.Next;
                    }
                    list.Add(last);
                    ans.Add(list.ToArray());
                }
            }
            return ans.ToArray();
        }
    }

    class Number
    {
        public Number(int value, Number next = null, Number previous = null)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }

        public int Value { get; set; }
        public Number Next { get; set; }
        public Number Previous { get; set; }

    }
}
