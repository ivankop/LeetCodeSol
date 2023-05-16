using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindSecretWordSol
    {
        public void FindSecretWord(string[] words, Master master)
        {

            var wordSet = new List<string>(words);
            Random random = new Random();
            // wordSet = SortByScore(wordSet);
            while (wordSet.Count > 0)
            {
                var guess = wordSet[random.Next(wordSet.Count)];
                var match = master.Guess(guess);
                if (match != 6)
                {
                    wordSet = Filter(match, guess, wordSet);
                }
                else
                {
                    return;
                }
            }
        }

        List<string> Filter(int match, string word, List<string> words)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < words.Count; i++)
            {
                //if (words[i] != word)
                {
                    var score = GetScore(word, words[i]);
                    if (score == match)
                    {
                        result.Add(words[i]);
                    }
                }
            }
            // result = SortByScore(result);
            return result;
        }

        List<string> SortByScore(List<string> words)
        {
            Dictionary<string, int> wordScore = new Dictionary<string, int>();
            wordScore.Add(words[0], 0);
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    var score = GetScore(words[i], words[j]);
                    if (!wordScore.ContainsKey(words[i]))
                    {
                        wordScore.Add(words[i], 0);
                    }
                    if (!wordScore.ContainsKey(words[j]))
                    {
                        wordScore.Add(words[j], 0);
                    }
                    wordScore[words[i]] += score;
                    wordScore[words[j]] += score;
                }
            }

            var wordList = wordScore.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).ToList();
            return wordList;

        }
        int GetScore(string word, string target)
        {
            int score = 0;
            //Console.WriteLine($"{word}-{target}");
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == target[i])
                {
                    score++;
                }
            }
            return score;
        }

        public class Master
        {
            public int Guess(string word)
            {
                return 0;
            }
        }
    }
}
