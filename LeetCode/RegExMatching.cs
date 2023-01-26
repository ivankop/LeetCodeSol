using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RegExMatching
    {
        bool IsMatchRec(string input, int index, List<string> patterns, int currentPattern)
        {
            if (index == input.Length)
            {
                if (currentPattern == patterns.Count)
                {
                    return true;
                }
                else
                {
                    for (int i = currentPattern; i < patterns.Count; i++)
                    {
                        if (patterns[i].Length == 1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            if (currentPattern == patterns.Count)
            {
                return false;
            }

            var p = patterns[currentPattern];
            if (p == ".")
            {
                return IsMatchRec(input, index + 1, patterns, currentPattern + 1);
            }
            if (p == ".*")
            {
                for (int i = index; i <= input.Length; i++)
                {
                    var tmpRes = IsMatchRec(input, i, patterns, currentPattern + 1);
                    if (tmpRes)
                        return true;
                }
                return false;
            }
            if (p == input[index].ToString())
            {
                return IsMatchRec(input, index + 1, patterns, currentPattern + 1);
            }
            if (p.Length == 2 && p[1] == '*')
            {
                if (input[index] == p[0])
                {
                    while (index < input.Length && input[index] == p[0])
                    {
                        var tmp = IsMatchRec(input, index, patterns, currentPattern + 1);
                        if (tmp == true)
                        {
                            return true;
                        }
                        index++;
                    }
                    return IsMatchRec(input, index, patterns, currentPattern + 1);
                }
                else
                {
                    return IsMatchRec(input, index, patterns, currentPattern + 1);
                }
            }
            return false;
        }
        public bool IsMatch(string s, string p)
        {
            List<string> patterns = new List<string>();
            for (int i = 0; i < p.Length; i++)
            {
                if (i < p.Length - 1 && p[i + 1] == '*')
                {
                    patterns.Add(p.Substring(i, 2));
                    i++;
                }
                else
                {
                    patterns.Add(p.Substring(i, 1));
                }
            }
            var ans = IsMatchRec(s, 0, patterns, 0);
            return ans;
        }

    }
}
