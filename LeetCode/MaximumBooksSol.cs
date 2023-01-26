using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaximumBooksSol
    {
        Dictionary<Tuple<long, long>, long> mem;
        long[][] prefix;
        public long MaximumBooks(int[] books)
        {
            mem = new Dictionary<Tuple<long, long>, long>();
            prefix = BuildPreFix(books);
            long[] dp = new long[books.Length];
            dp[0] = books[0];
            for (int i = 1; i < dp.Length; i++)
            {
                //int tmp = GetMaxBooks(books, i);
                long tmp = books[i] + GetBookRec(books, i - 1, books[i]);
                dp[i] = Math.Max(dp[i - 1], tmp);
            }
            return dp[dp.Length - 1];
        }

        private long GetBookRec(int[] books, long index, long prevValue)
        {
            if (index < 0 || books[index] == 0 || prevValue == 0)
            {
                return 0;
            }

            Tuple<long, long> rec = new Tuple<long, long>(index, prevValue);
            if (mem.ContainsKey(rec))
            {
                return mem[rec];
            }

            if (index == 0)
            {
                return prevValue > books[index] ? books[index] : prevValue - 1;
            }

            if (books[index] < prevValue)
            {
                mem[rec] = books[index] + GetBookRec(books, index - 1, books[index]);
            }
            else
            {
                //mem[rec] = lastBook - 1  + GetBookRec(books, index - 1, lastBook - 1);
                if (prevValue == books[index + 1])
                {
                    long gap = (prevValue - 1)*(prefix[index][0] + 1) - prefix[index][1];
                    if (gap < 0)
                    {
                        return 0;
                    }
                    long nextIndex = index - prefix[index][0];
                    long nextValue = prevValue - prefix[index][0] - 1;
                    mem[rec] = gap + GetBookRec(books, nextIndex - 1, nextValue);
                }
                else
                {
                    mem[rec] = prevValue - 1 + GetBookRec(books, index - 1, prevValue - 1);
                }
                
            }

            return mem[rec];
        }

        long[][] BuildPreFix(int[] books)
        {
            long[][] ret = new long[books.Length][];
            ret[0] = new long[2];
            ret[0][0] = 0;
            ret[0][1] = 0;
            long sum = 0;
            for (long i = 1; i < books.Length; i++)
            {
                ret[i] = new long[2];
                if (books[i] <= books[i-1])
                {
                    ret[i][0] = ret[i-1][0] + 1;
                    sum += ret[i][0];
                    ret[i][1] = sum;
                }
                else
                {
                    ret[i][0] = 0;
                    sum = 0;
                }
            }
            return ret;
        }
    }
}
