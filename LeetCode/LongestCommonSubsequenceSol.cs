using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LongestCommonSubsequenceSol
    {
        Dictionary<Tuple<string, string>, int> mem;
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int count = 0;
            mem = new Dictionary<Tuple<string, string>, int>();
            count = LongestCommonSubsequenceRec(text1, text2, 0, 0);
            return count;
        }
        int LongestCommonSubsequenceRec (string text1, string text2, int index1, int index2)
        {
            Tuple<string, string> rec = new Tuple<string, string>(text1, text2);
            if (mem.ContainsKey(rec))
            {
                return mem[rec];
            }
            if (index1 >= text1.Length || index2 >= text2.Length)
            {
                return 0;
            }
            int count = 0;
            for (char c = 'a'; c <= 'z'; c++)
            {
                var tmp1 = text1.IndexOf(c, index1);
                var tmp2 = text2.IndexOf(c, index2);
                if (tmp1 > -1 && tmp2 > -1)
                {
                    var subStr1 = text1.Substring(tmp1 + 1, text1.Length - tmp1 - 1);
                    var subStr2 = text2.Substring(tmp2 + 1, text2.Length - tmp2 - 1);
                    var tmpCount = 1 + LongestCommonSubsequenceRec(subStr1, subStr2, 0, 0);
                    count = Math.Max(count, tmpCount);
                }
            }
            mem[rec] = count;
            return count;
        }

    }
}
