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
    public TreeNode DFSBuild(ref int[] preorder, ref int[] inorder, int leftP, int rightP,
                             int leftI, int rightI) {
        TreeNode left = null, right = null;
        int pos = leftI;
        if (rightP == leftP)
            return new TreeNode(preorder[leftP]);
        while (pos <= rightI && inorder[pos] != preorder[leftP]) pos++;
        var leftSize = pos - leftI;
        if (pos - leftI > 0)
            left = DFSBuild(ref preorder, ref inorder, leftP + 1, leftP + leftSize, leftI, pos - 1);
        if (rightI - pos > 0)
            right =
                DFSBuild(ref preorder, ref inorder, leftP + leftSize + 1, rightP, pos + 1, rightI);
        var root = new TreeNode(inorder[pos]);
        root.left = left;
        root.right = right;
        return root;
    }
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int len = preorder.Length;
        return DFSBuild(ref preorder, ref inorder, 0, len - 1, 0, len - 1);
    }
}
