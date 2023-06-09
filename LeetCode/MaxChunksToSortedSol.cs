using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MaxChunksToSortedSol
    {
        public int MaxChunksToSorted(int[] arr)
        {
            int count = 1;
            var maxLeft = GetMaxFromLeft(arr);
            var minRight = GetMinFromRight(arr);
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] >= maxLeft[i] && minRight[i] >= maxLeft[i - 1])
                    count++;
            }
            return count;
        }

        int[] GetMaxFromLeft(int[] arr)
        {
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    res[i] = arr[i];
                }
                else
                {
                    res[i] = Math.Max(arr[i], res[i-1]);
                }
            }

            return res;
        }

        int[] GetMinFromRight(int[] arr)
        {
            int[] res = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (i == arr.Length - 1)
                {
                    res[i] = arr[arr.Length - 1];
                }
                else
                {
                    res[i] = Math.Min(arr[i], res[i+1]);
                }
            }
            return res;
        }

        public int MaxChunksToSorted1(int[] arr)
        {
            int count = 1;
            Stack<int> stack = new Stack<int>();
            stack.Push(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                if (stack.Count == 0 || arr[i] < stack.Peek() || (arr[i] == stack.Peek() && stack.Count > 1))
                {
                    stack.Push(arr[i]);
                }
                else
                {
                    //stack.
                    while (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    stack.Push(arr[i]);
                    count++;
                }
            }
            return count;
        }
    }
}
