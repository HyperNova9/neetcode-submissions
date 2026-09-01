public class Solution {
    public int Search(int[] nums, int target) {
        int n = nums.Length;
        int l = 0, r = n - 1;
        while (l <= r) {
            int mid = (l + r) / 2;
            // Console.WriteLine($"{l} - {r}");
            if (nums[l] <= nums[r]) {
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    r = mid - 1;
                else
                    l = mid + 1;
            } else {
                if (nums[l] <= nums[mid]) {
                    if (nums[l] <= target && target <= nums[mid]) {
                        r = mid;
                        continue;
                    } else
                        l = mid + 1;
                } else {
                    if (nums[mid] <= target && target <= nums[r]) {
                        l = mid;
                        continue;
                    } else
                        r = mid - 1;
                }
            }
        }
        return -1;
    }
}
