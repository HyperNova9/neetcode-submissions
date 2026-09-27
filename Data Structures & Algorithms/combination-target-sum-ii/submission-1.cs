public class Solution {
    public static void DFS_Comb2(int[] nums, int target, List<List<int>> Comb, List<int> tracking,
                                 int i, int sum) {
        int max_i = nums.Length - 1;
        if (sum >= target) {
            if (sum == target)
                Comb.Add(new List<int>(tracking));
            return;
        }
        if (i > max_i)
            return;
        sum += nums[i];
        tracking.Add(nums[i]);
        DFS_Comb2(nums, target, Comb, tracking, i + 1, sum);
        sum -= nums[i];
        tracking.RemoveAt(tracking.Count - 1);
        while (i + 1 <= max_i && nums[i + 1] == nums[i]) i++;
        DFS_Comb2(nums, target, Comb, tracking, i + 1, sum);
    }
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        List<List<int>> Comb = new();
        List<int> tracking = new();
        DFS_Comb2(candidates.ToList().OrderBy(x => x).ToArray(), target, Comb, tracking, 0, 0);
        return Comb;
    }
}
