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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null)
        return true;
        else if (p == null && q != null || p != null && q == null)
        return false;
        bool isLeft = true, isRight = true;
        if (p.left == null && q.left == null && p.right == null && q.right == null)
            return p.val == q.val ? true : false;

        if (p.left == null && q.left != null || p.left != null && q.left == null)
            return false;

        if (p.right == null && q.right != null || p.right != null && q.right == null)
            return false;

        isLeft = IsSameTree(p.left, q.left);
        isRight = IsSameTree(p.right, q.right);

        if (!isLeft || !isRight)
            return false;
        else
            return true;

        if (p.val != q.val)
            return false;
        else
            return true;
    }
}
