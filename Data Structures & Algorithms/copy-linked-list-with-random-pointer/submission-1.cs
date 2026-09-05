/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        Dictionary<Node, Node> Nodes = new();
        Node copy_head = null;
        Node copy_end = null;
        for (var p = head; p != null; p = p.next) {
            if (copy_head == null) {
                copy_head = new Node(p.val);
                copy_end = copy_head;
            } else {
                copy_end = copy_end.next = new Node(p.val);
            }
            Nodes.Add(p, copy_end);
        }
        for (var p = head; p != null; p = p.next) {
            if (p.random != null)
                Nodes[p].random = Nodes[p.random];
            else
                Nodes[p].random = copy_end.next;
        }

        return copy_head;
    }
}
