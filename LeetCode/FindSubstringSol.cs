using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindSubstringSol
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            int length = words[0].Length;
            List<int> result = new List<int>();
            List<string> set = new List<string>(words);
            for (int i = 0; i <= s.Length - length * words.Length; i++)
            {
                var subString = s.Substring(i, length * words.Length);
                if (FindSubstringRec(subString, new List<string>(set), length))
                    result.Add(i);
            }
            
            return result;
        }

        public bool FindSubstringRec(string subString, List<string> set, int length)
        {
            if (subString.Length != set.Count * length)
            {
                return false;
            }
            if (set.Count == 1 && set.Contains(subString))
            {
                return true;
            }
            var str = subString.Substring(0, length);
            var match = set.FirstOrDefault(w => w.Equals(str));
            if (match != null)
            {
                set.Remove(match);
                return FindSubstringRec(subString.Substring(length), set, length);
            }
            return false;
        }

    }
}
