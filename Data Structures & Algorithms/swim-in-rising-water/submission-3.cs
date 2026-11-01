public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        if (n == 1 && m == 1)
            return 0;
        PriorityQueue<((int i, int j)p1, (int i, int j)p2), int> Kruskal = new();
        Dictionary<(int i, int j), (int i, int j)> DSU = new();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                var curr = grid[i][j];
                DSU.Add((i, j), (i, j));
                if (i + 1 < n) {
                    var down = grid[i + 1][j];
                    Kruskal.Enqueue(((i, j), (i + 1, j)), Math.Max(curr, down));
                }
                if (j + 1 < m) {
                    var right = grid[i][j + 1];
                    Kruskal.Enqueue(((i, j), (i, j + 1)), Math.Max(curr, right));
                }
            }
        }
        (int i, int j) EndToBegin = (-1, -1);
        int max = 0;
        while (EndToBegin != (0, 0)) {
            EndToBegin = (n - 1, m - 1);
            var edge = Kruskal.Dequeue();
            var p1 = grid[edge.p1.i][edge.p1.j];
            var p2 = grid[edge.p2.i][edge.p2.j];
            var root_p1 = edge.p1;
            var root_p2 = edge.p2;
            while (root_p1 != DSU[root_p1] || root_p2 != DSU[root_p2]) {
                if (root_p1 != DSU[root_p1])
                    root_p1 = DSU[root_p1];
                if (root_p2 != DSU[root_p2])
                    root_p2 = DSU[root_p2];
            }
            if (root_p1 == root_p2)
                continue;
            // Comps connect
            if (root_p1 == (0, 0))
                DSU[root_p2] = root_p1;
            else
                DSU[root_p1] = root_p2;
            // Check full way
            while (EndToBegin != DSU[EndToBegin]) EndToBegin = DSU[EndToBegin];
            // Max value point

            if (max < p2)
                max = p2;
            if (max < p1)
                max = p1;
        }
        return max;
    }
}
