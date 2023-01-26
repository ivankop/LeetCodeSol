using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ValidSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {
            Dictionary<int, HashSet<int>> rowValues = new Dictionary<int, HashSet<int>>();
            Dictionary<int, HashSet<int>> colValues = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < board.Length; i++)
            {
                rowValues.Add(i, new HashSet<int>());
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (!colValues.ContainsKey(j))
                    {
                        colValues.Add(j, new HashSet<int>());
                    }
                    if (board[i][j] != '.')
                    {
                        int value = int.Parse(board[i][j].ToString());
                        if (rowValues[i].Contains(value))
                        {
                            return false;
                        }
                        if (colValues[j].Contains(value))
                        {
                            return false;
                        }
                        rowValues[i].Add(value);
                        colValues[j].Add(value);
                    }
                }
            }
            for (int i = 0; i < board.Length; i += 3)
            {
                for (int j = 0; i < board[0].Length; j += 3)
                {
                    var tmp = CheckSubBox(i, j, board);
                    if (tmp == false)
                        return false;
                }
            }
            return true;
        }

        private bool CheckSubBox(int x, int y, char[][] board)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    if (board[i][j] != '.')
                    {
                        if (set.Contains(board[i][j]))
                        {
                            return false;
                        }
                        set.Add(board[i][j]);
                    }
                }
            }
            return true;
        }
    }
}
