public class Solution {
    public int OrangesRotting(int[][] grid) {
        int min = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;
        Queue<(int row, int col)> BFS = new();
        var directions = new(int r, int c)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) {
                    BFS.Enqueue((r, c));
                    grid[r][c] = 0;
                }
            }
        }
        count = BFS.Count;
        while (BFS.Count > 0) {
            var (row, col) = BFS.Dequeue();
            foreach (var d in directions) {
                var nr = row + d.r;
                var nc = col + d.c;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || grid[nr][nc] == 0)
                    continue;
                BFS.Enqueue((nr, nc));
                grid[nr][nc] = 0;
            }
            count--;
            if (count == 0 && BFS.Count > 0) {
                min++;
                count = BFS.Count;
            }
        }
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 1)
                    return -1;
            }
        }
        return min;
    }
}
