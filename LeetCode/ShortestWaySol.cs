using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ShortestWaySol
    {
        public int ShortestWay(string source, string target)
        {
            int count = 1;
            int startIndex = -1;
            for (int i = 0; i < target.Length; i++)
            {
                if (!source.Contains(target[i]))
                {
                    return -1;
                }
                startIndex++;
                if (startIndex >= source.Length)
                {
                    // startIndex = -1;
                    startIndex = 0;
                    count++;
                    // break;
                }
                while (source[startIndex] != target[i])
                {
                    startIndex++;  
                    if (startIndex == source.Length)
                    {
                        // startIndex = -1;
                        startIndex = 0;
                        count++;
                        // break;
                    }
                }
            }

            return count;
        }
    }
}
