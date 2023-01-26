using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class AutocompleteSystem
    {
        SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
        public AutocompleteSystem(string[] sentences, int[] times)
        {
            for (int i = 0; i < sentences.Length; i++)
            {
                dict.Add(sentences[i], times[i]);
            }
        }
        string currentSentence = string.Empty;
        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                if (!dict.ContainsKey(currentSentence))
                {
                    dict.Add(currentSentence, 0);
                }
                dict[currentSentence]++;
                currentSentence = string.Empty;
                return new List<string>();
            }
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>> ();
            bool found = false;
            currentSentence += c;
            foreach (KeyValuePair<string, int> pair in dict)
            {
                if (pair.Key.StartsWith(currentSentence))
                {
                    list.Add(pair);
                    found = true;
                }
                else
                {
                    if (found == true)
                    {
                        break;
                    }
                }
            }
            var sortedList = list.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).Take(3).ToList();
            return sortedList;
        }
    }
}
