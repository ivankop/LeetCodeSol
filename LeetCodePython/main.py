import sys
import numSimilarGroups
import MaxValueOfCoinsSol
import maxAlternatingSumSol
import shortestSubarraySol
import countGoodStringsSol
import swapNodes


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
#sortedArr.shortestSubarray([48,99,37,4,-31], 140)

countGoodStrings = countGoodStringsSol.countGoodStringsSol()
countGoodStrings.countGoodStrings(2, 3, 1, 2)

swapNodesSol = swapNodes.swapNodesSol()
swapNodesSol.swapNodes(ListNode(1, ListNode(2, ListNode(3, ListNode(4, ListNode(5))))), 2)