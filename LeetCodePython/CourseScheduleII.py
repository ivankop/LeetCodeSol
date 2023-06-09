from typing import List
from collections import defaultdict
from queue import Queue

class CourseScheduleII:
    def findOrder(self, numCourses: int, prerequisites: List[List[int]]) -> List[int]:
        map = defaultdict(set)
        
        parentCount = [0] * numCourses
        for li in prerequisites:
            map[li[1]].add(li[0])
            parentCount[li[0]] += 1
        queue = Queue()
        for i in range(numCourses):
            if parentCount[i] == 0:
                queue.put(i)
                # map.pop(i)
        ans = []
        visited = set()
        while not queue.empty():
            count = queue.qsize()
            for _ in range(count):
                course = queue.get()
                if course in visited:
                    continue
                ans.append(course)
                visited.add(course)
                if len(ans) == numCourses:
                    return ans
                for nextCourse in map[course]:
                    parentCount[nextCourse] -= 1
                    if parentCount[nextCourse] == 0:
                        queue.put(nextCourse)
                    
        
        return []
                

        
        