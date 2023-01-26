using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class RoomDecor
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int highestBuilding = 0;
            for (int i = 0; i < A.Length; i++)
            {
                dict[i] = A[i];
                if (highestBuilding < A[i])
                {
                    highestBuilding = A[i];
                }
            }

            int totalStrokes = 0;
            for (int i = 0; i < highestBuilding; i++)
            {
                int s = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (dict[j] > i)
                    {
                        if (s == 0)
                        {
                            s = 1;
                        }
                    }
                    else
                    {
                        totalStrokes += s;
                        s = 0;
                    }
                }
                totalStrokes += s;
                if (totalStrokes >= 1000000000)
                {
                    return -1;
                }
            }
           
            return totalStrokes;
        }
    }
}
