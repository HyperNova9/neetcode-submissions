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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode p1 = l1, p2 = l2;
        int step = 1, a = 0, b = 0;
        ListNode head = null, end = null;
        int add = 0;
        while (p1 != null || p2 != null) {
            var sum_i = add;
            if (p1 != null)
                sum_i += p1.val;
            if (p2 != null)
                sum_i += p2.val;
            add = 0;
            if (sum_i > 9) {
                sum_i -= 10;
                add = 1;
            }
            if (head == null) {
                head = new ListNode(sum_i);
                end = head;
            } else {
                end = end.next = new ListNode(sum_i);
            }
            if (p1 != null)
                p1 = p1.next;
            if (p2 != null)
                p2 = p2.next;
        }
        if (add == 1) {
            end = end.next = new ListNode(add);
        }
        return head;
    }
}
