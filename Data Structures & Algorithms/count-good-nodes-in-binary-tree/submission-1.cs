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
    public static int DFS_count(TreeNode root, int max) {
        int left = 0, right = 0;
        if (root.left == null && root.right == null) {
            if (root.val >= max)
                return 1;
            else
                return 0;
        }
        max = root.val >= max ? root.val : max;
        if (root.left != null)
            left = DFS_count(root.left, max);
        if (root.right != null)
            right = DFS_count(root.right, max);
        if (root.val >= max)
            left++;
        return left + right;
    }
    public int GoodNodes(TreeNode root) {
        int count = 0;
        if (root == null)
            return 0;
        count = DFS_count(root, root.val);
        return count;
    }
}
