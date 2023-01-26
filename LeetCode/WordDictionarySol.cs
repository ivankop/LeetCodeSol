using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WordDictionary
    {
        Dictionary<string, string> dict;
        Dictionary<int, List<char[]>> wordDict;
        public WordDictionary()
        {
            dict = new Dictionary<string, string>();
            wordDict = new Dictionary<int, List<char[]>>();
        }

        public void AddWord(string word)
        {
            dict[word] = word;
            if (!wordDict.ContainsKey(word.Length))
            {
                wordDict.Add(word.Length, new List<char[]>());
            }
            wordDict[word.Length].Add(word.ToArray());
        }

        public bool Search(string word)
        {
            if (!wordDict.ContainsKey(word.Length))
            {
                return false;
            }
            var listWord = wordDict[word.Length];
            var inputArr= word.ToCharArray();
            
            foreach (var item in listWord)
            {
                var tmp = DFS(inputArr, item);
                if (tmp == true)
                    return true;
            }
            return false;
        }

        private bool DFS(char[] input, char[] arr)
        {
            int index = 0;

            while (index < input.Length)
            {
                if (input[index] == '.')
                {
                    index++;
                }
                else
                {
                    if (input[index] != arr[index])
                    {
                        return false;
                    }
                    index++;
                }
            }
            return true;
        }

        private bool SearchRec(string word)
        {
            if (dict.ContainsKey(word))
            {
                return true;
            }

            int dotIndex = word.IndexOf('.');
            var charArr = word.ToCharArray();
            for (char c = 'a'; c <= 'z'; c++)
            {
                charArr[dotIndex] = c;
                var tmpWord  = new string(charArr);
                var tmp = SearchRec(tmpWord);
                if (tmp == true)
                {
                    if (!dict.ContainsKey(tmpWord))
                    {
                        dict.Add(tmpWord, tmpWord);
                    }
                    return true;
                }
                   
                charArr[dotIndex] = word[dotIndex];
            }
            return false;
        }
    }
}
