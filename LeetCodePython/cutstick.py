from typing import List
from queue import PriorityQueue

class CutStick:
    def minCost(self, n: int, cuts: List[int]) -> int:
        cuts = sorted(cuts)
        mem = {}
        def dfs(start, end):
            if (start, end) in mem:
                return mem[(start, end)]
            cost = end - start
            mincost = float("inf")
            for c in cuts:
                if c > start and c < end:
                    left = dfs(start, c)
                    right = dfs(c, end)
                    mincost = min(mincost, left + right)

            if mincost == float("inf"):
                mincost = 0
            else:
                mincost = mincost + cost
            mem[(start, end)] = mincost
            return mem[(start, end)]
        
        ans = dfs(0, n)
        return ans

    def minCost_bfs(self, n: int, cuts: List[int]) -> int:
        cutList = []
        pq = PriorityQueue()
        for i in range (len(cuts)):
            cutList.append((cuts[i], cuts[i]))
        cuts = sorted(cuts)
        pq.put(((-1 * n), (0 , n)))
        totalCost = 0

        while not pq.empty():
            cost, (start, end) = pq.get()
            # find middle of current stick
            left = right = (int) ((end - start) / 2 + start)
            # find cut that near the mid
            found = False
            while left >= start or right <= end :
                if (left >= start and left in cuts) or (right in cuts and right <= end):
                    found = True
                    break
                
                left -= 1
                right += 1
            if not found:
                continue
            if left in cuts and right in cuts:
                if left - start >= end - right:
                    pos = left
                else:
                    pos = right
            elif left in cuts:
                pos = left
            else:
                pos = right

            if pos not in cuts:
                continue
            
            pq.put(((-1 * (pos - start)), (start, pos)))
            pq.put(((-1 * (end - pos)), (pos , end)))
            cuts.remove(pos)
            totalCost += -1 * cost
            if len(cuts) == 0:
                return totalCost
        
        return totalCost



