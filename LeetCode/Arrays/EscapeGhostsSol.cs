using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class EscapeGhostsSol
    {
        public bool EscapeGhosts(int[][] ghosts, int[] target)
        {
            var userMaxDistance = GetDistance(0, 0, target[0], target[1]);
            // double ghostMinDistance = (double)int.MaxValue;
            foreach (var ghost in ghosts)
            {
                var distance = GetDistance(ghost[0], ghost[1], target[0], target[1]);
                if (distance <= userMaxDistance)
                    return false;
                // ghostMinDistance = Math.Min(distance, ghostMinDistance);
            }
            // Console.WriteLine($"{ghostMinDistance}-{userMaxDistance}");
            return true;
            
        }

        private static double GetDistance(double x1, double y1, double x2, double y2)
        {
            // 7, 4 - 3, 0 -> 4 + 4 -> 8 
            // -7, 4 - 3, 0 -> 10 + 4
            return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
            //return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

    }
}
