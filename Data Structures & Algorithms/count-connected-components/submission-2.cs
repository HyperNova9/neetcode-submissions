public class Solution {
    public int CountComponents(int n, int[][] edges) {
        Stack<int> DFS = new();
        HashSet<int> unvisited = new();
        Dictionary<int, List<int>> Graph = new();
        HashSet<int> visited = new();
        int num_components = 0;
        foreach (var edge in edges) {
            for (int i = 0; i <= 1; i++) {
                if (!Graph.ContainsKey(edge[i])) {
                    Graph.Add(edge[i], new());
                }
            }
            Graph[edge[0]].Add(edge[1]);
            Graph[edge[1]].Add(edge[0]);
        }
        for (int i = 0; i < n; i++) {
            unvisited.Add(i);
        }
        while (unvisited.Count > 0) {
            var start = unvisited.First();
            DFS.Push(start);
            visited.Add(start);
            unvisited.Remove(start);
            while (DFS.Count > 0) {
                var node = DFS.Pop();
                if (!Graph.ContainsKey(node))
                    continue;
                foreach (var neighbor in Graph[node]) {
                    if (visited.Contains(neighbor))
                        continue;
                    DFS.Push(neighbor);
                    visited.Add(neighbor);
                    unvisited.Remove(neighbor);
                }
            }
            num_components++;
        }
        return num_components;
    }
}
