using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class RacecarSol
    {
        public int Racecar(int target)
        {
            var visited = new HashSet<Tuple<int,int, int>>();
            var queue = new Queue<Tuple<int,int, int>>();
           
            queue.Enqueue(new Tuple<int,int, int>(0, 0, 1)); // move 0 , pos 0, speed 1
            while(queue.Count > 0)
            {
                var q = queue.Dequeue();
                if(q.Item2 == target)
                    return q.Item1;
                if (visited.Contains(q))
                    continue;
                visited.Add(q);
                queue.Enqueue(new Tuple<int, int, int>(q.Item1+1, q.Item2+q.Item3, q.Item3*2));
                if ((q.Item2 + q.Item3 > target && q.Item3 > 0) || (q.Item2 + q.Item3 < target && q.Item3 < 0))
                {
                    queue.Enqueue(new Tuple<int, int, int>(q.Item1 + 1, q.Item2, q.Item3 > 0 ? -1 : 1));
                }
            }

            return -1;
        }
    }
}
