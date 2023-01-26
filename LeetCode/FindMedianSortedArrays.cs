using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class FindMedianSortedArraysSolution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i = 0, j = 0, k = 0;
            int m = nums1.Length;
            int n = nums2.Length;
            int[] num3 = new int[m + n];
            int midIndex = (m + n) / 2;

            // Traverse both array
            while (i < m && j < n && k <= midIndex + 1)
            {
                // Check if current element
                // of first array is smaller
                // than current element
                // of second array. If yes,
                // store first array element
                // and increment first array
                // index. Otherwise do same
                // with second array
                if (nums1[i] < nums2[j])
                    num3[k++] = nums1[i++];
                else
                    num3[k++] = nums2[j++];
            }

            // Store remaining
            // elements of first array
            while (i < m && k <= midIndex + 1)
                num3[k++] = nums1[i++];

            // Store remaining elements
            // of second array
            while (j < n && k <= midIndex + 1)
                num3[k++] = nums2[j++];

            if ((m + n) % 2 == 0)
            {
                return (double)(num3[midIndex] + num3[midIndex-1]) / 2;
            }
            return num3[midIndex];
        }
    }
}
