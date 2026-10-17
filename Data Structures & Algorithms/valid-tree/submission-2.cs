public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length == 0)
        return true;
        if (edges.Length != n - 1)
            return false;
        Stack<int> DFS = new();
        Dictionary<int, List<int>> Graph = new();
        HashSet<int> visited = new();

        foreach (var edge in edges) {
            if (!Graph.ContainsKey(edge[0])) {
                Graph.Add(edge[0], new());
            }
            Graph[edge[0]].Add(edge[1]);
            if (!Graph.ContainsKey(edge[1])) {
                Graph.Add(edge[1], new());
            }
            Graph[edge[1]].Add(edge[0]);
        }
        DFS.Push(0);
        visited.Add(0);
        while (DFS.Count > 0) {
            var node = DFS.Pop();
            foreach (var neighbor in Graph[node]) {
                if (visited.Contains(neighbor))
                    continue;
                DFS.Push(neighbor);
                visited.Add(neighbor);
            }
        }
        if (visited.Count != n)
            return false;

        return true;
    }
}
