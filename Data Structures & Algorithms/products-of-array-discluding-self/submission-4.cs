public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
    int n = nums.Length;
    int[] output = new int[n];
    int left = 1, right = 1;
       for (int i = 0; i < n; i++)
       {
        output[i] = left;
        left *= nums[i];
       }
       for (int i = n - 1; i >= 0; i--)
       {
        output[i] *= right;
        right *= nums[i];
       }
       return output;
    }
}
