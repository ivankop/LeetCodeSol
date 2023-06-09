from typing import List
from queue import PriorityQueue

class stoneGameIISol:
    def stoneGameII(self, piles: List[int]) -> int:
        n = len(piles)
        mem = {}
        def dfs(index, M, isAlice):
            if index >= n:
                return 0, 0
            key = (index, M, isAlice)
            if key in mem:
                return mem[key]
            take = 0
            q = PriorityQueue()
            for i in range(M * 2):
                nextIndex = index + i
                if nextIndex < n:
                    take += piles[nextIndex]
                    X = i + 1
                    (alice, bob) = dfs(nextIndex + 1, max(X, M), not isAlice)
                    if isAlice:
                        q.put((bob, take + alice))
                    else:
                        q.put((alice, take + bob))
                                    
            res1, res2 = q.get()
            if  isAlice:
                mem[key] = res2, res1
            else:
                mem[key] = res1, res2
            return mem[key]
        (alice, bob) = dfs(0, 1, True)
        return alice
                     
                