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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode merge_end = null;
        ListNode merge_head = null;
        merge_head = merge_end;
        while (list1 != null || list2 != null) {
            ListNode new_node;
            if (list1 == null) {
                new_node = new ListNode(list2.val);
                list2 = list2.next;
            } else if (list2 == null) {
                new_node = new ListNode(list1.val);
                list1 = list1.next;
            } else {
                if (list1.val <= list2.val) {
                    new_node = new ListNode(list1.val);
                    list1 = list1.next;
                } else {
                    new_node = new ListNode(list2.val);
                    list2 = list2.next;
                }
            }
            if (merge_head == null)
                merge_head = new_node;
            if (merge_end == null)
                merge_end = new_node;
            else {
                merge_end.next = new_node;
                merge_end = new_node;
            }
        }
        return merge_head;
    }
}