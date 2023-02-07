using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class FindWordsSol2
    {
        Dictionary<string, bool> mem;
        Dictionary<int, HashSet<char>> map ;
        HashSet<string> ans;
        int[][] direction = new int[][] {
            new int[] { 1, 0 },
            new int[] { 0, 1 },
            new int[] { -1, 0 },
            new int[] { 0, -1 }
        };
        
        // private bool Find
        public IList<string> FindWords(char[][] board, string[] words) 
        {
            mem = new Dictionary<string, bool>();
            map = new Dictionary<int, HashSet<char>>();
            ans = new HashSet<string>();
            HashSet<string> set = new HashSet<string>();
            foreach (var word in words)
            {
                set.Add(word);
                for (int i = 0; i < word.Length; i++)
                {
                    if (!map.ContainsKey(i))
                    {
                        map.Add(i, new HashSet<char>());
                    }
                    map[i].Add(word[i]);
                }
            }

            // Console.WriteLine("Built map");

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (map[0].Contains(board[i][j]))
                    {
                        FindWordsRec(board,i, j, board[i][j].ToString(), set, new HashSet<Tuple<int, int>>());
                    }
                }
            }

            return ans.ToList();
        }
        private void FindWordsRec(char[][] board, int row, int col, string word, HashSet<string> set, HashSet<Tuple<int,int>> visited)
        {
            if (set.Contains(word))
            {
                ans.Add(word);
            }
            if (ans.Count == set.Count)
            {
                return;
            }
            Tuple<int, int> pos = new Tuple<int, int>(row, col);
            visited.Add(pos);
            int index = word.Length;
            for (int i = 0; i < direction.Length && map.ContainsKey(index); i++)
            {
                int nextRow = row + direction[i][0];
                int nextCol = col + direction[i][1];
                Tuple<int, int> nextPos = new Tuple<int, int>(nextRow, nextCol);

                if (!visited.Contains(nextPos) && nextRow >= 0 && nextRow < board.Length && nextCol >= 0 && nextCol < board[0].Length)
                {
                    if(map[index].Contains(board[nextRow][nextCol]))
                    {
                        FindWordsRec(board, nextRow, nextCol, word + board[nextRow][nextCol], set, new HashSet<Tuple<int, int>>(visited));
                    }
                }
            }
        }        
    }
}


