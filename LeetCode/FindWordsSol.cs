using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindWordsSol
    {
        Dictionary<string, bool> mem;
        int[][] direction = new int[][] {
            new int[] { 1, 0 },
            new int[] { 0, 1 },
            new int[] { -1, 0 },
            new int[] { 0, -1 }
        };
        public bool FindWordsBFS(char[][] board,int row, int col, string word) 
        {
            Queue<Word> queue = new Queue<Word>();
            Word firstWord = new Word(word, word.ToList(), new Tuple<int, int>(row, col), new HashSet<Tuple<int, int>>());
            queue.Enqueue(firstWord);
                            
            //HashSet<string> ans = new HashSet<string>();
            while (queue.Count > 0)
            {
                int c = queue.Count;
                for (int q = 0; q < c; q++)
                {
                    var pos = queue.Dequeue();
                    if (pos.CharList.Count == 1)
                    {
                        return true;
                        //ans.Add(pos.Value);
                    }
                    else
                    {
                        pos.CharList.RemoveAt(0);
                        pos.Visited.Add(pos.Pos);
                        for (int i = 0; i < direction.Length; i++)
                        {
                            int nextRow = pos.Pos.Item1 + direction[i][0];
                            int nextCol = pos.Pos.Item2 + direction[i][1];
                            Tuple<int, int> nextPos = new Tuple<int, int>(nextRow, nextCol);

                            if (!pos.Visited.Contains(nextPos) && nextRow >= 0 && nextRow < board.Length && nextCol >= 0 && nextCol < board[0].Length)
                            {
                                if (board[nextRow][nextCol] == pos.CharList[0])
                                {
                                    //visited.Add(nextPos);
                                    Word w = new Word(pos.Value, new List<char>(pos.CharList), nextPos, new HashSet<Tuple<int, int>>(pos.Visited));
                                    queue.Enqueue(w);
                                    //visited.Remove(nextPos);
                                }
                                    
                            }
                        }
                    }
                }
            }
            return false;
        }

        // private bool Find
        public IList<string> FindWords(char[][] board, string[] words) 
        {
            mem = new Dictionary<string, bool>();
            HashSet<string> ans = new HashSet<string>();
            
                /* if(mem.ContainsKey(words[k]) && mem[words[k]] == true)
                {
                    ans.Add(words[k]);
                    continue;
                } */
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    for (int k = 0; k < words.Length; k++)
                    {
                        if (words[k][0] == board[i][j])
                        {
                            if (!ans.Contains(words[k]))
                            {
                                // var tmp = FindWordsRec(board,i, j, words[k].ToList(), new HashSet<Tuple<int, int>>());
                                var tmp = FindWordsBFS(board, i, j, words[k]);
                                if(tmp)
                                {
                                    ans.Add(words[k]);
                                }
                            }
                        }
                    }
                }
            }

            return ans.ToList();
        }
        private bool FindWordsRec(char[][] board, int row, int col, List<char> chars, HashSet<Tuple<int,int>> visited)
        {
            if (chars.Count == 1)
            {
                if (board[row][col] == chars[0])
                {
                    return true;
                }
                return false;
            }
            
            var key = new string(chars.ToArray()); // GenKey(chars, row, col);
            if (mem.ContainsKey(key))
            {
                // return mem[key];
            }
            bool found = false;
            Tuple<int, int> pos = new Tuple<int, int>(row, col);
            visited.Add(pos);
            var nextChars = new List<char>(chars);
            nextChars.RemoveAt(0);
            for (int i = 0; i < direction.Length; i++)
            {
                int nextRow = row + direction[i][0];
                int nextCol = col + direction[i][1];
                Tuple<int, int> nextPos = new Tuple<int, int>(nextRow, nextCol);

                if (!visited.Contains(nextPos) && nextRow >= 0 && nextRow < board.Length && nextCol >= 0 && nextCol < board[0].Length)
                {
                    if (board[nextRow][nextCol] == nextChars[0])
                    {
                        //visited.Add(nextPos);
                        found = FindWordsRec(board, nextRow, nextCol, new List<char>(nextChars), new HashSet<Tuple<int, int>>(visited));
                        if (found)
                            break;
                        //visited.Remove(nextPos);
                    }
                        
                }
            }
            mem[key] = found;
            return found;
        }
        private string GenKey(List<char> chars, int row, int col)
        {
            string str = new string(chars.ToArray());
            return $"{str}-{row}-{col}";
        }

        class Word 
        {
            public Word(string value, List<char> charList, Tuple<int, int> pos, HashSet<Tuple<int, int>> visited)
            {
                Value = value;
                CharList = charList;
                Pos = pos;
                Visited = visited;
            }

            public string Value {get; set;}
            public List<char> CharList {get; set;}
            public Tuple<int, int> Pos {get; set;}
            public HashSet<Tuple<int, int>> Visited {get; set;}
        }
    }
}


