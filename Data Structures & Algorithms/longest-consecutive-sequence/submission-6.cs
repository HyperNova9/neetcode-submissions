public class Solution {
    public int LongestConsecutive(int[] nums) 
    {
        int n = nums.Length;
        var hash_nums = nums.ToHashSet();
        int res = 0;
        int count_do = 0;
        foreach (var num in hash_nums)
        {
            if (hash_nums.Contains(num-1))
                continue;
            int curr = num;
            int streak = 1;

            while (hash_nums.Contains(curr+1))
            {
                streak++;
                curr++;
            }
            res = Math.Max(res, streak);
        }
        return res;
    }
}
