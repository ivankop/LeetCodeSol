from typing import List

class MaxValueOfCoinsSol:
    
    def maxValueOfCoins(self, piles: List[List[int]], k: int) -> int:
        n = len(piles)
        mem = {}
        def pick(pile, coins) -> int:
            if pile == n or coins == k:
                return 0
            if (pile, coins) in mem:
                return mem[(pile, coins)]
            maxVal = pick(pile + 1, coins)
            curValue = 0
            for i in range(min(len(piles[pile]), k - coins)):
                curValue += piles[pile][i]
                maxVal = max(maxVal, curValue + pick(pile + 1, coins + i + 1))
            mem[(pile, coins)] = maxVal
            return maxVal
        
        ans = pick(0, 0)
        return ans
