from typing import List

class subarraysDivByKSol:
    def subarraysDivByK(self, nums: List[int], k: int) -> int:
        n = len (nums)
        preSum = []
        preSum.append(0)
        sum = 0
        ans = 0
        for i in range(0, n):
            sum += nums[i]
            if sum % k == 0:
                ans += 1
            for j in range (n - 1):
                if (sum - preSum[j]) % k == 0:
                    ans += 1
            preSum.append(sum)
        return ans

