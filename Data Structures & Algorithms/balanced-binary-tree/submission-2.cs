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
    public static int DFS_2(TreeNode root, ref bool isBalanced) {
        int l = 0, r = 0;
        if (root == null)
            return 0;
        else if (root.right == null && root.left == null)
            return 1;
        r = root.right != null ? DFS_2(root.right, ref isBalanced) : 0;
        l = root.left != null ? DFS_2(root.left, ref isBalanced) : 0;
        if (Math.Abs(r - l) > 1)
            isBalanced = false;
        return Math.Max(l, r) + 1;
    }
    public bool IsBalanced(TreeNode root) {
        bool isBalanced = true;
        DFS_2(root, ref isBalanced);
        return isBalanced;
    }
}
