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
    public ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null)
            return null;
        ListNode new_head = null;
        ListNode start = head, end = head;
        ListNode prev_end = null;
        while (end != null) {
            bool isReverse = true;
            for (int i = 1; i < k; i++) {
                if (end.next == null) {
                    isReverse = false;
                    break;
                }
                end = end.next;
            }
            // Console.WriteLine($"[BEFORE]start: {start.val} | end: {end.val}\n");
            if (!isReverse) {
                // Console.WriteLine("Not reversed");
                if (prev_end != null)
                    prev_end.next = start;
                else
                    new_head = start;
                break;
            }
            ListNode prev = null, pointer = start, next = start.next;
            for (int i = 0; i < k; i++) {
                pointer.next = prev;
                prev = pointer;
                pointer = next;
                if (pointer != null)
                    next = pointer.next;
            }
            if (new_head == null)
                new_head = prev;
            if (prev_end != null) {
                prev_end.next = end;
            }
            prev_end = start;
            //    Console.WriteLine($"[AFTER]start: {start.val} | end: {end.val}\n");
            start = pointer;
            end = pointer;
        }
        return new_head;
    }
}
