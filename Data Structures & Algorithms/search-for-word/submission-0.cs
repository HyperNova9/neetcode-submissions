public class Solution {
    public static bool DFS_Exist(char[][] board, string word, HashSet<(int i, int j)> tracking,
                                 int i_board, int j_board) {
        bool isWord = false;
        if (tracking.Count == word.Length)
            return true;
        if (tracking.Count == 0) {
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    if (board[i][j] == word[tracking.Count]) {
                        tracking.Add((i, j));
                        isWord = DFS_Exist(board, word, tracking, i, j);
                        tracking.Remove((i, j));
                        if (isWord)
                            return true;
                    }
                }
            }
        } else {
            for (int step = -1; step <= 1; step += 2) {
                (int i, int j) candidate = (i_board, j_board + step);
                if (candidate.j < 0 || candidate.j >= board[i_board].Length)
                    continue;
                if (!tracking.Contains(candidate) &&
                    board[candidate.i][candidate.j] == word[tracking.Count]) {
                    tracking.Add(candidate);
                    isWord = DFS_Exist(board, word, tracking, candidate.i, candidate.j);
                    tracking.Remove(candidate);
                    if (isWord)
                        return true;
                }
            }

            for (int step = -1; step <= 1; step += 2) {
                (int i, int j) candidate = (i_board + step, j_board);
                if (candidate.i < 0 || candidate.i >= board.Length)
                    continue;
                if (!tracking.Contains(candidate) &&
                    board[candidate.i][candidate.j] == word[tracking.Count]) {
                    tracking.Add(candidate);
                    isWord = DFS_Exist(board, word, tracking, candidate.i, candidate.j);
                    tracking.Remove(candidate);
                    if (isWord)
                        return true;
                }
            }
        }
        return false;
    }
    public bool Exist(char[][] board, string word) {
        var res = DFS_Exist(board, word, new(), 0, 0);
        return res;
    }
}
