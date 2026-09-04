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
    public void ReorderList(ListNode head) {
        if (head == null)
            return;
        ListNode mid = head, right = head;
        while (right != null && right.next != null) {
            right = right.next.next;
            mid = mid.next;
        }

        ListNode prev = null;
        ListNode current = mid;
        while (current != null) {
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        ListNode first = head;
        ListNode second = prev;

        while (second != null && first.next != null) {
            ListNode first_next = first.next;
            ListNode second_next = second.next;
            first.next = second;
            first = first.next;
            first.next = first_next;
            first = first.next;
            second = second_next;
        }
        first.next = null;
    }
}
