using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class MinRemoveToMakeValidSol
    {
        public string MinRemoveToMakeValid(string s)
        {
            StringBuilder res = new StringBuilder(s);
            List<int> openParen = new List<int>();
            List<int> closeParen = new List<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    openParen.Add(i);
                }
                else if (s[i] == ')')
                {
                    closeParen.Add(i);
                }
            }
            
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    // find close paren
                    if (closeParen.Count == 0 || closeParen[0] < i)
                    {
                        res[i] = '?';
                        openParen.RemoveAt(0);
                    }
                    else
                    {
                        closeParen.RemoveAt(0);
                    }
                }
                else if (s[i] == ')')
                {
                    // find open paren
                    if (openParen.Count == 0 || openParen[0] > i)
                    {
                        res[i] = '?';
                        closeParen.RemoveAt(0);
                    }
                    else
                    {
                        openParen.RemoveAt(0);
                    }
                }
            }
            res.Replace("?", "");

            return res.ToString();
        }
    }
}
