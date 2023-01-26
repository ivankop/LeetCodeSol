using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LargestRectangleAreaSol
    {
        
        public int LargestRectangleArea(int[] heights)
        {
            int[] area = new int[heights.Length]; 
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            int ans  = heights[0];
            int lowestPos = 0;
            for (int i = 1; i < heights.Length; i++)
            {
                area[i] = heights[i];
                if (heights[i] > heights[i-1])
                {
                    stack.Push(i);
                }
                else
                {
                    while (stack.Count > 0 && heights[stack.Peek()] > heights[i])
                    {
                        var prev = stack.Pop();
                        var tmp1 = heights[prev] * (i - prev);
                        var pos = stack.Count > 0 ? stack.Peek() : -1;
                        var tmp2 = heights[prev] * (i - 1 - pos);

                        area[prev] = tmp2;

                        if (area[prev] >  ans)
                        {
                            ans = area[prev];
                        }
                    }
                    
                    stack.Push(i);
                    
                }
                if (heights[i] < heights[lowestPos])
                {
                    lowestPos = i;
                }
            }

            while (stack.Count > 0)
            {
                var prev = stack.Pop();
                var pos = stack.Count > 0 ? stack.Peek() : -1;
                area[prev] = heights[prev] * (heights.Length - 1 - pos);
                if (area[prev] > ans)
                {
                    ans = area[prev];
                }
            }

            ans = Math.Max(ans, heights[lowestPos] * heights.Length);

            return ans;
        }

        private int findMax(int[] heights, int index)
        {
            var l = index - 1;
            var r = index + 1;
            int leftArea = 0, rightArea = 0;
            while (l >= 0)
            {
                if (heights[l] < heights[index])
                {
                    break;
                }
                leftArea += heights[index];
                l--;
            }

            while (r < heights.Length)
            {
                if (heights[r] < heights[index])
                {
                    break;
                }
                rightArea += heights[index];
                r++;
            }
            return leftArea + heights[index] + rightArea;

        }
    }
}
