public class Solution {
    public static void DFS_Sub2(List<List<int>> Sub, List<int> tracking, int[] nums, int j) {
        for (int i = j; i < nums.Length; i++) {
            tracking.Add(nums[i]);
            DFS_Sub2(Sub, tracking, nums, i + 1);
            tracking.RemoveAt(tracking.Count - 1);
            while (i + 1 < nums.Length && nums[i] == nums[i + 1]) {
                i++;
            }
        }
        Sub.Add(new List<int>(tracking));
    }
    public List<List<int>> SubsetsWithDup(int[] nums) {
        List<List<int>> Sub = new();
        DFS_Sub2(Sub, new(), nums.ToList().OrderBy(x => x).ToArray(), 0);
        return Sub;
    }
}
