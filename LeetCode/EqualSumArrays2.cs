using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class EqualSumArrays2
    {
        public int MinOperations(int[] nums1Arr, int[] nums2Arr)
        {
            if (nums1Arr.Length > nums2Arr.Length * 6 || nums2Arr.Length > nums1Arr.Length * 6)
            {
                return -1;
            }

            int sumArr1 = 0, sumArr2 = 0;
            var dict1 = SumArray(nums1Arr, ref sumArr1);
            var dict2 = SumArray(nums2Arr, ref sumArr2);

            int[] nums1, nums2;
            if (sumArr1 <= sumArr2)
            {
                nums1 = nums1Arr;
                nums2 = nums2Arr;
            }
            else
            {
                nums1 = nums2Arr;
                nums2 = nums1Arr;
                var tmp = sumArr2;
                sumArr2 = sumArr1;
                sumArr1 = tmp;

            }

            int step = 0;

            while (sumArr1 != sumArr2)
            {
                if (sumArr1 == sumArr2)
                {
                    break;
                }

                // try to increase
                int value1 = -1, index1 = -1;
                int value2 = -1, index2 = -1;
                int gap1 = Increase(nums1, sumArr1, sumArr2, ref value1, ref index1);
                int gap2 = Decrease(nums2, sumArr2, sumArr1, ref value2, ref index2);

                if (gap1 == 0 || gap2 == 0)
                {
                    step++;
                    break;
                }

                if (gap1 == int.MaxValue && gap2 == int.MaxValue)
                {
                    return -1;
                }

                if (gap1 == gap2)
                {
                    if (dict1[value1] < dict2[value1])
                    {
                        gap1++;
                    }
                    else
                    {
                        gap2++;
                    }
                }

                if (gap1 < gap2)
                {
                    sumArr1 = sumArr1 - nums1[index1] + value1;
                    nums1[index1] = value1;
                }
                else
                {
                    sumArr2 = sumArr2 - nums2[index2] + value2;
                    nums2[index2] = value2;
                }

                step++;
            }

            return step;
        }
        private static int[] VALUES = new int[] { 1, 2, 3, 4, 5, 6 };
        private int[] SumArray(int[] nums, ref int sum)
        {
            int[] dict = new int[7];
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                dict[nums[i]]++;
            }
            return dict;
        }

        private int Increase(int[] nums, int currentSum, int targetSum, ref int value, ref int index)
        {
            // find min index
            int minValue = 6;
            int minIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < minValue)
                {
                    minValue = nums[i];
                    minIndex = i;

                    if (minValue == 1)
                    {
                        break;
                    }
                }
            }

            if (minIndex == -1)
            {
                return int.MaxValue;
            }
            for (int j = 5; j >= 0; j--)
            {
                var tempValue = currentSum - nums[minIndex] + VALUES[j];
                if (tempValue <= targetSum)
                {
                    currentSum = tempValue;
                    value = VALUES[j];
                    index = minIndex;
                    return targetSum - currentSum;
                }
            }
            return int.MaxValue;
        }


        private int Decrease(int[] nums, int currentSum, int targetSum, ref int value, ref int index)
        {
            // find max index
            int maxValue = 1;
            int maxIndex = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maxValue)
                {
                    maxValue = nums[i];
                    maxIndex = i;
                    if (maxIndex == 6)
                    {
                        break;
                    }
                }
            }

            if (maxIndex == -1)
            {
                return int.MaxValue;
            }
            for (int j = 0; j < VALUES.Length; j++)
            {
                var tempValue = currentSum - nums[maxIndex] + VALUES[j];
                if (tempValue >= targetSum)
                {
                    currentSum = tempValue;
                    value = VALUES[j];
                    index = maxIndex;
                    return currentSum - targetSum;
                }
            }
            return int.MaxValue;
        }
    }
}
