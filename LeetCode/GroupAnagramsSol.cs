using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class GroupAnagramsSol
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
            foreach (string str in strs)
            {
                var key = new string(str.OrderBy(x => x).ToArray());
                if (!groups.ContainsKey(key))
                {
                    List<string> group = new List<string>();
                    groups.Add(key, group);
                }
                groups[key].Add(str);
            }
            var res = groups.Values.ToList();

            return res;
        }
    }
}
