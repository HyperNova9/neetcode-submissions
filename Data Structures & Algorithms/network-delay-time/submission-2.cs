public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        Dictionary<int, List<(int node, int w)>> Graph = new();
        foreach (var t in times) {
            var time = t[2];
            for (int i = 0; i <= 1; i++) {
                if (!Graph.ContainsKey(t[i])) {
                    Graph.Add(t[i], new());
                }
            }
            Graph[t[0]].Add((t[1], time));
        }
        Dictionary<int, (int r, int prev)> Dijkstra = new();
        HashSet<int> unvisited = new();
        for (int i = 1; i <= n; i++) {
            unvisited.Add(i);
            if (i == k) {
                Dijkstra.Add(k, (0, -1));
                continue;
            }
            Dijkstra.Add(i, (int.MaxValue, -1));
        }
        PriorityQueue<int, int> shortestPath = new();
        shortestPath.Enqueue(k, 0);
        int end_k = -1;
        while (shortestPath.Count > 0) {
            var curr = shortestPath.Dequeue();

            if (!unvisited.Contains(curr))
                continue;
            unvisited.Remove(curr);
            foreach (var node in Graph[curr]) {
                var d_curr_r = Dijkstra[curr].r;
                if (Dijkstra[node.node].r > node.w + d_curr_r) {
                    Dijkstra[node.node] = (d_curr_r + node.w, curr);
                    if (unvisited.Contains(node.node))
                        shortestPath.Enqueue(node.node, Dijkstra[node.node].r);
                }
            }
            if (unvisited.Count == 0) {
                end_k = curr;
            }
        }
        if (unvisited.Count > 0)
            return -1;

        return Dijkstra[end_k].r;
    }
}
