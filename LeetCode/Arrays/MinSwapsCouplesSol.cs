using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class MinSwapsCouplesSol
    {
        public int MinSwapsCouples(int[] row)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < row.Length; i++)
            {
                map.Add(row[i], i);
            }
            int step = 0;
            for (int i = 0; i < row.Length; i += 2)
            {
                int pairValue;
                if (row[i] % 2 == 0)
                {
                    pairValue = row[i] + 1;
                }
                else
                {
                    pairValue = row[i] - 1;
                }
                if (row[i + 1] != pairValue)
                {
                    int tmpPos = map[pairValue];
                    int tmpValue = row[i + 1];
                    
                    row[i + 1] = pairValue;
                    row[tmpPos] = tmpValue;

                    map[pairValue] = i + 1;
                    map[tmpValue] = tmpPos;

                    step++;
                }
            }
            return step;
        }
    }
}
