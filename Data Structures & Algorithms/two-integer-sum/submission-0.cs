public class Solution {
    public int[] TwoSum(int[] nums, int target) {
       int n = nums.Length;
       for (int i = 0; i < n; i++)
       for (int j = i+1; j < n; j++)
       {
        if (nums[i] + nums[j] == target)
        {
            int[] arr = {i,j};
            return arr;
        }
       }
       return null;
    }
}
