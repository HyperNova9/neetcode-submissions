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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        int i = 0;
        ListNode point = head;
        ListNode prev = null;
        for (var node = head; node != null; node = node.next, i++);
        i = i - n;
        if (i <= 0)
            return head.next;
        while (i > 0) {
            ListNode next = point.next;
            prev = point;
            point = next;
            i--;
        }
        prev.next = point.next;
        return head;
    }
}
