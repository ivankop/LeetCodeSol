# Definition for singly-linked list.
from typing import Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class swapNodesSol:
    def swapNodes(self, head: Optional[ListNode], k: int) -> Optional[ListNode]:
        nodes =[]
        current = head
        while current is not None:
            nodes.append(current)
            current = current.next
        first = nodes[k - 1]
        second = nodes[-(k)]
        tmp = first.val
        first.val = second.val
        second.val = tmp
        return head