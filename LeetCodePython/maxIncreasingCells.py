from typing import List
import sys

class maxIncreasingCellsSol:
    def maxIncreasingCells(self, mat: List[List[int]]) -> int:
        
        m = len(mat)
        n = len(mat[0])
        cells = []
        sortedCol = [[] for _ in range(n)]
        sortedRow = [[] for _ in range(m)]
        for i in range(m):
            row = list(zip(range(n), mat[i]))
            row.sort(key = lambda x : x[1])
            sortedRow[i] = row
            for j in range(n):
                cells.append((mat[i][j], i, j))
                sortedCol[j].append((i, mat[i][j]))
        for j in range(n):
            sortedCol[j].sort(key = lambda x : x[1])

        cells.sort(reverse=True)
        #dpr = [ [1] * n for _ in range(m)]
        #dpc = [ [1] * n for _ in range(m)]
        dp =  [ [1] * n for _ in range(m)]
        maxRow = [1] * m
        maxCol = [1] * n
        ans = 0
        '''
        maxVal, maxRow, maxCol = cells[0]
        dpr[maxRow][maxCol] = 1
        dpc[maxRow][maxCol] = 1
        '''
        for i in range(m * n):
            val, row, col = cells[i]

            
            for c,cellVal in sortedRow[row]:
                if cellVal < mat[row][col]:
                    dp[row][c] = max(dp[row][c], dp[row][col] + 1)
                else:
                    break

            for r,cellVal in sortedCol[col]:
                if cellVal < mat[row][col]:
                    dp[r][col] = max(dp[r][col], dp[row][col] + 1)
                else:
                    break
            
            ans = max(ans, dp[row][col])
            
        return ans

    def maxIncreasingCells_rec(self, mat: List[List[int]]) -> int:
        m = len(mat)
        n = len(mat[0])
        sortedCol = [[] for _ in range(n)]
        rowMap = {}
        colMap = {}
        mem = {}
        for i in range(m):
            row = list(zip(range(n), mat[i]))
            row.sort(key = lambda x : x[1], reverse=True)
            tmpSet = set()
            for j in range(n):
                (index, _) = row[j]
                rowMap[(i, index)] = set(tmpSet)
                tmpSet.add(index)
                sortedCol[j].append((i, mat[i][j]))       

        for j in range(n):
            sortedCol[j].sort(key = lambda x : x[1], reverse=True)
            tmpSet = set()
            for i in range(m):
                (index, _) = sortedCol[j][i]
                colMap[(j, index)] = set(tmpSet)
                tmpSet.add(index)

        def dfs(row, col, visited : set):
            if (row, col) in mem:
                return mem[(row, col)]
            rowStep = 1
            colStep = 1
            visited.add((row, col))
            if (row, col) in rowMap:
                for nextCol in rowMap[(row, col)]:
                    if mat[row][nextCol] > mat[row][col] and (row, nextCol) not in visited:
                        rowStep = max(rowStep, dfs(row, nextCol, set(visited)) + 1)
                        visited.add((row, nextCol))
                    
            if (col, row) in colMap:
                for nextRow in colMap[(col, row)]:
                    if mat[nextRow][col] > mat[row][col] and (nextRow, col) not in visited:
                        colStep = max(colStep, dfs(nextRow, col, set(visited)) + 1)
                        visited.add((nextRow, col))
            
            mem[(row, col)] = max(rowStep, colStep)
            return mem[(row, col)]
        ans = 0
        for i in range(m):
            for j in range(n):
                ans = max(ans, dfs(i, j, set()))
        return ans      