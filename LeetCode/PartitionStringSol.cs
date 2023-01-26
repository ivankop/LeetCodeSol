using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class PartitionStringSol
    {
        public int PartitionString(string s)
        {
            HashSet<char> set = new HashSet<char>();
            int count = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (!set.Contains(s[i]))
                {
                    set.Add(s[i]);
                }
                else
                {
                    set = new HashSet<char>();
                    set.Add(s[i]);
                    count++;
                }
            }
            return count;
        }
    }
}
