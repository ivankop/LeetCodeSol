using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class CustomSortStringSol
    {
        public string CustomSortString(string order, string s)
        {
            SortedDictionary<int, Tuple<char, int>> charInOrder = new SortedDictionary<int, Tuple<char, int>>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                var index = order.IndexOf(c);
                if (index > -1)
                {
                    if (!charInOrder.ContainsKey(index))
                    {
                        Tuple<char, int> tuple = new Tuple<char, int>(c, 1);
                        charInOrder.Add(index, tuple);
                    }
                    else
                    {
                        charInOrder[index]= new Tuple<char, int>(c, charInOrder[index].Item2 + 1);
                    }
                    
                }
                else
                {
                    sb.Append(c);
                }
            }

            foreach (var item in charInOrder)
            {
                for (int i = 0; i < item.Value.Item2; i++)
                {
                    sb.Append(item.Value.Item1);
                }
                
            }
            return sb.ToString();
        }
    }
}
