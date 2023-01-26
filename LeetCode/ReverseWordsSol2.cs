using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class ReverseWordsSol2
    {
        public void ReverseWords(char[] s)
        {
            List<char> res = new List<char>();
            List<char> word = new List<char>();
            for (int i = 0; i <= s.Length; i++)
            {
                if (i == s.Length || s[i] == ' ') 
                {
                    // insert to resutl list
                    for (int j = word.Count - 1; j >= 0; j--)
                    {
                        res.Insert(0, word[j]);
                    }
                    if (i != s.Length )
                    {
                        res.Insert(0, ' ');
                    }
                    
                    word.Clear();// append to word                    
                }
                else
                {
                    word.Add(s[i]);
                }
            }

            for (int i = 0; i < res.Count; i++)
            {
                s[i] = res[i];
            }
        }
    }
}
