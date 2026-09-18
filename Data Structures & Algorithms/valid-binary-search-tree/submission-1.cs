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
    public static bool DFS_BST(TreeNode root, int min, int max) {
        bool left = true, right = true;
        if (root == null)
            return true;
        if (root.left == null && root.right == null)
            if (root.val > min && root.val < max)
                return true;
            else
                return false;
        if (root.val > min && root.val < max) {
            if (root.left != null) {
                left = DFS_BST(root.left, min, root.val);
            }
            if (root.right != null) {
                right = DFS_BST(root.right, root.val, max);
            }
        } else
            return false;
        return left && right;
    }
    public bool IsValidBST(TreeNode root) {
        return DFS_BST(root, int.MinValue, int.MaxValue);
    }
}
