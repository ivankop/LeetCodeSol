from queue import Queue
from typing import List
import sys


class shortestBridgeSol:
    def shortestBridge(self, grid: List[List[int]]) -> int:
        dirs = [[0, 1],[1, 0],[0, -1],[-1, 0]]
        n = len(grid)
        ans = n
        queue = Queue()
        
        def dfs(row, col, visited: set):
            grid[row][col] = -1
            visited.add((row, col))
            queue.put((row, col))
            for dir in dirs:
                    nextRow = row + dir[0]
                    nextCol = col + dir[1]
                    if nextRow < 0 or nextRow >= n or nextCol < 0 or nextCol >= n:
                        continue
                    if grid[nextRow][nextCol] == 1 and (nextRow, nextCol) not in visited:
                        dfs(nextRow, nextCol, visited)
        visited = set()
        for i in range(n):
            found = False
            for j in range(n):
                if grid[i][j] == 1:
                    dfs(i, j, visited)  
                    found = True
                    break
            if found:
                break

        step = 0
        while not queue.empty():
            count = queue.qsize()
            for _ in range(count):
                row, col = queue.get()
                # grid[row][col] = -1 * (step + 1)
                
                for dir in dirs:
                    nextRow = row + dir[0]
                    nextCol = col + dir[1]
                    if nextRow < 0 or nextRow >= n or nextCol < 0 or nextCol >= n: # or (nextRow, nextCol) in visited:
                        continue
                    if grid[nextRow][nextCol] == 1:
                        return step
                    if grid[nextRow][nextCol] == 0:
                        queue.put((nextRow, nextCol))
                        grid[nextRow][nextCol] = -1 * (step + 1)
                        #visited.add((nextRow, nextCol))
            step += 1


        return ans
        




