public class Solution {
    public static void DFS(List<List<int>> Sub, List<int> tracking, int[] nums, int i) {
        int max_i = nums.Length - 1;
        if (i > max_i)
            return;
        if (i >= 0) {
            int num = nums[i];
            tracking.Add(num);
            Sub.Add(new List<int>(tracking));
        }
        DFS(Sub, tracking, nums, i + 1);
        if (tracking.Count > 0)
            tracking.RemoveAt(tracking.Count - 1);
        DFS(Sub, tracking, nums, i + 1);
    }
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> Sub = new();
        List<int> tracking = new();
        DFS(Sub, tracking, nums, 0);
        Sub.Add(new());
        return Sub;
    }
}
