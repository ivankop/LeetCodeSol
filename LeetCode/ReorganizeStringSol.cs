using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ReorganizeStringSol
    {
        public string ReorganizeString(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!charCount.ContainsKey(s[i]))
                {
                    charCount[s[i]] = 0;
                }
                charCount[s[i]]++;
            }
            StringBuilder sb = new StringBuilder();
            var topChar = charCount.Where(x => x.Value == charCount.Values.Max()).FirstOrDefault().Key;
            sb.Append(topChar);
            charCount[topChar]--;

            while (sb.Length < s.Length)
            {
                char key = sb[sb.Length - 1];
               
                var nextChar = charCount.Where(x => x.Key != key && x.Value > 0).OrderByDescending(x => x.Value).FirstOrDefault();
                if (nextChar.Key != default(char))
                {
                    sb.Append(nextChar.Key);
                    charCount[nextChar.Key]--;
                    //found = true;
                    // break;
                }
                else
                {
                    return "";
                }
                /*
                bool found = false;
                for (char c = 'a'; c <= 'z';c++)
                {
                    if (c != key && charCount.ContainsKey(c) && charCount[c] > 0)
                    {
                        sb.Append(c);
                        charCount[c]--;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    return "";
                */
            }
            return sb.ToString();
        }
    }
}
