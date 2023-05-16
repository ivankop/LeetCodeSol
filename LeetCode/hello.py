from typing import List

my_string = "exemplary"
print(my_string[0:7:2])
"""
name = input("What is your name ? ")

print ("hello python " + name[2:])
index = name.find(" ")
reversedName = ""
while index >= 0:
    reversedName += name[index]
    index -=1
print(f"hello again {reversedName}")
"""
def add_item(my_list: list) -> list:
    new_item = 10
    my_list = my_list[:]
    my_list.append(new_item)
    return my_list

numbers = [1, 2, 3]
numbers2 = add_item(numbers[:])
print("original list:", numbers)
print("new list:", numbers2)
def older_people(people :list, year :int) -> list:
    result = []
    for p in people:
        if p[1] <= year:
            result.append(p[0])
    return result

p1 = ("Adam", 1977)
p2 = ("Ellen", 1985)
p3 = ("Mary", 1953)
p4 = ("Ernest", 1997)
people = [p1, p2, p3, p4]

older = older_people(people, 1979)
print(older)

def twoSum(nums: List[int], target: int) -> List[int]:
    ans = []
    dic = {}
    for i in range(0,len(nums)):
        if target - nums[i] in dic:
            ans.append(i)
            ans.append(dic[target - nums[i]])
            return ans
        else:
            dic[nums[i]] = i

nums = [2,7,11,15] 
target = 9
ans = twoSum(nums, target)
print(ans)
class isPalindromeSol:
    def isPalindrome(self, x: int) -> bool:
        strX = str(x)
        left = 0
        right = len(strX) - 1
        while left < right:
            if strX[left] != strX[right]:
                return False
            left += 1
            right -= 1
        return True
sol = isPalindromeSol()
print(sol.isPalindrome(x=121))
print(sol.isPalindrome(x=121334))