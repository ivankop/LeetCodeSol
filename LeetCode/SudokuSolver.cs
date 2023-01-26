using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SudokuSolver
    {
        Dictionary<int, HashSet<char>> rowValues = new Dictionary<int, HashSet<char>>();
        Dictionary<int, HashSet<char>> colValues = new Dictionary<int, HashSet<char>>();
        public void SolveSudoku(char[][] board)
        {
            rowValues = new Dictionary<int, HashSet<char>>();
            colValues = new Dictionary<int, HashSet<char>>();
            for (int i = 0; i < board.Length; i++)
            {
                rowValues.Add(i, new HashSet<char>());
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (!colValues.ContainsKey(j))
                    {
                        colValues.Add(j, new HashSet<char>());
                    }
                    if (board[i][j] != '.')
                    {
                        var value = board[i][j];
                        rowValues[i].Add(value);
                        colValues[j].Add(value);
                    }
                }
            }
            var ans = SolveSudokuRec(board, 0, 0);
            Console.WriteLine(ans);
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

        private bool SolveSudokuRec(char[][] board, int x, int y)
        {
            if (x == 8 && y > 8)
            {
                //if(CheckSubBox(x, y, board))
                    return true;
                //return false;
            }
            
            if (y > 8)
            {
                y = 0;
                x++;
            }
            if (board[x][y] != '.')
            {
                return SolveSudokuRec(board, x, y + 1);
            }
            HashSet<char> possibleValues = new HashSet<char>();
            var boxValues = GetBoxValues(board, x, y);
            for (char i = '1'; i <= '9'; i++)
            {
                if (!rowValues[x].Contains(i) && !colValues[y].Contains(i) && !boxValues.Contains(i))
                {
                    possibleValues.Add(i);
                }
            }
            foreach (var item in possibleValues)
            {
                board[x][y] = item;
                rowValues[x].Add(item);
                colValues[y].Add(item);
                var tmp = SolveSudokuRec(board, x, y + 1);
                if (tmp)
                    return true;
                board[x][y] = '.';
                rowValues[x].Remove(item);
                colValues[y].Remove(item);
            }
            return false;
        }

        private HashSet<char> GetBoxValues(char[][] board, int x, int y)
        {
            int top = 0;
            int left = 0;
            if (x >= 3 && x < 6)
            {
                top = 3;
            }
            else if (x >= 6)
            {
                top = 6;
            }

            if (y >= 3 && y < 6)
            {
                left = 3;
            }
            else if (y >= 6)
            {
                left = 6;
            }
            HashSet<char> set = new HashSet<char>();
            for (int i = top; i < top + 3; i++)
            {
                for (int j = left; j < left + 3; j++)
                {
                    if (board[i][j] != '.')
                    {
                        set.Add(board[i][j]);
                    }
                }
            }
            return set;
        }

    }
}
