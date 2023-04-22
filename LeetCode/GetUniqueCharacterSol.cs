using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class GetUniqueCharacterSol
    {
        public static int getUniqueCharacter(string s)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!charCount.ContainsKey(s[i]))
                {
                    charCount.Add(s[i], 0);
                }
                charCount[s[i]]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (charCount[s[i]] == 1) // unique character
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}
