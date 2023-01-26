using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RectangleArea
    {
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            var xIntersec = FindIntersect(ax1, ax2, bx1, bx2);
            var yIntersec = FindIntersect(ay1, ay2, by1, by2);
            var area1 = (ax2 - ax1) * (ay2 - ay1);
            var area2 = (bx2 - bx1) * (by2 - by1);
            var area3 = xIntersec  * yIntersec;

            return area1 + area2 - area3;
        }
        int FindIntersect(int ax1, int ax2, int bx1, int bx2)
        {
            if (ax2 <= bx1 || bx2 <= ax1)
            {
                return 0;
            }
            /*
            if (bx1 >= ax1 && bx2 >= ax2)
            {
                return ax2 - ax1;
            }
            */
            var x1 = Math.Max(ax1, bx1);
            var x2 = Math.Min(ax2, bx2);
            return x2 - x1;
        }
    }
}
