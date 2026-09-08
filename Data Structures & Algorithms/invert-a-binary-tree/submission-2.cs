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
    public TreeNode InvertTree(TreeNode root) {
        if (root == null)
            return null;
        if (root.right != null || root.left != null) {
            TreeNode swap = root.left;
            root.left = root.right;
            root.right = swap;
        }
        if (root.right != null)

            InvertTree(root.right);
        if (root.left != null)
            InvertTree(root.left);

        return root;
    }
}
