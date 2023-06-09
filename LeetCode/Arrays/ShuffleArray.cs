using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class ShuffleArray
    {
        int[] orgArr;
        int[] arr;
        public ShuffleArray(int[] nums)
        {
            orgArr = nums;
            arr = new int[nums.Length];
        }

        public int[] Reset()
        {
            // arr = orgArr;
            return orgArr;
        }

        public int[] Shuffle()
        {
            var rand = new Random();
            
            HashSet<int> indexSet = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int index;
                do
                {
                    index = rand.Next(0, arr.Length);
                }
                while (indexSet.Contains(index));
                    
                indexSet.Add(index);
                arr[i] = orgArr[index];
            }
            return arr;
        }
    }
}
