using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class CloseStringsSol
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }
            Dictionary<char, int> wordCount1 = new Dictionary<char, int>();
            Dictionary<char, int> wordCount2 = new Dictionary<char, int>();
            for (int i = 0; i < word1.Length; i++)
            {
                if (!wordCount1.ContainsKey(word1[i]))
                {
                    wordCount1.Add(word1[i], 0);
                }
                wordCount1[word1[i]]++;
                if (!wordCount2.ContainsKey(word2[i]))
                {
                    wordCount2.Add(word2[i], 0);
                }
                wordCount2[word2[i]]++;
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                if (!wordCount1.ContainsKey(c) && !wordCount2.ContainsKey(c))
                {
                    continue;
                }
                if (!wordCount1.ContainsKey(c) && wordCount2.ContainsKey(c))
                {
                    return false;
                }
                if (wordCount1.ContainsKey(c) && !wordCount2.ContainsKey(c))
                {
                    return false;
                }
                /*
               if (wordCount1[c] != wordCount2[c])
               {
                   return false;
               }
               */
            }
            var count1 = wordCount1.Values.OrderBy(x => x).ToList();
            var count2 = wordCount2.Values.OrderBy(x => x).ToList();
            return count1.SequenceEqual(count2);
            // return true;
        }
    }
}
