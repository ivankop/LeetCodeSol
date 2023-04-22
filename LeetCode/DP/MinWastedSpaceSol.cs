using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DP
{
    public class MinWastedSpaceSol
    {
        int MOD = 1000000007;
        int minWastedSpace = int.MaxValue;
        public int MinWastedSpace(int[] packages, int[][] boxes)
        {
            Array.Sort(packages);
            //List<int[]> sorted = new List<int[]>();
            //for (int i = 0; i < boxes.Length; i++)
            //{
            //    Array.Sort(boxes[i]);
                
            //}
            //Console.WriteLine("Sorted");
            
            foreach (var box in boxes)
            {
                var tmp = CalWastedSpace(packages, box);
                // if (tmp != -1)
                {
                    minWastedSpace = Math.Min(minWastedSpace, tmp);
                }
            }
            if (minWastedSpace == int.MaxValue)
            {
                minWastedSpace = -1;
            }
            return minWastedSpace;
        }

        int CalWastedSpace(int[] packages, int[] boxes)
        {
            Array.Sort(boxes);
            if (boxes[boxes.Length - 1] < packages[packages.Length - 1])
            {
                return -1;
            }
            int wastedSpace = 0;
            int index = 0;
            for (int i = 0; i < packages.Length; i++)
            {
                for (int j = index; j < boxes.Length; j++)
                {
                    if (boxes[j] >= packages[i])
                    {
                        wastedSpace += (boxes[j] - packages[i]);
                        wastedSpace %= MOD;
                        if (wastedSpace >= minWastedSpace)
                        {
                            return -1;
                        }
                        index = j;
                        break;
                    }
                }
            }
            return wastedSpace;
        }
    }
}
