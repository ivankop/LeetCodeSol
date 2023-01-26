using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class SmallestPositiveInteger
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            List<int> sortedList = A.Distinct().OrderBy(i => i).ToList();
            if (sortedList[sortedList.Count-1] < 0)
            {
                return 1;
            }
            
            for (int i = 1; i < sortedList[sortedList.Count-1]; i++)
            {
                if (!sortedList.Contains(i))
                {
                    return i;
                }
            }
            return sortedList[sortedList.Count-1] + 1;
        }
    }
}
