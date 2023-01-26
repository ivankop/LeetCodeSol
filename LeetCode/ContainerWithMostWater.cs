using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int maxArea = 0;
            //var ltr = LTR(height);
            //var rtl = RTL(height);
            int l = 0, r = height.Length - 1;
            while (l < r)
            {
                int area = (r - l) * Math.Min(height[l], height[r]);
                if (area > maxArea)
                {
                    maxArea = area;
                }
                if (height[r] > height[l])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return maxArea;
        }

        Tuple<int, int>[] LTR(int[] height)
        {
            Tuple<int, int>[] ans = new Tuple<int, int>[height.Length];
            for (int i = 0; i < height.Length; i++)
            {
                if (i == 0)
                {
                    ans[i] = new Tuple<int, int>(height[i], i);
                }
                else
                {
                    if (height[i] + i > ans[i-1].Item1 + i - 1 )
                    {
                        ans[i] = new Tuple<int, int>(height[i], i);
                    }
                    else
                    {
                        ans[i] = ans[i-1];
                    }
                }
            }
            return ans;
        }

        Tuple<int, int>[] RTL(int[] height)
        {
            Tuple<int, int>[] ans = new Tuple<int, int>[height.Length];
            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (i == height.Length - 1)
                {
                    ans[i] = new Tuple<int, int>(height[i], i);
                }
                else
                {
                    if (height[i] + i > ans[i + 1].Item1 + i + 1)
                    {
                        ans[i] = new Tuple<int, int>(height[i], i);
                    }
                    else
                    {
                        ans[i] = ans[i + 1];
                    }
                }
            }
            return ans;
        }
    }
}
