using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class MinHeightShelvesSol
    {
        // int minHeight = int.MaxValue;
        Dictionary<Tuple<int,int, int>, int> mem = new Dictionary<Tuple<int,int,int>, int>();
        public int MinHeightShelves(int[][] books, int shelfWidth)
        {
            mem = new Dictionary<Tuple<int, int, int>, int>();
            var ans = DFS(books, shelfWidth, 0, shelfWidth, 0);
            return ans;
        }
        private int DFS(int[][] books, int shelfWidth, int index, int remainWidth, int currentHeight)
        {
            Tuple<int, int, int> tuple = new Tuple<int, int, int>(index, remainWidth, currentHeight);
            if (mem.ContainsKey(tuple))
            {
                return mem[tuple];
            }
            
            if (index == books.Length)
            {
                return currentHeight;
            }

            
            int minHeight = int.MaxValue;

            if (books[index][0] <= remainWidth)
            {
                var newHeight = Math.Max(currentHeight, books[index][1]);
                remainWidth = remainWidth - books[index][0];
                minHeight = DFS(books, shelfWidth, index + 1, remainWidth, newHeight);
            }

            var tmpHeight = DFS(books, shelfWidth, index + 1, shelfWidth - books[index][0], books[index][1]) + currentHeight;
            minHeight = Math.Min(minHeight, tmpHeight);

            mem.Add(tuple, minHeight);
            return minHeight;
        }


    }
}
