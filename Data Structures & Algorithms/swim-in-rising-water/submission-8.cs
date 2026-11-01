public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        if (n == 1 && m == 1)
            return grid[0][0];
        int l = int.MaxValue;
        int r = 0;
        var directions = new(int i, int j)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
        // l is minimal height | r is maximum height
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                var curr = grid[i][j];
                if (l > curr)
                    l = curr;
                if (r < curr)
                    r = curr;
            }
        }
        // Binary time search
        while (l < r) {
            int mid = (l + r) / 2;
        
            var DFS = new Stack<(int i, int j)>();
            if (grid[0][0] > mid) {
                l = mid + 1;
                continue;
            }
            DFS.Push((0, 0));
            HashSet<(int i, int j)> visited = new();
            visited.Add((0, 0));
            while (DFS.Count > 0) {
                var curr = DFS.Pop();
                if (curr.i == n - 1 && curr.j == m - 1) {
                    r = mid;
                    break;
                }
                foreach (var d in directions) {
                    var new_i = d.i + curr.i;
                    var new_j = d.j + curr.j;

                    if (visited.Contains((new_i, new_j)) || new_i >= n || new_i < 0 || new_j >= m ||
                        new_j < 0 || grid[new_i][new_j] > mid)
                        continue;

                    visited.Add((new_i, new_j));
                    DFS.Push((new_i, new_j));
                }
                if (DFS.Count == 0) {
                    l = mid + 1;
                }
            }
        }
        return l;
    }
}
