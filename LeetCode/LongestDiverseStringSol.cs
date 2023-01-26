using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class LongestDiverseStringSol
    {
        public string LongestDiverseString(int a, int b, int c)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('a', a);
            dict.Add('b', b);
            dict.Add('c', c);

            Dictionary<char, int> copy = new Dictionary<char, int>(dict);
            string output = string.Empty;
            do
            {
                char tmpChar = '0';
                int tmpValue = -1;
                foreach (var item in dict.OrderByDescending(key => key.Value))
                {
                   if (item.Value > 0 && TryToAppend(ref output, item.Key, copy[item.Key]))
                   {
                        // TryToAppend(ref output, item.Key, item.Value);
                        tmpChar = item.Key;
                        tmpValue = item.Value;
                        break;
                   }

                }
                if (tmpChar == '0')
                { 
                    break;
                }
                dict[tmpChar] = tmpValue - 1;
            } while (true);

            return output;
        }

        private bool TryToAppend(ref string input, char c, int count)
        {
            int occ = input.Count(s => s == c);
            if (occ == count)
            {
                return false;
            }
            if (input.Length >= 2)
            {
                var tmpStr = input.Substring(input.Length - 2);
                if (tmpStr.Count(s => s == c) == 2)
                {
                    return false;
                }
            }
            input = input + c;
            return true;
        }

    }
}
