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

public class Solution {
    public static List<int> KthSmallestDFS(TreeNode root) {
        List<int> left = null, right = null;
        var list = new List<int>();
        if (root.left == null && root.right == null) {
            list.Add(root.val);
            return list;
        }
        if (root.left != null) {
            left = KthSmallestDFS(root.left);
        }
        if (root.right != null) {
            right = KthSmallestDFS(root.right);
        }
        if (left != null) {
            list.AddRange(left);
        }
        list.Add(root.val);
        if (right != null) {
            list.AddRange(right);
        }
        return list;
    }
    public int KthSmallest(TreeNode root, int k) {
        if (root == null)
            return 0;
        var res = KthSmallestDFS(root);
        return res[k - 1];
    }
}
