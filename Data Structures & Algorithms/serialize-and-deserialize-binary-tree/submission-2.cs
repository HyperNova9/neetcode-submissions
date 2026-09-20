/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Codec {
    string paths;
    private int StrToNum(string str) {
        return int.Parse(str);
    }
    private string DFS_Serialize(TreeNode root, string path) {
        if (root == null)
            return "";
        paths += $"{path}:{root.val}\n";
        DFS_Serialize(root.left, path + "L");
        DFS_Serialize(root.right, path + "R");
        return path;
    }
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        paths = "";
        DFS_Serialize(root, "");
        return paths;
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        TreeNode root = null;
        var strs = data.Split("\n");
        Dictionary<string, TreeNode> dict = new();
        foreach (var elem in strs) {
            if (elem == "")
                continue;
            var str = elem.Split(":");
            string path = str[0];
            int num = StrToNum(str[1]);
            if (dict.Count == 0) {
                root = new TreeNode(num);
                dict.Add(path, root);
                continue;
            }
            int pathLen = path.Length - 1;
            string pre_path = path.Substring(0, pathLen);
            dict.Add(path, new TreeNode(num));
            if (path[path.Length - 1] == 'R')
                dict[pre_path].right = dict[path];
            else
                dict[pre_path].left = dict[path];
        }
        return dict.Count > 0 ? dict[""] : null;
    }
}
