public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        Stack<(int row, int col)> DFS = new();
        List<List<int>> Cells = new();
        var directions = new (int r, int c)[]
        {
            (1, 0),
            (0, -1),
            (-1, 0),
            (0, 1)
        };
        var rows = heights.Length;
        var cols = heights[0].Length;

        HashSet<(int row, int col)> Pacific = new();
        HashSet<(int row, int col)> Atlantic = new();
        for (int i = 0; i < rows; i++)
        {
            Pacific.Add((i, 0));
            DFS.Push((i, 0));
        }
        for (int j = 0; j < cols; j++)
        {
            Pacific.Add((0, j));
            DFS.Push((0, j));
        }

        while (DFS.Count > 0)
        {
            var (row, col) = DFS.Pop();
            foreach (var d in directions)
            {
                var nr = d.r + row;
                var nc = d.c + col;
                if (nr < 0 || nr >= rows
                || nc < 0 || nc >= cols ||
                Pacific.Contains((nr, nc)))
                {
                    continue;
                }
                if (heights[nr][nc] >= heights[row][col])
                {
                    Pacific.Add((nr, nc));
                    DFS.Push((nr, nc));
                }
            }
        }
        for (int i = 0; i < rows; i++)
        {
            (int r, int c) point = (i, cols - 1);
            Atlantic.Add(point);
            DFS.Push(point);
        }
        for (int j = 0; j < cols; j++)
        {
            (int r, int c) point = (rows - 1, j);
            Atlantic.Add(point);
            DFS.Push(point);
        }

        while (DFS.Count > 0)
        {
            var (row, col) = DFS.Pop();
            foreach (var d in directions)
            {
                var nr = d.r + row;
                var nc = d.c + col;
                if (nr < 0 || nr >= rows
                || nc < 0 || nc >= cols ||
                Atlantic.Contains((nr, nc)))
                {
                    continue;
                }
                if (heights[nr][nc] >= heights[row][col])
                {
                    Atlantic.Add((nr, nc));
                    DFS.Push((nr, nc));
                }
            }
        }
        
        foreach (var (row, col) in Pacific)
        {
            if (Atlantic.Contains((row, col)))
                Cells.Add(new() {row, col});
        }
        return Cells;
    }
}
