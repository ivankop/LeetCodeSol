using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WordBreakII
    {
        List<IList<string>> words = new List<IList<string>>();
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> set = new HashSet<string>(wordDict);
            FindWordRec(0, "", set, s, new List<string>());
            List<string> ans = new List<string>();
            foreach (var word in words)
            {
                var str= string.Join(" ", word);
                ans.Add(str);
            }
            return ans;
        }

        private void FindWordRec(int index, string concatStr, HashSet<string> set, string target, IList<string> subset)
        {
            if (concatStr == target)
            {
                words.Add(subset);
                return;
            }
            if (index >= target.Length)
            {
                return;
            }

            for (int i = index + 1; i <= target.Length; i++)
            {
                var subString = target.Substring(index, i - index);
                if (set.Contains(subString))
                {
                    var newSubset = new List<string>(subset);
                    newSubset.Add(subString);
                    FindWordRec(i, concatStr + subString, set, target, newSubset);
                }
            }

        }
    }
}
