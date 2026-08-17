public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        int n = nums.Length;
        var dict = new Dictionary<int, int>();
        var uniq_nums = new List<int>();
        for (int i = 0; i < n; i++) {
            if (!dict.ContainsKey(nums[i])) {
                dict.Add(nums[i], 0);
                uniq_nums.Add(nums[i]);
            }
            dict[nums[i]]++;
        }
        var sort_dict = dict.OrderByDescending(x => x.Value);
        var res = sort_dict.Take(k).Select(x => x.Key).ToArray();
        return res;
    }
}
