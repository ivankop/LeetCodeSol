using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LongestStrChainSol
    {
        public int LongestStrChain(string[] words)
        {
            Dictionary<int, int> mem = new Dictionary<int, int>();
            words = words.OrderByDescending(w => w.Length).ToArray();
            // int[] dp = new int[words.Length];
            // dp[0] = 1;
            string prevWord = words[0];
            int count = countPredecessor(prevWord, 1, words, mem);
            for (int i = 1; i < words.Length; i++)
            {
                var tmp = countPredecessor(words[i], i + 1, words, mem);
                if (tmp > count)
                {
                    count = tmp;
                }
            }

            return count + 1;
        }

        //public int LongestStrChain2(string[] words)
        //{
        //    words= words.OrderByDescending( w => w.Length).ToArray();
        //    int[] dp = new int[words.Length];
        //    dp[0] = 1;
        //    string prevWord = words[0];
        //    var count = countPredecessor(prevWord, 1, words);
        //    for (int i = 1; i < words.Length; i++)
        //    {
        //        if (!isPredecessor(prevWord, words[i]))
        //        {
        //            dp[i] = dp[i - 1];
        //        }
        //        else
        //        {
        //            dp[i] = dp[i-1] + 1;
        //            prevWord = words[i];
        //        }
        //    }

        //    return dp[words.Length-1];
        //}

        private int countPredecessor(string word, int index, string[] words, Dictionary<int, int> mem)
        {
            if (mem.ContainsKey(index))
            {
                return mem[index];
            }
            if (index >= words.Length)
            {
                return 0;
            }

            int maxCount = 0;

            for (int i = index; i < words.Length; i++)
            {
                if (isPredecessor(word, words[i]))
                {
                    // count this word
                    var tmp = countPredecessor(words[i], i + 1, words, mem) + 1;
                    if (tmp > maxCount)
                    {
                        maxCount = tmp;
                    }
                }
            }
            mem[index] = maxCount;
            return maxCount;
        }

        private bool isPredecessor(string word2, string word1)
        {
            if (word1.Length == word2.Length || word2.Length != word1.Length + 1)
                return false;
            for (int i = 0; i < word2.Length; i++)
            {
                if (word2.Remove(i,1) == word1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
