public class Solution {
    public static void DFS_Board(char[][] board, (int row, int col)[] directions, TreeNode Trie,
                                 List<string> words, HashSet<(int row, int col)> tracking_way,
                                 StringBuilder tracking_word, int row, int col) {
        if (tracking_way.Count == 0) {
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    if (Trie.Nodes.ContainsKey(board[i][j])) {
                        tracking_way.Add((i, j));
                        tracking_word.Append(board[i][j]);
                        if (Trie.Nodes[board[i][j]].isKey) {
                            var word = tracking_word.ToString();
                            Trie.Nodes[board[i][j]].isKey = false;
                            words.Add(word);
                        }
                        DFS_Board(board, directions, Trie.Nodes[board[i][j]], words, tracking_way,
                                  tracking_word, i, j);
                        if (Trie.Nodes[board[i][j]].Nodes.Count == 0) {
                            Trie.Nodes.Remove(board[i][j]);
                        }
                        tracking_word.Remove(tracking_word.Length - 1, 1);
                        tracking_way.Remove((i, j));
                    }
                }
            }
        } else {
            foreach (var d in directions) {
                if (row + d.row < 0 || row + d.row >= board.Length || col + d.col < 0 ||
                    col + d.col >= board[row].Length ||
                    tracking_way.Contains((row + d.row, col + d.col)))
                    continue;

                var new_row = row + d.row;
                var new_col = col + d.col;
                var candidate = board[new_row][new_col];

                if (Trie.Nodes.ContainsKey(candidate)) {
                    tracking_way.Add((new_row, new_col));
                    tracking_word.Append(candidate);
                    if (Trie.Nodes[candidate].isKey) {
                        var word = tracking_word.ToString();
                        Trie.Nodes[candidate].isKey = false;
                        words.Add(word);
                    }
                    DFS_Board(board, directions, Trie.Nodes[candidate], words, tracking_way,
                              tracking_word, new_row, new_col);
                    if (Trie.Nodes[candidate].Nodes.Count == 0) {
                        Trie.Nodes.Remove(candidate);
                    }
                    tracking_word.Remove(tracking_word.Length - 1, 1);
                    tracking_way.Remove((new_row, new_col));
                }
            }
        }
    }
    public List<string> FindWords(char[][] board, string[] words) {
        var directions = new(int row, int col)[] { (0, -1), (0, 1), (1, 0), (-1, 0) };
        var Trie = new TreeNode();
        var res = new List<string>();
        foreach (var word in words) {
            var pointer = Trie;
            foreach (var letter in word) {
                if (!pointer.Nodes.ContainsKey(letter)) {
                    pointer.Nodes.Add(letter, new());
                }
                pointer = pointer.Nodes[letter];
            }
            pointer.isKey = true;
        }
        DFS_Board(board, directions, Trie, res, new(), new(), 0, 0);
        return res;
    }
}
public class TreeNode {
    public Dictionary<char, TreeNode> Nodes;
    public bool isKey;
    public TreeNode(bool isKey = false) {
        Nodes = new();
        this.isKey = isKey;
    }
}
