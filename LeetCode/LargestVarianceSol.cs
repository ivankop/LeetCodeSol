using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LargestVarianceSol
    {
        int max = 0;
        public int LargestVariance1(string s)
        {
            max = 0;
            for (int l = 1; l <= s.Length; l++)
            {
                // Choose ending point
                for (int i = 0; i <= s.Length - l; i++)
                {
                    // Display the substrings
                    int q = i + l - 1;
                    if (q - i > max)
                    {
                        Dictionary<char, int> charCount = new Dictionary<char, int>();
                        List<char> charList = new List<char>();
                        for (int j = i; j <= q; j++)
                        {
                            if (!charCount.ContainsKey(s[j]))
                            {
                                charCount.Add(s[j], 0);
                            }
                            charCount[s[j]]++;
                            charList.Add(s[j]);
                        }

                        var tmp = GetVariance(charCount);
                        max = Math.Max(max, tmp);
                    }
                    else
                    {
                        Console.WriteLine("skip");
                    }
                    
                }
            }
            //FindSubString(s, 0, new Dictionary<char, int>(), new List<char>());
            return max;
        }

        public int LargestVariance(string s)
        {
            max = 0;
            int skip = 0;
            for (int i = 0; i < s.Length; i++)
            {
                Dictionary<char, int> charCount = new Dictionary<char, int>();
                if (!charCount.ContainsKey(s[i]))
                {
                    charCount.Add(s[i], 1);
                }
                var minOcc = s[i];
                var maxOcc = s[i];
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (!charCount.ContainsKey(s[j]))
                    {
                        charCount.Add(s[j], 0);
                    }
                    charCount[s[j]]++;

                    if (charCount[s[j]] < charCount[minOcc])
                    {
                        minOcc = s[j];
                    }

                    if (charCount[s[j]] > charCount[maxOcc])
                    {
                        maxOcc = s[j];
                    }
                    var min = charCount.Values.Min();
                    var tmp  = charCount[maxOcc] - min;
                    max = Math.Max(max, tmp);
                    if (j - i > max)
                    {
                        // var tmp = GetVariance(charCount);
                        //max = Math.Max(max, tmp);
                    }
                    else
                    {
                        skip++;
                    }

                    
                }
            }
            //FindSubString(s, 0, new Dictionary<char, int>(), new List<char>());
            return max;
        }

        void FindSubString(string s, int index, Dictionary<char, int> charCount, List<char> list)
        {
            if (index == s.Length)
            {
                // check variance
                var tmp = GetVariance(charCount);
                max = Math.Max(max, tmp);
                return;
            }
            FindSubString(s, index + 1, new Dictionary<char, int>(charCount), new List<char>(list));
            
            if (!charCount.ContainsKey(s[index]))
            {
                charCount.Add(s[index], 0);
            }
            charCount[s[index]]++;
            list.Add(s[index]);
            FindSubString(s, index + 1, new Dictionary<char, int>(charCount), new List<char>(list));
        }

        int GetVariance(Dictionary<char, int> charCount)
        {
            if (charCount.Count == 0)
            {
                return 0;
            }
            var list = charCount.Values.OrderBy(x => x).ToList();
            return list[list.Count - 1] - list[0];   
        }
    }
}
