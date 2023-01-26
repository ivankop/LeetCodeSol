using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WordPatternSol
    {
        public bool WordPattern(string pattern, string s)
        {
            var sList = s.Split(' ').ToList();
            if (sList.Count != pattern.Length)
            {
                return false;
            }
            Dictionary<char, string> map = new Dictionary<char, string>();
            for (int i = 0; i < pattern.Length; i++)
            {
                if (!map.ContainsKey(pattern[i]))
                {
                    if (map.Values.Any(v => v == sList[i]))
                    {
                        return false;
                    }
                    map.Add(pattern[i], sList[i]);
                }
                else
                {
                    if (map[pattern[i]] != sList[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
