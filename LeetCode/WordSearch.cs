using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class WordSearch
    {
        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        Dictionary<Tuple<int, int>, bool> mem = new Dictionary<Tuple<int, int>, bool>();

        public bool Exist2(char[][] board, string word)
        {
            Dictionary<char, HashSet<Tuple<int, int>>> map = new Dictionary<char, HashSet<Tuple<int, int>>>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (!map.ContainsKey(board[i][j]))
                    {
                        map[board[i][j]] = new HashSet<Tuple<int, int>>();
                    }
                    map[board[i][j]].Add(new Tuple<int, int>(i, j));
                }
            }

            if (!word.All(c => map.ContainsKey(c)))
            {
                return false;
            }

            var adj = new int[4][];
            adj[0] = new int[] { -1, 0 }; // left
            adj[1] = new int[] { 1, 0 }; // right
            adj[2] = new int[] { 0, -1 }; // top
            adj[3] = new int[] { 0, 1 }; // top


            Queue<Tuple<int, int, int, HashSet<Tuple<int, int>>>> queue = new Queue<Tuple<int, int, int, HashSet<Tuple<int, int>>>>();

            foreach (var pos in map[word[0]])
            {
                Tuple<int, int, int, HashSet<Tuple<int, int>>> cell = new Tuple<int, int, int, HashSet<Tuple<int, int>>>(pos.Item1, pos.Item2, 0, new HashSet<Tuple<int, int>>());
                cell.Item4.Add(pos);
                queue.Enqueue(cell);
            }

            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int j = 0; j < size; j++)
                {
                    var cell = queue.Dequeue();

                    if (cell.Item3 == word.Length - 1)
                    {
                        return true;
                    }
                    else if (cell.Item3 > word.Length - 1)
                    {
                        continue;
                    }

                    var x = cell.Item1;
                    var y = cell.Item2;

                    for (int i = 0; i < adj.Length; i++)
                    {
                        var nextX = x + adj[i][0];
                        var nextY = y + adj[i][1];
                        Tuple<int, int> nextPos = new Tuple<int, int>(nextX, nextY);
                        if (nextX >= 0 && nextY >= 0 && nextX < board.Length && nextY < board[x].Length)
                        {
                            if (!cell.Item4.Contains(nextPos) && map[word[cell.Item3 + 1]].Contains(nextPos))
                            {
                                var nextCell = new Tuple<int, int, int, HashSet<Tuple<int, int>>>(nextPos.Item1, nextPos.Item2, cell.Item3 + 1, new HashSet<Tuple<int, int>>(cell.Item4));
                                nextCell.Item4.Add(nextPos);
                                queue.Enqueue(nextCell);
                            }
                        }
                    }
                }
                
            }


            return false;
        }

        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        var ans = Search(board, word, 0, i, j);
                        if (ans)
                            return true;
                    }
                    
                }
            }
            
            return false;
        }
        private bool Search(char[][] board, string word, int index, int x, int y)
        {
            Tuple<int, int> currentPos = new Tuple<int, int>(x, y);
            
            if (index == word.Length - 1)
            {
                return true;
            }
            if (index >= word.Length)
            {
                return false;
            }
            
            var adj = new int[4][];
            adj[0] = new int[] { -1, 0 }; // left
            adj[1] = new int[] { 1, 0 }; // right
            adj[2] = new int[] { 0, -1 }; // top
            adj[3] = new int[] { 0, 1 }; // top

            
            visited.Add(currentPos);
            
            for (int i = 0; i < adj.Length; i++)
            {
                var nextX = x + adj[i][0];
                var nextY = y + adj[i][1];
                Tuple<int, int> nextPos = new Tuple<int, int>(nextX, nextY);
                if (!visited.Contains(nextPos) && nextX >= 0 && nextY >= 0 && nextX <  board.Length && nextY < board[x].Length)
                {
                    if (board[nextX][nextY] == word[index + 1])
                    {
                        var res = Search(board, word, index + 1, nextX, nextY);
                        if (res)
                            return true;
                    }
                    
                }
            }
            visited.Remove(currentPos);
            // mem.Add(currentPos, false);
            return false;
        }
    }
}
