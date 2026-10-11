public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        Queue<(int row, int col)> BFS = new();
        int rows = grid.Length;
        int cols = grid[0].Length;
        var directions = new(int r, int c)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        // Цикл добавления всех сундуков в очередь
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 0) {
                    BFS.Enqueue((r, c));
                }
            }
        }
        // Пока не посещены все клетки движем указатели по алгоритму
        // Поиска в ширинц BFS
        while (BFS.Count > 0) {
            var (row, col) = BFS.Dequeue();
            foreach (var d in directions) {
                int nr = d.r + row;
                int nc = d.c + col;

                // Проверка границ сетки
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || grid[nr][nc] == -1)
                    continue;
                // Проверка на дальнейший путь (меньше путь значит выгоднее)
                if (grid[row][col] + 1 < grid[nr][nc]) {
                    grid[nr][nc] = grid[row][col] + 1;
                    BFS.Enqueue((nr, nc));
                }
            }
        }
    }
}
