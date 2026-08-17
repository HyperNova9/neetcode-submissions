public class Solution {
    public int LongestConsecutive(int[] nums) {
        var n = nums.Length;
        var max = 0;
        var count = 1;
        var list_nums = nums.ToList().Distinct().OrderBy(x => x).ToList();
        n = list_nums.Count();
        for (int i = 1; i < n; i++)
        {
           if (list_nums[i] - list_nums[i-1] == 1)
           {
            count++;
           }
           else
{
    if (count > max)
    max = count;
    count = 1;
}
        }
        if (count > max && n > 0)
        max = count;
        return max;
    }
}
