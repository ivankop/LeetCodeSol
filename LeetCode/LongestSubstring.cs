using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            int tmpLength = 1;
            int max = 0;
            string tmpStr = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if(!tmpStr.Contains(s[i]))
                {
                    tmpStr = string.Concat(tmpStr, s[i]);
                    tmpLength++;
                }
                else
                {
                    tmpStr = s[i].ToString();
                    if (tmpLength > max)
                    {
                        max = tmpLength;
                    }
                    tmpLength = 1;
                }
            }
            return max;
        }

        private int findSubString(string s)
        {
            string output = string.Empty;
            int i = 0;
            while (!output.Contains(s[i]) && i < s.Length)
            {
                i++;
                output = string.Concat(output,s[i]);
            }
            return output.Length;
        }
    }
}
