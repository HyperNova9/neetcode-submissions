public class PrefixTree {
    TreeNode Tree;
    public PrefixTree() {
        Tree = new();
    }
    public void Insert(string word) {
        var pointer = Tree;
        foreach (var sym in word) {
            if (!pointer.Nodes.ContainsKey(sym)) {
                pointer.Nodes.Add(sym, new());
            }
            pointer = pointer.Nodes[sym];
        }
        pointer.isKey = true;
    }
    public bool Search(string word) {
        var pointer = Tree;
        foreach (var sym in word) {
            if (!pointer.Nodes.ContainsKey(sym)) {
                return false;
            }
            pointer = pointer.Nodes[sym];
        }
        return pointer.isKey;
    }
    public bool StartsWith(string prefix) {
        var pointer = Tree;
        foreach (var sym in prefix) {
            if (!pointer.Nodes.ContainsKey(sym)) {
                return false;
            }
            pointer = pointer.Nodes[sym];
        }
        return true;
    }
}
public class TreeNode {
    public Dictionary<int, TreeNode> Nodes;
    public bool isKey;
    public TreeNode(bool isKey = false) {
        Nodes = new();
        this.isKey = isKey;
    }
}
