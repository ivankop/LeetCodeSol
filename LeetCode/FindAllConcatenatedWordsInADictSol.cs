using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindAllConcatenatedWordsInADictSol
    {
        public IList<string> FindAllConcatenatedWordsInADict2(string[] words)
        {
            var res = new List<string>();
            var listWords = words.ToList();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (i != j && words[j].Length < words[i].Length && words[i].StartsWith(words[j]))
                    {
                        var tmpList = words.Where(w => words[i].Contains(w)).ToList();
                        if (FindConcatenatedWords(words[i], words[j], tmpList) && !res.Contains(words[i]))
                        {
                            res.Add(words[i]);
                        }
                    }
                }
            }

            return res;
        }

        private bool FindConcatenatedWords(string target, string input, List<string> words)
        {
            if (!target.StartsWith(input))
            {
                return false;
            }
            if (target == input)
            {
                return true;
            }
            else
            {
                foreach (var item in words)
                {
                    if (target.Contains(item))
                    {
                        var tmpStr = input + item;
                        var tmpList = words.Where(w => w.Length <= target.Length - tmpStr.Length).ToList();
                        if (tmpStr.Length <= target.Length && FindConcatenatedWords(target, tmpStr, tmpList))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        HashSet<string> ans = new HashSet<string>();
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < words.Length; i++)
            {
                set.Add(words[i]);
            }
            for (int i = 0; i < words.Length; i++)
            {
                FindWordRec(words, 0, "", set, words[i], 0);
            }
            
            return ans.ToList();
        }
        private void FindWordRec(string[] words, int index, string concatStr, HashSet<string> set, string target, int count)
        {
            if (concatStr == target && count > 1)
            {
                ans.Add(target);
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
                    FindWordRec(words, i, concatStr + subString, set, target, count + 1);
                }
            }

        }

    }
}
