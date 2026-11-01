public class Solution {
    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        if (n == 1 && m == 1)
            return 0;

        HashSet<(int i, int j)> visited = new();
        PriorityQueue<(int i, int j, int max_h), int> shortPath = new();
        var directions = new(int i, int j)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        shortPath.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        while (shortPath.Count > 0) {
            var curr = shortPath.Dequeue();
            int max_h = curr.max_h, i = curr.i, j = curr.j;
            if (i == n - 1 && j == m - 1) {
                return max_h;
            }
            foreach (var d in directions) {
                var new_i = d.i + i;
                var new_j = d.j + j;

                if (visited.Contains((new_i, new_j)) || new_i >= n || new_i < 0 || new_j >= m ||
                    new_j < 0)
                    continue;
                visited.Add((new_i, new_j));
                var max_edge_points = Math.Max(grid[new_i][new_j], max_h);
                shortPath.Enqueue((new_i, new_j, max_edge_points), max_edge_points);
            }
        }
        return 0;
    }
}
