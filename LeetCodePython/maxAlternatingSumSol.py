from typing import List
import sys

class maxAlternatingSumSol:
    def maxAlternatingSum(self, nums: List[int]) -> int:
        n = len(nums)
        ans = -sys.maxsize - 1
        mem = {}
        def altSum(seq:List[int]):
            evenSum = 0
            oddSum = 0
            for i in range(len(seq)):
                if i % 2 != 0:
                    oddSum += seq[i]
                else:
                    evenSum += seq[i]
            return evenSum - oddSum
        def findSubSeq(index :int, isEven: bool):
            nonlocal ans
            if index == n:
                return 0
            if (index, isEven) in mem:
                return mem[(index, isEven)]
            maxVal = findSubSeq(index + 1, isEven)
            if isEven :
                tmp = findSubSeq(index + 1, not isEven) - nums[index]
            else:
                tmp = findSubSeq(index + 1, not isEven) + nums[index]
            maxVal = max(tmp, maxVal)
            mem[(index, isEven)] = maxVal

            return maxVal

        
        ans = findSubSeq(0, False)

        return ans
        