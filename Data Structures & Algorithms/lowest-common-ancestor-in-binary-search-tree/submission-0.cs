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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode anc = null;
        if (root.val < p.val && root.val > q.val || root.val > p.val && root.val < q.val) {
            return root;
        } else if (root.val > p.val && root.val > q.val) {
            anc = LowestCommonAncestor(root.left, p, q);
        } else if (root.val < p.val && root.val < q.val) {
            anc = LowestCommonAncestor(root.right, p, q);
        } else {
            anc = root;
        }
        return anc;
    }
}
