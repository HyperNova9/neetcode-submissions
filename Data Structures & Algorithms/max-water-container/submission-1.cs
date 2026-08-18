public class Solution 
{
    public int MaxArea(int[] heights) 
    {
        int n = heights.Length;
        int l = 0, r = n - 1;
        var max = 0;
        while (l < r)
        {
            int left = heights[l], right = heights[r];
            var s = Math.Min(left, right) * (r - l);
            if (s > max)
                max = s;
            if (left < right)
                l++;
            else
                r--;
        }

        return max;
    }
}
