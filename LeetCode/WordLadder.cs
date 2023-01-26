using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WordLadder
    {
        Dictionary<string, bool> visited = new Dictionary<string, bool>();
        Dictionary<string, int> mem = new Dictionary<string, int>();
        int shortedSeq = 6000;
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if(!wordList.Contains(endWord))
                return 0;
            //int maxseq = -1;
            //dfs(beginWord, endWord, 1, wordList, ref maxseq);
            bfs(beginWord, endWord, wordList);
            return shortedSeq != 6000 ? shortedSeq : 0;
        }        

        private void bfs(string beginWord, string endWord, IList<string> wordList)
        {
            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(beginWord, 1));
            HashSet<string> set = new HashSet<string>();
            foreach (var item in wordList)
            {
                //GetPattern(item);
                set.Add(item);
            }
            Console.WriteLine("GetPattern ");
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    var word = node.Item1;
                    if (word == endWord)
                    {
                        shortedSeq = node.Item2;
                        break;
                    }
                    visited[word] = true;
                    char[] chars = word.ToCharArray();
                    
                    for(int j = 0; j < word.Length; j++)
                    {
                        for (char k = 'a'; k <= 'z'; k++)
                        {
                            chars[j] = k;
                            var str = new string(chars);
                            if (set.Contains(str))
                            {
                                queue.Enqueue(new Tuple<string, int>(str, node.Item2 + 1));
                                set.Remove(str);
                            }

                        }
                        chars[j] = word[j];
                    }
                }
                
            }
        }

    }
}
