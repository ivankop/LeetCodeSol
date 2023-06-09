from typing import List
from queue import PriorityQueue
import sys

from collections import deque

class shortestSubarraySol:
    def shortestSubarray(self, nums: List[int], k: int) -> int:
        preSum = [nums[0]]
        n = len(nums)
        queue = deque()
        for i in range(1, n):
            preSum.append(nums[i] + preSum[-1])
        ans = sys.maxsize
        for i in range(n):
            if preSum[i] >= k:
                ans = min(ans, i + 1)
            left = sys.maxsize
            while len(queue) > 0 and preSum[i]  - preSum[queue[0]] >= k:
                left = queue.popleft()                    
            #left = queue[0] if len(queue) > 0 else i
            if left != sys.maxsize:
                ans = min(ans, i - left)
            while len(queue) > 0 and preSum[queue[-1]] > preSum[i]:
                queue.pop()
            queue.append(i)

            
        if ans == sys.maxsize:
            return -1
        return ans

    
    def shortestSubarray2(self, nums: List[int], k: int) -> int:
        n = len(nums)
        queue = []
        for i in range(n):
            queue.append((i,nums[i],1))
        while len(queue) > 0:
            count = len(queue)
            for i in range(count):
                index, sum, c = queue.pop(0)
                if sum == k:
                    return c
                if index + 1 < n:
                    sum += nums[index + 1]
                    queue.append((index+1, sum, c+1))
        return -1
                

                 


        
