public class Solution {
    public int NumIslands(char[][] grid) {
        Queue<(int row, int col)> island = new();
        var rows = grid.Length;
        var cols = grid[0].Length;
        int count = 0;
        var directions = new(int dr, int dc)[] { (-1, 0), (1, 0), (0, 1), (0, -1) };

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (grid[i][j] == '0')
                    continue;
                island.Enqueue((i, j));
                grid[i][j] = '0';
                while (island.Count > 0) {
                    (int row, int col) pos = island.Dequeue();
                    foreach ((int dr, int dc) in directions) {
                        var nr = pos.row + dr;
                        var nc = pos.col + dc;
                        if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                            continue;

                        if (grid[nr][nc] == '1') {
                            island.Enqueue((nr, nc));
                            grid[nr][nc] = '0';
                        }
                    }
                }
                count++;
            }
        }
        return count;
    }
}
