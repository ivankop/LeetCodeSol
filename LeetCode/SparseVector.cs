using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SparseVector
    {
        public Dictionary<int, int> Vectors { get; set; }
        public SparseVector(int[] nums)
        {
            Vectors = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    Vectors[i] = nums[i];
                }
            }
        }

        // Return the dotProduct of two sparse vectors
        public int DotProduct(SparseVector vec)
        {
            int product = 0;
            foreach (var item in Vectors)
            {
                product += item.Value * (vec.Vectors.ContainsKey(item.Key) ? vec.Vectors[item.Key] : 0);
            }
            return product;
        }
    }
}
