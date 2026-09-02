/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public bool HasCycle(ListNode head) {
        HashSet<ListNode> set = new();
        for (var p = head; p != null; p = p.next) {
            if (set.Contains(p))
                return true;
            else
                set.Add(p);
        }
        return false;
    }
}
