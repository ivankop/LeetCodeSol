using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class MinCostSol
    {
        public int MinCost(string colors, int[] neededTime)
        {
            Dictionary<int, int> removeIndexes = new Dictionary<int, int>();
            char previousColor = colors[0];
            int previousColorIndex = 0;
            for (int i = 1; i < colors.Length; i++)
            {
                if (colors[i] == previousColor && !removeIndexes.ContainsKey(i))
                {
                    // remove i or i + 1
                    if (neededTime[i] <= neededTime[previousColorIndex])
                    {
                        removeIndexes.Add(i, neededTime[i]);
                    }
                    else
                    {
                        removeIndexes.Add(previousColorIndex, neededTime[previousColorIndex]);
                        previousColorIndex = i;
                    }
                } 
                else
                {
                    previousColorIndex = i;
                    previousColor = colors[i];
                }
            }

            var res = removeIndexes.Sum(kv => kv.Value);
            return res;
        }
    }
}
