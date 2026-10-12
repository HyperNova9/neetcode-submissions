public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        Stack<(int row, int col)> DFS = new();
        List<List<int>> Cells = new();
        var directions = new(int r, int c)[] { (1, 0), (0, -1), (-1, 0), (0, 1) };
        var rows = heights.Length;
        var cols = heights[0].Length;
        HashSet<(int row, int col)> visited = new();
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                bool isPacific = false, isAtlantic = false;
                DFS.Push((r, c));
                visited.Add((r, c));
                while (DFS.Count > 0) {
                    var (row, col) = DFS.Pop();
                    foreach (var d in directions) {
                        var nr = d.r + row;
                        var nc = d.c + col;

                        if (nr < 0 || nc < 0) {
                            isPacific = true;
                            continue;
                        }
                        if (nr >= rows || nc >= cols) {
                            isAtlantic = true;
                            continue;
                        }
                        if (heights[nr][nc] > heights[row][col] || visited.Contains((nr, nc)))
                            continue;
                        DFS.Push((nr, nc));
                        visited.Add((nr, nc));
                    }
                }
                if (isPacific && isAtlantic) {
                    Cells.Add(new());
                    var n = Cells.Count - 1;
                    Cells[n].Add(r);
                    Cells[n].Add(c);
                }
                visited.Clear();
            }
        }
        return Cells;
    }
}
