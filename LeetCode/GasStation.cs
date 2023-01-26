using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class GasStation
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            for (int i = 0; i < gas.Length; i++)
            {
                int stops = 0;
                int tank = gas[i];
                int nextStop = i;
                while (tank >= cost[nextStop])
                {
                    if (stops == gas.Length)
                    {
                        return i;
                    }
                    tank = tank - cost[nextStop];
                    stops++;
                    nextStop = (nextStop + 1) % gas.Length;
                    tank += gas[nextStop];
                }
                i += stops;
            }
            return -1;
        }
    }
}
