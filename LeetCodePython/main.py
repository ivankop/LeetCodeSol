import sys
import numSimilarGroups
import MaxValueOfCoinsSol
import maxAlternatingSumSol
import shortestSubarraySol
import countGoodStringsSol
import swapNodes
import PaintHouseII
import shortestBridge
import maxScore
import stoneGameII
import CourseScheduleII
import cutstick
import shortestPathBinaryMatrix
import maxIncreasingCells
import solveNQueensSol


sys.path.append(".")

from MaxNumEdgesToRemove import maxNumEdgesToRemoveSol
from swapNodes import ListNode

maxNumEdgesToRemoveSol = maxNumEdgesToRemoveSol()
maxNumEdgesToRemoveSol.maxNumEdgesToRemove(4, [[3,1,2],[3,2,3],[1,1,3],[1,2,4],[1,1,2],[2,3,4]])

maxCoins = MaxValueOfCoinsSol.MaxValueOfCoinsSol()
maxCoins.maxValueOfCoins([[1,100,3],[7,8,9]], 2)

maxAlternatingSum = maxAlternatingSumSol.maxAlternatingSumSol()
maxAlternatingSum.maxAlternatingSum([4,2,5,3])

sortedArr = shortestSubarraySol.shortestSubarraySol()
sortedArr.shortestSubarray([-28,81,-20,28,-29], 89)
sortedArr.shortestSubarray([2,-1,2, 3], 3)
sortedArr.shortestSubarray([84,-37,32,40,95], 167)

sortedArr.shortestSubarray([56,-21,56,35,-9], 61)
sortedArr.shortestSubarray([48,99,37,4,-31], 140)

sortedArr.shortestSubarray([2,-1,2], 3)


countGoodStrings = countGoodStringsSol.countGoodStringsSol()
countGoodStrings.countGoodStrings(2, 3, 1, 2)

swapNodesSol = swapNodes.swapNodesSol()
swapNodesSol.swapNodes(ListNode(1, ListNode(2, ListNode(3, ListNode(4, ListNode(5))))), 2)

painHouse = PaintHouseII.minCostIISol()
painHouse.minCostII([[7,19,11,3,7,15,17,5,6,18,1,15,18,11],[13,18,18,8,13,12,11,13,4,8,2,4,5,20],[14,5,18,4,7,6,1,6,11,6,16,6,13,17],
                     [18,17,11,3,12,4,8,6,2,7,10,9,19,3],[4,3,2,14,11,15,18,1,17,1,6,14,14,9],[9,13,15,14,5,1,1,6,11,15,16,12,10,18],
                     [19,2,11,3,13,4,13,7,16,16,20,18,20,8],[8,19,20,9,18,13,17,1,2,4,3,20,15,9],[9,10,11,6,14,20,4,1,5,15,13,10,13,5],
                     [13,11,9,11,9,16,3,19,1,11,6,7,12,13],[14,1,15,14,11,12,7,14,12,11,6,9,5,5]])


painHouse.minCostII([[11,20,4,3,19,3,18,17,6,8,18,18],[6,14,13,4,8,12,16,4,14,15,11,12],[8,1,4,20,19,9,12,11,13,12,1,3],
                     [8,12,9,3,1,14,3,16,12,13,4,10],[17,1,1,5,17,10,20,15,3,9,18,3],[16,3,18,11,1,16,3,10,19,6,11,13]])
painHouse.minCostII([[1,5,3],[2,9,4]])


shortestBridge = shortestBridge.shortestBridgeSol()


shortestBridge.shortestBridge([[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,1],
                               [0,0,0,0,0,0,0,1,1],[0,0,0,0,0,0,0,1,1],[0,0,0,0,0,0,0,0,1],
                               [0,1,0,0,0,0,0,0,0],[1,1,1,0,0,0,0,0,0],[1,1,0,0,0,0,0,0,0]])

shortestBridge.shortestBridge([
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,0,1,1,1,1,1,1,1,1,1,0,1,0,1,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,1,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,1,1,0,1,1,1,1,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,1,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],
[0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]])


maxScore = maxScore.maxScoreSol()
maxScore.maxScore([79,76,41,28,41,66,44,30,25],[25,0,69,67,55,0,9,77,26], 7)
maxScore.maxScore([4,2,3,1,1],[7,5,10,9,6], 1)


maxScore.maxScore([2,1,14,12],[11,7,13,6], 3)
maxScore.maxScore([1,3,3,2],[2,1,3,4], 3)

stoneGameII = stoneGameII.stoneGameIISol()
stoneGameII.stoneGameII([1,1, 1])
stoneGameII.stoneGameII([1,2,3,4,5,100])
stoneGameII.stoneGameII([2,7,9,4,4])

courseScheduleII = CourseScheduleII.CourseScheduleII()
courseScheduleII.findOrder(3, [[1,0],[1,2],[0,1]])
courseScheduleII.findOrder(3, [[0,1],[0,2],[1,2]])
courseScheduleII.findOrder(2, [[1,0]])

cutstick = cutstick.CutStick()
cutstick.minCost(20, [1,14,18,6,17,8,10,4,13,16,7])
cutstick.minCost(7, [1,3,4,5])

cutstick.minCost(10, [7,8,9,2,1])
cutstick.minCost(5, [3, 1, 4])
cutstick.minCost(9, [5,6,1,4,2])

shortestPathBinary = shortestPathBinaryMatrix.shortestPathBinaryMatrixSol()
shortestPathBinary.shortestPathBinaryMatrix([[0,0,0,1],[0,0,1,0],[0,1,0,0],[1,0,0,0]])
shortestPathBinary.shortestPathBinaryMatrix([[0,1],[1,0]])

def printallSublists(nums, target):
 
    # create a dictionary for storing the end index of all sublists with
    # the sum of elements so far
    d = {}
 
    # To handle the case when the sublist with the given sum starts
    # from the 0th index
    d.setdefault(0, []).append(-1)
 
    sum_so_far = 0
 
    # traverse the given list
    for index in range(len(nums)):
 
        # target of elements so far
        sum_so_far += nums[index]
 
        # check if there exists at least one sublist with the given sum
        if (sum_so_far - target) in d:
            print(*[nums[value+1: index+1] for value in d.get(sum_so_far-target)], end=' ')
 
        # insert (target so far, current index) pair into the dictionary
        d.setdefault(sum_so_far, []).append(index)

printallSublists([3, 4, -7, 1, 3, 3, 1, -4], 7)

maxCells = maxIncreasingCells.maxIncreasingCellsSol()
maxCells.maxIncreasingCells([[1,-8],[4,4],[-3,-9]])
maxCells.maxIncreasingCells([[3,1,6],[-9,5,7]])
maxCells.maxIncreasingCells([[1,1],[1,1]])

solveNQueens = solveNQueensSol.solveNQueensSol()
solveNQueens.solveNQueens(4)
