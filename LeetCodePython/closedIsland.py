from typing import List

class closedIslandSol:
    def closedIsland(self, grid: List[List[int]]) -> int:
        n = len(grid)
        m = len(grid[0])
        dir = [[1, 0][-1, 0][0, 1][0, -1]]
        def dfs(row:int, col:int, visited : set):
            if row < 0 or row >= n or col < 0 or col >= m:
                return False
            
            if grid[row][col] == 1:
                return True
            set.add((row, col))
            grid[row][col] = -1
            for d in dir:
                nextRow = row + d[0]
                nextCol = col + d[1]
                if (nextRow, nextCol) not in visited: 
                    if dfs(nextRow, nextCol, visited) == False :
                        return False
            return True
        ans = 0
        for i in range(n):
            for j in range(m):
                if grid[i][j] == 0:
                    if dfs(i, j, set()) == True:
                        ans += 1
        return ans


                


            
