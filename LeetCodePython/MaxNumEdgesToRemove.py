from typing import List

class maxNumEdgesToRemoveSol():
    def __init__(self):
        self.title="this is my title"
        self.content= "this is some content"
        self.author= "Ata"
        
    def maxNumEdgesToRemove(self, n: int, edges: List[List[int]]) -> int:
        def findParent(parent: list, f : int) -> int:
            if parent[f] == f :
                return f
            return findParent(parent, parent[f])
        
        def union(parent: list, edgesCount: list, f1: int, f2: int):
            p1 = findParent(parent, f1)
            p2 = findParent(parent, f2)
            if p1 == p2:
                return 0, p1
            parent[p2] = p1
            edgesCount[p1] += edgesCount[p2]
            return 1, p1
        
        parentA = list(range(0, n +1))
        parentB = list(range(0, n +1))
        edgesCountA = list(range(0, n +1))
        edgesCountB = list(range(0, n +1))
        #edgesCountA = 1 * range(0, n + 1)
        #edgesCountB = 1 * range(0, n + 1)

        for i in range(1, n + 1):
            parentA[i] = i
            parentB[i] = i 
            edgesCountA[i] = 1
            edgesCountB[i] = 1 
        count = 0
        headA = 1
        headB = 1
        for i in range(0, len(edges)):
            if edges[i][0] == 3:
                tmp1, headA = union(parentA, edgesCountA, edges[i][1], edges[i][2])
                tmp2, headB = union(parentB, edgesCountB, edges[i][1], edges[i][2])
                if tmp1 > 0 or tmp2 > 0:
                    count += 1
        
        for i in range(0 , len(edges)):
            if edges[i][0] == 1:
                tmp1, headA = union(parentA, edgesCountA, edges[i][1], edges[i][2])
                count += tmp1
            if edges[i][0] == 2:
                tmp2, headB = union(parentB, edgesCountB, edges[i][1], edges[i][2])
                count += tmp2
        if edgesCountA[headA] == n and edgesCountB[headB] == n:
            return len(edges) - count
        return -1


