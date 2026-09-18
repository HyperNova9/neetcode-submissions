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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int i = 0, k = 0;
        if (preorder.Length == 0 || inorder.Length == 0)
            return null;
        if (preorder.Length == 1)
            return new TreeNode(preorder[i]);
        while (inorder[k] != preorder[i]) k++;
        var left = BuildTree(preorder.Take(k + 1).Skip(1).ToArray(), inorder.Take(k).ToArray());
        var right = BuildTree(preorder.Skip(k + 1).ToArray(), inorder.Skip(k + 1).ToArray());
        var root = new TreeNode(preorder[i]);
        root.left = left;
        root.right = right;
        return root;
    }
}
