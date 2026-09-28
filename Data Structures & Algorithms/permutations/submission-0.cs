public class Solution {
    public void DFS_Permute(List<List<int>> Perm, List<int> tracking, int[] nums,
                            HashSet<int> Used) {
        if (Used.Count == nums.Length)
            Perm.Add(new List<int>(tracking));
        for (int i = 0; i < nums.Length; i++) {
            if (!Used.Contains(nums[i])) {
                tracking.Add(nums[i]);
                Used.Add(nums[i]);
                DFS_Permute(Perm, tracking, nums, Used);
                Used.Remove(nums[i]);
                tracking.Remove(nums[i]);
            }
        }
    }

    public List<List<int>> Permute(int[] nums) {
        var Perm = new List<List<int>>();
        var tracking = new List<int>();
        if (nums.Length == 0)
            return Perm;
        DFS_Permute(Perm, new(), nums, new());
        return Perm;
    }
}
