public class Solution {
    public int Rob(int[] nums) {
        int max = 0;
        int max_prevs = 0;
        int len = nums.Length;
        if (len == 0)
            return 0;
        if (len == 1)
            return nums[0];
        int[] DP = new int[len];
        DP[0] = nums[0];
        max = DP[0] > max ? DP[0] : max;
        DP[1] = nums[1];
        max = DP[1] > max ? DP[1] : max;
        max_prevs = DP[0];
        int i = 2;
        while (i < len) {
            if (DP[i - 2] > max_prevs)
                max_prevs = DP[i - 2];
            DP[i] = max_prevs + nums[i];
            if (DP[i] > max)
                max = DP[i];
            // Console.WriteLine($"i = {i} | DP_i {DP[i]} | max_prevs: {max_prevs}");
            i++;
        }
        return max;
    }
}
