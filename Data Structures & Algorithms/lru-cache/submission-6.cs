public class LRUCache {
    int capacity, count = 0;
    Dictionary<int, Node> dict;
    int begin = 0, end = 0;
    public LRUCache(int capacity) {
        this.capacity = capacity;
        dict = new();
    }

    public int Get(int key) {
        if (dict.ContainsKey(key)) {
            var node = dict[key];
            var res = dict[key].val;
            if (node.next != null) {
                Node prev = node.prev, next = node.next;
                if (node.next != null && node.prev != null) {
                    prev.next = next;
                    next.prev = prev;
                } else {
                    begin = next.key;
                    next.prev = null;
                }
                dict[end].next = node;
                node.prev = dict[end];
                node.next = null;

            }
            end = key;
            return res;
        } else
            return -1;
    }

    public void Put(int key, int value) {
        if (dict.ContainsKey(key)) {
            var node = dict[key];
            if (node.next == null) {
                node.val = value;
            } else {
                Node prev = node.prev, next = node.next;
                if (node.next != null && node.prev != null) {
                    prev.next = next;
                    next.prev = prev;
                } else {
                    begin = next.key;
                    next.prev = null;
                }
                dict[end].next = node;
                node.prev = dict[end];
                node.next = null;
                node.val = value;
            }

        } else {
            if (count == 0) {
                begin = key;
                dict.Add(key, new Node(value, key));
                count++;
            } else if (count > 0 && count < capacity) {
                Node new_node = dict[end];
                new_node = new_node.next = new Node(value, key);
                new_node.prev = dict[end];

                dict.Add(key, new_node);
                count++;
            } else {
                var first = dict[begin];
                var last = dict[end];
                if (begin == end) {
                    dict.Remove(begin);
                    dict.Add(key, new Node(value, key));
                    begin = key;
                    end = begin;
                    return;
                }
                first = first.next;
                first.prev = null;
                dict.Remove(begin);
                begin = first.key;
                dict.Add(key, new Node(value, key));
                dict[end].next = dict[key];
                dict[key].prev = dict[end];
            }
        }
        end = key;
    }
}

public class Node {
    public int val;
    public Node next;
    public Node prev;
    public int key;
    public Node(int val = 0, Node next = null, Node prev = null) {
        this.val = val;
        this.next = next;
        this.prev = prev;
    }
    public Node(int val = 0, int key = 0, Node next = null, Node prev = null) {
        this.val = val;
        this.next = next;
        this.prev = prev;
        this.key = key;
    }
}