using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class GroupStringsSol
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            Dictionary<string, IList<string>> groupStrings = new Dictionary<string, IList<string>>();
            foreach (string s in strings)
            {
                var pattern = GetPattern(s);
                if(!groupStrings.ContainsKey(pattern))
                {
                    var list = new List<string>();
                    list.Add(s);
                    groupStrings.Add(pattern, list);
                }
                else
                {
                    groupStrings[pattern].Add(s);
                }
            }
            var res = groupStrings.Values.ToList();
            return res;
        }

        private string GetPattern(string input)
        {
            if (input.Length == 0)
            {
                return "";
            }

            if (input.Length == 1)
            {
                return ",";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < input.Length; i++)
            {
                var gap = input[i] - input[i - 1];
                if (gap < 0)
                    gap += 26;
                sb.Append(gap);
                sb.Append(",");
            }
            return sb.ToString();
        }

    }
}
