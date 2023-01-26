using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinimumRoundsSol
    {
        public int MinimumRounds(int[] tasks)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int round = 0;

            foreach (int task in tasks)
            {
                if (!dict.ContainsKey(task))
                {
                    dict.Add(task, 1);
                }
                else
                {
                    dict[task]++;
                }
                if (dict[task] == 5)
                {
                    round += 1;
                    dict[task] = 2;
                }
            }

            // Queue<int> queue = new Queue<int>();

            foreach (var item in dict)
            {
                if (item.Value == 1)
                {
                    return -1;
                }
                if (item.Value == 4)
                {
                    round += 2;
                }
                else
                {
                    round += 1;
                }
            }
            /*
            
            while (dict.Count > 0)
            {
                int nextLevel = 0;
                foreach (var item in dict)
                {
                    if (item.Value >= 2)
                    {
                        nextLevel = item.Key;
                        break;
                    }
                }
                if (dict.Count > 0 && nextLevel == 0)
                    return -1;

                round++;
                var level = nextLevel;
                if (dict[level] % 3 == 0)
                {
                    round += dict[level] / 3 - 1;
                    dict[level] = 0;
                }
                else if (dict[level] > 4 && (dict[level] - 4) % 3 == 0)
                {
                    round += (dict[level] - 4) / 3 - 1;
                    dict[level] = 4;
                }
                else if (dict[level] != 2 && dict[level] != 4)
                {
                    dict[level] -= 3;
                }
                else // if (dict[level] % 2 == 0)
                {
                    dict[level] -= 2;
                }

                if (dict[level] == 0)
                {
                    dict.Remove(level);
                }
                // var nextLevel = dict.Where(t => t.Value >= 4 || t.Value >= 2).Select(t => t.Key).FirstOrDefault();
            }
            */

            return round;
        }
    }
}
