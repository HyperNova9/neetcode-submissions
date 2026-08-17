public class Solution {
    public bool hasDuplicate(int[] nums) {
       int n = nums.Length;
       for (int i = 0; i < n; i++)
       for (int j = i+1; j < n; j++)
       if (nums[i] == nums[j])
       return true;
    return false;
 }

}