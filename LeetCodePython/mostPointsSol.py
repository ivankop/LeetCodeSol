from typing import List
import sys

class mostPointsSol:
    def mostPoints(self, questions: List[List[int]]) -> int:
        n = len(questions)
        dp = [-1] * n
        #mem = {}
        def dfs(index :int):
            if index >= n:
                return 0
            if dp[index] != -1:
                return dp[index]
            p = dfs(index + 1)
            p = max(p, dfs(index + questions[index][1] + 1) + questions[index][0])
            dp[index] = p
            return p
        return dfs(0)
