from typing import List
import sys


class maxScoreSol:
    def maxScore(self, nums1: List[int], nums2: List[int], k: int) -> int:
        ans = -1
        n = len(nums1)
        mem = {}
        def dfs(index, remain):
            if remain == 0:
                return 0, 0
            if index == n or n - index < remain:
                return 0, 0
           
            key = (index, remain)
            #if key in mem:
             #   return mem[key]
            # skip
            sum1, min1 = dfs(index + 1, remain)

            # include
            sum2 = nums1[index]
            min2 = nums2[index]
            max = -1

            for i in range(index + 1, index + remain):
                tmpSum, tmpMin  = dfs(i, remain - 1)
                if (tmpSum + nums1[index]) * min(tmpMin, nums2[index]) > max:
                    sum2 = nums1[index] + tmpSum
                    min2 =  min(tmpMin, nums2[index])
                    max = sum2 * min2

            if sum1 * min1 > sum2 * min2:
                mem[key] = (sum1, min1)
            else:
                mem[key] = (sum2, min2)
            return mem[key]
        sumVal, minVal = dfs(0, k)
        ans = sumVal * minVal
        return ans
            