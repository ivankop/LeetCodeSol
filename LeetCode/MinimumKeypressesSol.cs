using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinimumKeypressesSol
    {
        public int MinimumKeypresses(string s)
        {
            int count = 0;
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charCount.ContainsKey(c))
                {
                    charCount.Add(c, 0);
                }
                charCount[c]++;
            }
            List<char> list = charCount.OrderByDescending(kv => kv.Value).Select(kv => kv.Key).ToList();
            // int level = 0;
            for (int i = 0; i < list.Count; i++)
            {
                charCount[list[i]] = i / 9 + 1;
            }

            foreach (var c in s)
            {
                count += charCount[c];
            }

            return count;
         }
    }
}
