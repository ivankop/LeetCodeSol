# Definition for a binary tree node.
from typing import Optional
from typing import List

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
class delNodesSol:
    def delNodes(self, root: Optional[TreeNode], to_delete: List[int]) -> TreeNode:
        ans = []
        def dfs(node : TreeNode) -> list:
            if node is None:
                return None
            
            if node.val in to_delete:
                arr = [dfs(node.left)]
                if not arr:
                    ans += arr
                arr = [dfs(node.right)]
                if not arr:
                    ans += arr
                    
                return None

            node.left = dfs(node.left)
            node.right = dfs(node.right)
            return node

        ans.append(root)
        return ans
            

            