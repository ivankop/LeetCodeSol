using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TrappingRainWater
    {
        public int Trap(int[] height)
        {
            var ltr = l2r(height);
            var rtl = r2l(height);

            int count = 0;
            for (int i = 1; i < height.Length - 1; i++)
            {
                var leftMin = Math.Min(ltr[i - 1], rtl[i - 1]);
                var rightMin = Math.Min(ltr[i + 1], rtl[i + 1]);
                var min = Math.Min(leftMin, rightMin);
                var tmp = min - height[i];
                if (tmp > 0)
                {
                    count += tmp;
                }
            }
            return count;
        }

        private int[] l2r(int[] height)
        {
            int[] l2r = new int[height.Length];
            for (int i = 0; i < height.Length; i++)
            {
                if (i == 0)
                {
                    l2r[i] = height[i];
                }
                else
                {
                    l2r[i] = Math.Max(l2r[i-1], height[i]);
                }
            }
            return l2r;
        }

        private int[] r2l(int[] height)
        {
            int[] r2l = new int[height.Length];
            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (i == height.Length - 1)
                {
                    r2l[i] = height[height.Length - 1];
                }
                else
                {
                    r2l[i] = Math.Max(r2l[i + 1], height[i]);
                }
            }
            return r2l;
        }

        public int Trap2(int[] height)
        {
            List<int[]> tank = new List<int[]>();
            int maxRow = 0;
            var currentRow = 0;
            int count = 0;
            int l = 0;
            int r = height.Length - 1;

            while (currentRow <= maxRow)
            {
                while (height[l] <= currentRow && l < r)
                {
                    l++;
                }
                while (height[r] <= currentRow && r > l)
                {
                    r--;
                }
                if (l == r)
                {
                    break;
                }
                var tmpl = l;
                var tmpr = r;
                while (tmpl <= tmpr)
                {
                    if (tmpl == tmpr && height[tmpl] <= currentRow)
                    {
                        count++;
                    }
                    else
                    {
                        if (height[tmpl] <= currentRow)
                        {
                            count++;
                        }
                        if (height[tmpr] <= currentRow)
                        {
                            count++;
                        }
                    }
                    maxRow = Math.Max(maxRow, Math.Max(height[tmpl], height[tmpr]));
                    tmpl++;
                    tmpr--;
                    
                }
                /*
                for (int j = l; j < r; j++)
                {
                    if (height[j] <= currentRow)
                    {
                        count++;
                    }
                    maxRow = Math.Max(maxRow, height[j]);
                }
                */
                currentRow++;
            }

            return count;

        }
    }
}
