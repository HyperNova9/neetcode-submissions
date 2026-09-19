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
    public static int DFS_MaxSum(TreeNode root, ref int max) {
        if (root == null)
            return 0;
        int left = 0, right = 0;
        left = DFS_MaxSum(root.left, ref max);
        right = DFS_MaxSum(root.right, ref max);
        var num = root.val;
        if (max >= 0)
            if (left + num < 0 && right + num < 0)
                return 0;
        max = Math.Max(max, left + num + right);
        max = Math.Max(max, num + Math.Max(left, right));
        max = Math.Max(max, num);
        return num + Math.Max(left, right);
    }
    public int MaxPathSum(TreeNode root) {
        if (root == null)
            return 0;
        int max = root.val;
        DFS_MaxSum(root, ref max);
        return max;
    }
}
