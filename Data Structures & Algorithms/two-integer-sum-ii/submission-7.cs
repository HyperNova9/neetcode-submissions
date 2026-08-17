public class Solution {
    public int[] TwoSum(int[] numbers, int target) 
    {
        var n = numbers.Length;
        var l = 0;
        var r = n - 1;

        while (l < r)
        {
            int sum = numbers[l] + numbers[r];
            if (sum > target)
                r--;
            else if (sum < target)
                l++;
            else
                return new int[] {l+1, r+1};
        }

        return new int[] {};
    }
}
