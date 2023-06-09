from typing import List
import sys
from queue import Queue

class shortestPathBinaryMatrixSol:
    def shortestPathBinaryMatrix(self, grid: List[List[int]]) -> int:
        dir = [[1, 0],[-1, 0],[0, 1],[0, -1],[-1, -1],[1, 1],[1, -1],[-1, 1]]
        n = len(grid)
        if grid[0][0] == 1:
            return -1
        queue = Queue()
        queue.put((0, 0))
        step = 1
        visited = set()
        visited.add((0, 0))
        while not queue.empty():
            count = queue.qsize()
            for _ in range(count):
                row, col = queue.get()
                if row == n - 1 and col == n - 1:
                    return step
                for d in dir:
                    nextRow = row + d[0]
                    nextCol = col + d[1]
                    if nextRow >= 0 and nextRow < n and nextCol >= 0 and nextCol < n and (nextRow, nextCol) not in visited and grid[nextRow][nextCol] == 0:
                        if nextRow == n - 1 and nextRow == n - 1:
                            return step + 1
                        queue.put((nextRow, nextCol))
                        visited.add((nextRow, nextCol))
            step += 1

        return -1

