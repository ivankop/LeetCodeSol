using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class DailyTemperaturesSol
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] ans = new int[temperatures.Length];
            // DailyTemperaturesRec(temperatures, 0, ans);
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            // Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[i] > stack.Peek().Item2)
                {
                    var prevDay = stack.Pop();
                    ans[prevDay.Item1] = i - prevDay.Item1;
                }

                if (i < temperatures.Length - 1 && temperatures[i] < temperatures[i + 1])
                {
                    ans[i] = 1;
                }
                else
                {
                    // q.Enqueue(new Tuple<int, int>(i, temperatures[i]));
                    stack.Push(new Tuple<int, int>(i, temperatures[i]));
                }
                
            }

            return ans;
        }
        public int DailyTemperaturesRec(int[] temperatures, int index, int[] ans)
        {
            int count = 1;
            while (index < temperatures.Length - 1 && temperatures[index] < temperatures[index+1])
            {
                ans[index] =1;
                index++;
                count++;
            }
            if (index < temperatures.Length)
            {
                var tmp = DailyTemperaturesRec(temperatures, index + 1, ans);
                ans[index] = tmp;
            }
            
            return count;
        }
    }
}
