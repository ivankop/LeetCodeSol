using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class ReverseWordsSol
    {
        public string ReverseWords(string s)
        {
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            StringBuilder output = new StringBuilder();
            foreach (var item in words)
            {
                output.Append(item.Trim() + " ");
            }

            return output.ToString().Trim();
        }
    }
}
