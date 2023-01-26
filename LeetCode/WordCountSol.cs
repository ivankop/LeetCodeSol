using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WordCountSol
    {
        Dictionary<string, int> wordHash = new Dictionary<string, int>();
        public int WordCount(string[] startWords, string[] targetWords)
        {
            int count = 0;
            // HashSet<string> checkedTarget = new HashSet<string>();
            foreach (var target in targetWords)
            {
                int targetHash = GetWordHashCode(target, target.Length - 1);
                foreach (var word in startWords)
                {
                    if (word.Length + 1 == target .Length && IsConverable(word, targetHash))
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        private bool IsConverable(string input, int targetHash)
        {
            if (!wordHash.ContainsKey(input))
            {
                wordHash[input] = GetWordHashCode(input);
            }
            
            if(wordHash[input] != targetHash)
                return false;
            
            return true;
        }

        private int GetWordHashCode(string input)
        {
            var tmp = new string(input.OrderBy(x => x).ToArray());
            return tmp.GetHashCode();
        }

        private int GetWordHashCode(string input, int length)
        {
            var tmp = new string(input.OrderBy(x => x).Take(length).ToArray());
            return tmp.GetHashCode();
        }
    }
}
