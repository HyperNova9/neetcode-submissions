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
    public int MaxDepth(TreeNode root) {
        TreeNode left = null, right = null;
        if (root == null)
            return 0;
        left = root.left;
        right = root.right;
        int l = 0, r = 0;
        if (root.right != null) {
            r = MaxDepth(root.right);
        }
        if (root.left != null) {
            l = MaxDepth(root.left);
        }
        if (left == null && right == null) {
            root.val = 1;
            return root.val;
        } else if (left == null || right == null)
            root.val = right != null ? r : l;
        else
            root.val = r > l ? r : l;
        return root.val + 1;
    }
}
