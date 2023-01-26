using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class PlatesBetweenCandlesSol
    {
        public int[] PlatesBetweenCandles(string s, int[][] queries)
        {
            // build map
            int[] map = new int[s.Length];
            int start = 0;
            while (start < s.Length && s[start] != '|')
            {
                start++;
            }
            int count = 0;
            while (start < s.Length)
            {
                if (s[start] == '|')
                {
                    map[start] = -1;
                }
                else
                {
                    map[start] = count;
                    count++;
                }
                start++;
            }
            int end = s.Length - 1;
            while (end >= 0 && s[end] != '|')
            {
                map[end] = -1;
                end--;
            }

            int[] ans = new int[queries.Length];
            var prefix = BuildPrefix(s);
            var subfix = BuildSubfix(s);
            for (int i = 0; i < queries.Length; i++)
            {
                ans[i] = CountPlates(map, queries[i][0], queries[i][1], prefix, subfix);
            }
            return ans;
        }

        int[] BuildPrefix(string s)
        {
            var ans = new int[s.Length];
            int start = 0;
            while (start < s.Length && s[start] != '|')
            {
                ans[start] = -1;
                start++;                
            }
            int end = start;
            while (end < s.Length)
            {
                if (s[end] == '|')
                {
                    start = end;
                }
                ans[end] = start;
                
                end++;
            }

            return ans;
        }

        int[] BuildSubfix(string s)
        {
            var ans = new int[s.Length];
            int start = s.Length - 1;
            while (start >=0 && s[start] != '|')
            {
                ans[start] = -1;
                start--;
            }
            int end = start;
            while (end >= 0)
            {
                if (s[end] == '|')
                {
                    
                    start = end;
                }
                ans[end] = start;
                end--;
            }

            return ans;
        }

        int CountPlates(int[] map, int start, int end, int[] prefix, int[] subfix)
        {
            if (subfix[start] == -1 || prefix[end] == -1)
            {
                return 0;
            }
            start = subfix[start];
            while (start < end && map[start] == -1 )
            {
                start++;
            }
            end = prefix[end];
            while (end > start && map[end] == -1)
            {
                end--;
            }
            if (start < end)
            {
                return map[end] - map[start] + 1;
            }
            if (start == end && map[end] != -1)
            {
                return 1;
            }
                
            return 0 ;
        }
    }
}
