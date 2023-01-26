using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WordBreakSol
    {
        Dictionary<string, bool> vistited = new Dictionary<string, bool>();
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var ans = WordBreakRec(s, wordDict.OrderByDescending( w => w.Length).ToList());
            return ans;
        }

        private bool WordBreakRec(string target, IList<string> wordDict)
        {
            if (vistited.ContainsKey(target))
            {
                return vistited[target];
            }
            List<string> startWords = new List<string>();
            List<string> endWords = new List<string>();
            foreach (var word in wordDict)
            {
                if (word == target)
                    return true;
                if (target.StartsWith(word))
                {
                    startWords.Add(word);
                }
                if (target.EndsWith(word))
                {
                    endWords.Add(word);
                }
            }

            if (startWords.Count == 0 || endWords.Count == 0)
            {
                vistited[target] = false;
                return false;
            }

            foreach (var prefix in startWords)
            {
                foreach (var subfix in endWords)
                {
                    if (prefix + subfix == target)
                    {
                        vistited[target] = true;
                        return true;
                    }
                    if (target.Length > prefix.Length + subfix.Length)
                    {
                        var tmp = WordBreakRec(target.Substring(prefix.Length, target.Length - (subfix.Length + prefix.Length)), wordDict);
                        if (tmp == true)
                        {
                            vistited[target] = true;
                            return true;
                        }
                            
                    }
                }
            }
            vistited[target] = false;
            return false;
        }

        private bool WordBreak(string target, string current, IList<string> wordDict)
        {
            if (current == target)
            {
                return true;
            }
            if (current.Length > target.Length)
            {
                return false;
            }

            foreach (var word in wordDict)
            {
                if (target.StartsWith(current + word))
                {
                    var tmp = WordBreak(target, current + word, wordDict);
                    if (tmp == true)
                        return true;
                }
            }
            return false;
        }
    }
}
