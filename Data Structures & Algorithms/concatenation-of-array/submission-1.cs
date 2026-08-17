public class Solution {
    public int[] GetConcatenation(int[] nums) {
    int n = nums.Length;
    int[] nums_conc = new int[2*n];
    for (int i = 0; i < n; i++)
    {
        nums_conc[i] = nums[i];
        nums_conc[i+n] = nums[i];
    }
    return nums_conc; 
}
}