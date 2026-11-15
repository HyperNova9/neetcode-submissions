public class Solution {
    public int Rob(int[] nums) {
        int max = 0;
        int max_prevs = 0;
        int len = nums.Length;
        if (len == 0)
            return 0;
        if (len == 1)
            return nums[0];
        if (len == 3)
            return Math.Max(nums[0], Math.Max(nums[1], nums[2]));
        int[] DP = new int[len];
        Array.Fill(DP, -1);
        DP[0] = nums[0];
        max = DP[0] > max ? DP[0] : max;
        DP[len - 1] = nums[len - 1];
        max = DP[len - 1] > max ? DP[len - 1] : max;
        max_prevs = DP[len - 1];
        int i = 1;
        while (i < len - 2) {
            int ind = i - 2 < 0 ? len - 1 : i - 2;
            if (DP[ind] > max_prevs && ind != 0)
                max_prevs = DP[ind];
            DP[i] = max_prevs + nums[i];
            if (DP[i] > max)
                max = DP[i];
            // Console.WriteLine($"i = {i} | DP_i {DP[i]} | max_prevs: {max_prevs}");
            i++;
        }
        max_prevs = 0;
        i = len - 2;
        while (i > 1) {
            int ind = i + 2 > len - 1 ? 0 : i + 2;
            if (DP[ind] > max_prevs && ind != len - 1) {
                max_prevs = DP[ind];
            }
            DP[i] = max_prevs + nums[i];
            if (DP[i] > max)
                max = DP[i];
            i--;
        }
        return max;
    }
}
