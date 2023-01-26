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
