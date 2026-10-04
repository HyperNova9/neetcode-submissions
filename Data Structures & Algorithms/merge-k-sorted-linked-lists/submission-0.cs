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
    public ListNode MergeKLists(ListNode[] lists) {
        PriorityQueue<ListNode, int> sorted_lists = new();
        ListNode merged_head = null;
        ListNode merged_list = null;
        foreach (var list in lists) {
            if (list != null)
                sorted_lists.Enqueue(list, list.val);
        }
        while (sorted_lists.Count > 0) {
            var peek_elem = sorted_lists.Peek();
            if (merged_list == null) {
                merged_list = peek_elem;
                merged_head = peek_elem;
            } else {
                merged_list.next = peek_elem;
                merged_list = merged_list.next;
            }
            sorted_lists.Dequeue();
            peek_elem = peek_elem.next;
            if (peek_elem != null)
                sorted_lists.Enqueue(peek_elem, peek_elem.val);
        }
        if (merged_list != null)
            merged_list.next = null;
        return merged_head;
    }
}
