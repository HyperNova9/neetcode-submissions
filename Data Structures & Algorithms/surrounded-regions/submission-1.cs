public class Solution {
    public void Solve(char[][] board) {
        var rows = board.Length;
        var cols = board[0].Length;
        var directions = new(int r, int c)[] { (1, 0), (0, -1), (-1, 0), (0, 1) };

        Stack<(int r, int c)> DFS = new();
        HashSet<(int row, int col)> safe_O = new();
        for (int r = 0; r < rows; r++) {
            if (board[r][0] == 'O') {
                DFS.Push((r, 0));
                safe_O.Add((r, 0));
            }
            if (board[r][cols - 1] == 'O') {
                DFS.Push((r, cols - 1));
                safe_O.Add((r, cols - 1));
            }
        }
        for (int c = 1; c < cols - 1; c++) {
            if (board[0][c] == 'O') {
                DFS.Push((0, c));
                safe_O.Add((0, c));
            }
            if (board[rows - 1][c] == 'O') {
                DFS.Push((rows - 1, c));
                safe_O.Add((rows - 1, c));
            }
        }
        while (DFS.Count > 0) {
            var (row, col) = DFS.Pop();
            foreach (var d in directions) {
                var nr = d.r + row;
                var nc = d.c + col;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || board[nr][nc] == 'X' ||
                    safe_O.Contains((nr, nc)))
                    continue;
                DFS.Push((nr, nc));
                safe_O.Add((nr, nc));
            }
        }
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (board[r][c] != 'O' || safe_O.Contains((r, c)))
                    continue;
                DFS.Push((r, c));
                board[r][c] = 'X';
                while (DFS.Count > 0) {
                    var (row, col) = DFS.Pop();
                    foreach (var d in directions) {
                        var nr = d.r + row;
                        var nc = d.c + col;
                        if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || board[nr][nc] == 'X')
                            continue;
                        DFS.Push((nr, nc));
                        board[nr][nc] = 'X';
                    }
                }
            }
        }
    }
}
