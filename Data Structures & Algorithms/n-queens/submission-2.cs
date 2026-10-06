public class Solution {
    public static void DFS_NQueens(List<List<int>> NQueens, List<int> tracking,
                                   HashSet<int> leftDiags, HashSet<int> rightDiags,
                                   HashSet<int> QueensCol, int deep, int n) {
        if (deep == n) {
            NQueens.Add(new(tracking));
            return;
        }
        for (int i = 0; i < n; i++) {
            if (QueensCol.Contains(i) || leftDiags.Contains(deep + i) ||
                rightDiags.Contains(deep - i)) {
                continue;
            }
            tracking.Add(i);
            QueensCol.Add(i);
            leftDiags.Add(deep + i);
            rightDiags.Add(deep - i);
            DFS_NQueens(NQueens, tracking, leftDiags, rightDiags, QueensCol, deep + 1, n);
            QueensCol.Remove(i);
            leftDiags.Remove(deep + i);
            rightDiags.Remove(deep - i);
            tracking.Remove(i);
        }
    }
    
    public List<List<string>> SolveNQueens(int n) {
        var intQueens = new List<List<int>>();
        DFS_NQueens(intQueens, new(), new(), new(), new(), 0, n);
        var res = new List<List<string>>();
        foreach (var queens in intQueens) {
            res.Add(new());
            foreach (var queen in queens) {
                StringBuilder build = new();
                int last = res.Count - 1;
                for (int i = 0; i < n; i++) {
                    if (queen == i)
                        build.Append('Q');
                    else
                        build.Append('.');
                }
                res[last].Add(build.ToString());
            }
        }
        /* foreach (var elem in res)
                {
                            foreach (var variant in elem)
                                        {
                                                        Console.Write($"{variant} ");
                                                                    }
                                                                                Console.Write("| ");
                                                                                        }*/
        return res;
    }
}
