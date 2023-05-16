class countGoodStringsSol:
    def countGoodStrings(self, low: int, high: int, zero: int, one: int) -> int:
        count = 0
        mod = 10**9 + 7
        mem = {}
        def dfs(curLen: int):
            if curLen > high:
                return 0
            
            if curLen in mem:
                return mem[curLen]
            
            res = 0
            if curLen >= low:
                res += 1

            res += dfs(curLen + zero) + dfs(curLen + one)
            res %= mod
            mem[curLen] = res
            return res
        count = dfs(0)
        return count
            