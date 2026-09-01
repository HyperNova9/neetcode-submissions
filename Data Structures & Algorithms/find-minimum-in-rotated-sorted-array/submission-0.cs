public class Solution {
    public int FindMin(int[] nums) {
        int n = nums.Length;
        int l = 0, r = n - 1;
        int min = int.MaxValue;
        while (l <= r) {
            if (nums[l] <= nums[r])
                return nums[l];
            var mid = (int)(l + r) / 2;
            Console.WriteLine($"{l} - {r}");
            if (nums[mid] > nums[r])
                l = mid + 1;
            else
                r = mid;
        }
        return nums[l];
    }
}
