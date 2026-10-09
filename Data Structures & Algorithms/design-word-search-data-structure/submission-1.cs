public class WordDictionary {
    TreeNode Trie;
    public WordDictionary() {
        Trie = new();
    }

    public void AddWord(string word) {
        var pointer = Trie;
        foreach (var sym in word) {
            if (!pointer.Nodes.ContainsKey(sym)) {
                pointer.Nodes.Add(sym, new());
            }
            pointer = pointer.Nodes[sym];
        }
        pointer.isKey = true;
    }

    public bool Search(string word) {
        var pointer = Trie;
        Stack<(TreeNode node, int deep)> stack = new();
        stack.Push((pointer, 0));
        while (stack.Count > 0) {
            var peek_node = stack.Peek();
            var node = peek_node.node;
            var deep = peek_node.deep;
            if (deep < word.Length && word[deep] == '.') {
                stack.Pop();
                foreach (var child in node.Nodes) {
                    stack.Push((child.Value, deep + 1));
                }
            } else if (deep < word.Length && node.Nodes.ContainsKey(word[deep])) {
                stack.Pop();
                stack.Push((node.Nodes[word[deep]], deep + 1));
            } else {
                stack.Pop();
            }
            if (deep == word.Length && node.isKey)
                return true;
        }
        return false;
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
