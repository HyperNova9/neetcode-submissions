public class Solution {
    public int FindDuplicate(int[] nums) {
        int point = 0, slow = 0, fast = 0;
        int n = nums.Length;
        while (slow != fast || slow == 0 && fast == 0) {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }
        int slow2 = 0;
        while (slow != slow2) {
            slow = nums[slow];
            slow2 = nums[slow2];
        }
        return slow;
    }
}
