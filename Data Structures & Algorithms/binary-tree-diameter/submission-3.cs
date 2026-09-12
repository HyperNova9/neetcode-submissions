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
    public int DiameterOfBinaryTree(TreeNode root) {
int res = 0;
DFS(root, ref res);
return res;
    }
    public static int DFS(TreeNode root,ref int res) {
        int l = 0, r = 0;
        if (root == null || root.right == null && root.left == null)
            return 1;

        if (root.left != null) {
            l = DFS(root.left, ref res);
        }
        if (root.right != null) {
            r = DFS(root.right, ref res);
        }
        res = Math.Max(res, l + r);
        return Math.Max(l,r) + 1;
    }
}
