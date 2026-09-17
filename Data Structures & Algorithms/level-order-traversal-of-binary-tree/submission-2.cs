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
    public List<List<int>> LevelOrder(TreeNode root) {
        if (root == null)
            return new List<List<int>>();
        Queue<TreeNode> queue = new();
        int count = 0;
        List<List<int>> list = new();
        queue.Enqueue(root);
        list.Add(new());
        count++;
        while (queue.Count > 0) {
            if (count == 0) {
                list.Add(new());
                count = queue.Count;
            }
            var elem = queue.Peek();
            list[list.Count - 1].Add(elem.val);
            if (elem.left != null)
                queue.Enqueue(elem.left);
            if (elem.right != null)
                queue.Enqueue(elem.right);
            queue.Dequeue();
            count--;
        }
        return list;
    }
}
