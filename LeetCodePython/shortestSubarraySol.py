from typing import List
from queue import PriorityQueue
import sys

class shortestSubarraySol:
    def shortestSubarray(self, nums: List[int], k: int) -> int:
        n = len(nums)
        q = PriorityQueue()
        curSum = nums[0]
        start = 0
        end = 0

        for i in range(1, n):
            if curSum + nums[i] < curSum:
                #if curSum >= k:
                q.put((curSum, (curSum, start, end)))
                start = i
                end = i
                curSum = nums[i]
            else:
                end = i
                curSum += nums[i]
        ans = sys.maxsize
        while not q.empty():
            curSum, start, end = q.get()
            while start < end :
                if curSum - nums[start] < k:
                    ans = min(ans, end - start)
                    break
                start += 1
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
                

                 


        
