/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null)
            return null;
        Stack<Node> DFS = new();
        HashSet<Node> visited = new();
        Dictionary<Node, Node> GraphControl = new();
        DFS.Push(node);
        visited.Add(node);
        Node new_graph = null;
        while (DFS.Count > 0) {
            var pointer = DFS.Pop();
            if (new_graph == null) {
                GraphControl.Add(pointer, new(pointer.val));
                new_graph = GraphControl[pointer];
            }
            foreach (var next in pointer.neighbors) {
                if (!visited.Contains(next)) {
                    DFS.Push(next);
                    visited.Add(next);
                    if (!GraphControl.ContainsKey(next))
                        GraphControl.Add(next, new(next.val));
                }
                GraphControl[pointer].neighbors.Add(GraphControl[next]);
            }
        }
        return new_graph;
    }
}
