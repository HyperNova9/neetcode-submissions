public class Solution {
    public static void DFS_Comb(int[] nums, int target, List<List<int>> Comb, List<int> tracking,
                                int i, int sum) {
        int max_i = nums.Length - 1;
        if (i > max_i)
            return;
        if (sum >= target) {
            if (sum == target)
                Comb.Add(new List<int>(tracking));
            return;
        }
        sum += nums[i];
        tracking.Add(nums[i]);
        DFS_Comb(nums, target, Comb, tracking, i, sum);
        sum -= nums[i];
        tracking.RemoveAt(tracking.Count - 1);
        DFS_Comb(nums, target, Comb, tracking, i + 1, sum);
    }
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<List<int>> Comb = new();
        List<int> tracking = new();
        DFS_Comb(nums, target, Comb, tracking, 0, 0);
        return Comb;
    }
}
