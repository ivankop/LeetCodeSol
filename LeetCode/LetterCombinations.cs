using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class LetterCombinationsSolution
    {
        public IList<string> LetterCombinations(string digits)
        {
            var res = new List<string>();
            if (string.IsNullOrEmpty(digits))
            {
                return res;
            }
            var charList = new List<string[]>();
            foreach (char c in digits.ToCharArray(0, digits.Length))
            {
                charList.Add(getNumberList(c));
            }

            if (charList.Count == 1)
            {
                return charList[0].ToList();
            }

            IEnumerable<string> mix = charList[0].SelectMany(c => charList[1], (c, a) => string.Concat(c, a));
            for (int i = 2; i < charList.Count; i++)
            {
                var index = i;
                mix = mix.SelectMany(c => charList[index], (c, a) => string.Concat(c, a));
            }
            var r = mix.ToList();
            res.AddRange(mix);

            return res;

        }

        private static Dictionary<char, string[]> d = new Dictionary<char, string[]>() {
            {'2', new string[3] {"a","b","c"}},
            {'3', new string[3] {"d","e","f"}},
            {'4', new string[3] {"g","h","i"}},
            {'5', new string[3] {"j","k","l"}},
            {'6', new string[3] {"m","n","o"}},
            {'7', new string[4] {"p","q","r","s"}},
            {'8', new string[3] {"t","u","v"}},
            {'9', new string[4] {"w","x","y","z"}}
        };
        private static string[] getNumberList(char c)
        {
            var res = new List<string>();
            int number = int.Parse(c.ToString());
            if (number < 2)
                return new string[0];

            return d[c];
        }
    }
}
