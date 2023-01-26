using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ValidWordAbbreviationSol
    {
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            int wordIndex = 0;
            int abbrIndex = 0;
            while(wordIndex < word.Length && abbrIndex < abbr.Length)
            {
                if(!char.IsDigit(abbr[abbrIndex]))
                {
                    if (word[wordIndex] != abbr[abbrIndex])
                    {
                        return false;
                    }
                    wordIndex++;
                    abbrIndex++;
                }
                else
                {
                    StringBuilder numberStr = new StringBuilder();
                    
                    while (abbrIndex < abbr.Length && char.IsDigit(abbr[abbrIndex]))
                    {
                        numberStr.Append(abbr[abbrIndex]);
                        abbrIndex++;
                    }
                    var tmpStr= numberStr.ToString();
                    if (tmpStr.StartsWith("0"))
                    {
                        return false;
                    }
                    wordIndex += int.Parse(tmpStr);
                }
            }

            return true;
        }
    }
}
