using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class MinDeletionsSol
    {
        public int MinDeletions(string s)
        {
            // this dictionary store the count of each letter
            Dictionary<char, int> dict = new Dictionary<char, int>();
            // count the occurrences of each letter
            foreach (char c in s)
            {
                // int currentCount;
                dict.TryGetValue(c, out int currentCount);
                dict[c] = currentCount + 1;
            }
            // start with the most occurrence letter
            var orderedList = dict.OrderBy(x => x.Value).ToList();
            int totalDelete = 0;
            foreach (var item in orderedList)
            {
                int tmpDel = 0;
                // delete one time if the occurrence is not unique
                while (dict.Any(x => x.Key != item.Key && x.Value == item.Value - tmpDel && x.Value != 0))
                {
                    tmpDel++;
                    dict[item.Key]--;
                }
                totalDelete += tmpDel;
            }

            return totalDelete;
        }
    }
}
