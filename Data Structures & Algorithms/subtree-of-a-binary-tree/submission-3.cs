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
    public static bool IsSameTree(TreeNode p, TreeNode q) {
        bool isLeft = true, isRight = true;
        if (p.left == null && q.left == null && p.right == null && q.right == null)
            return p.val == q.val ? true : false;

        if (p.left == null && q.left != null || p.left != null && q.left == null)
            return false;

        if (p.right == null && q.right != null || p.right != null && q.right == null)
            return false;

        if (p.left != null && q.left != null)
            isLeft = IsSameTree(p.left, q.left);
        if (p.right != null && q.right != null)
            isRight = IsSameTree(p.right, q.right);

        if (!isLeft || !isRight)
            return false;

        if (p.val != q.val)
            return false;
        else
            return true;
    }
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        TreeNode sub = subRoot;
        bool isLeft = false, isRight = false, isEqual = false;
        // null check
        if (root == null)
            return root == sub ? true : false;

        if (sub == null)
            return true;

        if (root.val == sub.val)
            isEqual = IsSameTree(root, sub);

        if (isEqual)
            return true;

        if (root.left != null)
            isLeft = IsSubtree(root.left, sub);

        if (isLeft)
            return true;

        if (root.right != null)
            isRight = IsSubtree(root.right, sub);

        if (isRight)
            return true;

        return false;
    }
}
