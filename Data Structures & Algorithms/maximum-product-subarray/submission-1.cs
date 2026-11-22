public class Solution {
    public int MaxProduct(int[] nums) {
        int len = nums.Length;
        int l = 0, r = 0;
        int max = int.MinValue;
        int div = 0;

        while (l < len) {
            if (r < len && nums[r] == 0) {
                r++;
                l = r;
                div = 0;
                max = div > max ? div : max;
                continue;
            }

            if (r <= len - 1) {
                if (div == 0)
                    div = nums[r];
                else
                    div *= nums[r];
                r++;
            } else if (div < 0 && r - l > 1) {
                div /= (int)nums[l];
                l++;
            } else
                break;
            max = div > max ? div : max;
        }
        return max;
    }
}
