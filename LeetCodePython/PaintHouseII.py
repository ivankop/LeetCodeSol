from typing import List
from queue import PriorityQueue
import sys


class minCostIISol:
    def minCostII(self, costs: List[List[int]]) -> int:
        n = len(costs)
        k = len(costs[0])
        q = PriorityQueue()
        
        dp = [[-1] * k for _ in range(n)]
        for i in range(k):
            q.put((costs[0][i], i))
        row = 1
        dp[0] = [costs[0]]
        while not q.empty():
            tmpQ = PriorityQueue()
            
            cost, index = q.get()
            if row == n:
                return cost
            for i in range(k):
                if i != index:
                    dp[row][i] = costs[row][i] + cost
                    tmpQ.put((costs[row][i] + cost, i))
                else:
                    cost2, index2 = q.queue[0]
                    dp[row][i] = costs[row][i] + cost2
                    tmpQ.put((costs[row][i] + cost2, i))
            row += 1
            q = tmpQ
        return -1


