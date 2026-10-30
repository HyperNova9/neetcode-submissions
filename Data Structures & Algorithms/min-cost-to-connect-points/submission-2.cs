public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        if (points.Length <= 1)
            return 0;
        int n = points.Length;
        PriorityQueue<((int x, int y)p1, (int x, int y)p2), double> PQueue = new();
        Dictionary<(int x, int y), (int x, int y)> DSU = new();
        for (int i = 0; i < n; i++) {
            DSU.Add((points[i][0], points[i][1]), (points[i][0], points[i][1]));
            for (int j = i + 1; j < n; j++) {
                var dist =
                    Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                PQueue.Enqueue(((points[i][0], points[i][1]), (points[j][0], points[j][1])), dist);
            }
        }
        int cost = 0;
        int num_edges = 0;
        while (num_edges != n - 1) {
            var edge = PQueue.Dequeue();
            var p1 = edge.p1;
            var p2 = edge.p2;
            var check_root1 = p1;
            var check_root2 = p2;
            while (check_root1 != DSU[check_root1]) check_root1 = DSU[check_root1];
            while (check_root2 != DSU[check_root2]) check_root2 = DSU[check_root2];
            if (check_root1 == check_root2) {
                continue;
            }
            DSU[check_root2] = check_root1;
            var dist = Math.Abs(edge.p1.x - edge.p2.x) + Math.Abs(edge.p1.y - edge.p2.y);
            cost += dist;
            num_edges++;
        }
        return cost;
    }
}
