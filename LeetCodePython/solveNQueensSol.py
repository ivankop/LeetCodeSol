from random import randrange
from typing import List
import copy


class solveNQueensSol:
    def solveNQueens(self, n: int) -> List[List[str]]:
        dir = [[1, 0],[-1, 0],[0, 1],[0, -1],[-1, -1],[1, 1],[1, -1],[-1, 1]]
        blankBoard = [["-"]*n for _ in range(n)]
        visited = set()
        ans = []
        def putQueen(row, col, board):
            newBoard = copy.deepcopy(board)
            newBoard[row][col] = "Q"
            for d in dir:
                nextRow = row
                nextCol = col
                while nextRow >= 0 and nextRow < n and nextCol >= 0 and nextCol < n:
                    if newBoard[nextRow][nextCol] == "-" :
                        newBoard[nextRow][nextCol] = "."
                    nextRow = nextRow + d[0]
                    nextCol = nextCol + d[1]
            return newBoard
            
        def solve(board, currRow):
            if currRow == n:
                ans.append(board)
                return
            
            for j in range(n):
                if board[currRow][j] == "-" :
                    # put Queen in this position
                    newBoard = putQueen(currRow, j, board)
                    solve(newBoard, currRow + 1)
        solve(blankBoard, 0)
        res = []
        for mat in ans:
            sol = []
            for row in mat:
                rowStr = "".join(row)
                sol.append(rowStr)
            res.append(sol)
        return res


            

